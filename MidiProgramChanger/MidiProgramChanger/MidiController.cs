using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MidiProgramChanger
{
    class MidiController
    {

        private readonly int MIDI_HEADER_LENGTH = 14;
        private readonly byte[] TRACK_START = new byte[] { 0x04, 0x54, 0x72, 0x6B };
        private readonly byte[] TRACK_END = new byte[] { 0xFF, 0x2F, 0x0 };

        private readonly SettingList _settingList;

        public MidiController(SettingList settingList)
        {
            _settingList = settingList;
        }

        public bool Convert(string importFilePath, string exportFilePath)
        {
            byte[] midiData = OpenMidiFile(importFilePath);

            List<byte[]> trackList = DivideIntoTrack(midiData);

            List<byte[]> editedTrackList = AddProgramChange(trackList);

            byte[] editedMidiData = CombineTrack(editedTrackList);

            ExportMidiFile(editedMidiData, exportFilePath);

            return true;

        }

        public void TrackListTest(List<byte[]> TrackList)
        {
            foreach (var tt in TrackList)
            {
                foreach (var ee in tt)

                    Debug.Write(ee.ToString("X") + " ");
                Debug.WriteLine("");
            }
        }

        private byte[] OpenMidiFile(string filePath)
        {
            byte[] midiData;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var fileSize = (int)fs.Length;
                midiData = new byte[fileSize];
                // Read
                int readSize = 0;

                int remain = fileSize;

                int bufpos = 0;

                while (remain > 0)
                {
                    readSize = fs.Read(midiData, bufpos, Math.Min(1024, remain));
                    bufpos += readSize;
                    remain -= readSize;
                }
            }
            return midiData;
        }

        private List<byte[]> DivideIntoTrack(byte[] midiData)
        {
            var trackList = new List<byte[]>();

            byte[] midiHeader = midiData.Take(14).ToArray();
            trackList.Add(midiHeader);
            var trackSt = 0;

            while (MIDI_HEADER_LENGTH + trackSt + 3 <= midiData.Length)
            {

                int trackLen = Common.BMSearch(midiData.Skip(14 + trackSt).ToArray(), TRACK_END) + 3;

                byte[] track = midiData.Skip(MIDI_HEADER_LENGTH + trackSt).Take(trackLen).ToArray();
                trackList.Add(track);
                trackSt += trackLen;
            }
            return trackList;

        }

        private List<byte[]> AddProgramChange(List<byte[]> trackList)
        {
            for (var i_track = 2; i_track < trackList.Count; i_track++)
            {

                var trackNameByte = trackList[i_track].Skip(12).Take(trackList[i_track][11]).ToArray();

                var trackName = Encoding.GetEncoding(932).GetString(trackNameByte);

                int channelNum = 0;
                var MatchChannel = _settingList.InstrumentList.Where(t => t.TrackName == trackName).Select(t => t.Channnel);


                if (!MatchChannel.Any())
                {
                    continue;
                }

                var ProgramChange = _settingList.InstrumentList.Where(t => t.TrackName == trackName).Select(t => t.ProgramChange).First();

                channelNum = MatchChannel.First();

                // 初回の&H90より前に 00 B0 00 00 , 00 B0 20 00 , 00 C0 28
                int firstnote = 0;

                for (var i_event = 0; i_event < trackList[i_track].Count(); i_event++)
                {
                    if (trackList[i_track][i_event] == 0x80 || trackList[i_track][i_event] == 0x90)
                    {
                        firstnote = firstnote == 0 ? i_event : firstnote;
                        trackList[i_track][i_event] = (byte)(trackList[i_track][i_event] + channelNum - 1);
                    }
                }

                if (firstnote != 0)
                {
                    List<byte> l_track = trackList[i_track].ToList();

                    byte[] cc = new byte[] { 0x0, 0xB0, 0x0, 0x0, 0x0, 0xB0, 0x20, 0x0, 0x0, 0xC0, 0x0 };
                    cc[1] += (byte)(channelNum - 1);
                    cc[5] += (byte)(channelNum - 1);
                    cc[9] += (byte)(channelNum - 1);
                    cc[10] += (byte)(ProgramChange - 1);

                    l_track.InsertRange(firstnote - 1, cc);

                    l_track[7] = (byte)(11 + trackList[i_track][7]);
                    trackList[i_track] = l_track.ToArray();
                }
            }
            return trackList;
        }

        private byte[] CombineTrack(List<byte[]> trackList)
        {
            List<byte> oneTrack = new List<byte>();

            foreach (byte[] track in trackList)
            {
                oneTrack.InsertRange(oneTrack.Count, track);
            }

            byte[] midiData = oneTrack.ToArray();

            int i_export = 0;

            foreach (var exTrack in trackList)
            {
                foreach (var exEvent in exTrack)
                {
                    midiData[i_export] = exEvent;
                    i_export += 1;
                }
            }

            return oneTrack.ToArray();
        }

        private bool ExportMidiFile(byte[] midiData, string fileName)
        {

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(midiData, 0, midiData.Length);
            }

            return true;
        }
    }
}
