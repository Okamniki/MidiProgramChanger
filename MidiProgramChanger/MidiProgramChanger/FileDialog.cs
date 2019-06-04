using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MidiProgramChanger
{
    static class FileDialog
    {
        private const string DEF_FILENAME = "";
        private const string DEF_FILTER = "MIDIファイル(*.midi;*.mid)|*.midi;*.mid|すべてのファイル(*.*)|*.*";
        private const int DEF_FILTERINDEX = 1;
        private const string DEF_SAVE_TITLE = "名前を付けてファイルを保存";
        private const string DEF_OPEN_TITLE = "ファイルを開く";
        
        public static bool TryGetOpenPath(string filter, int filterIndex, string title, out string filePath)
        {

            using (OpenFileDialog ofd = new OpenFileDialog())
            {


                ofd.Filter = filter;

                ofd.FilterIndex = filterIndex;

                ofd.Title = title;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    return true;
                }
            }

            filePath = "";
            return false;
        }

        public static bool TryGetOpenPath(out string filePath)
        {
            return TryGetOpenPath(DEF_FILTER, DEF_FILTERINDEX, DEF_OPEN_TITLE, out filePath);
        }

        public static bool TryGetSavePath(string fileName, string filter, int filterIndex, string title, out string filePath)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = fileName;

                sfd.Filter = filter;

                sfd.FilterIndex = filterIndex;

                sfd.Title = title;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    filePath = sfd.FileName;
                    return true;
                }
            }

            filePath = "";
            return false;
        }

        public static bool TryGetSavePath(string fileName, string filter, out string filePath)
        {
            return TryGetSavePath(fileName, filter, DEF_FILTERINDEX, DEF_SAVE_TITLE, out filePath);
        }

        public static bool TryGetSavePath(string fileName, out string filePath)
        {
            return TryGetSavePath(fileName, DEF_FILTER, DEF_FILTERINDEX, DEF_SAVE_TITLE, out filePath);
        }

        public static bool TryGetSavePath(out string filePath)
        {
            return TryGetSavePath(DEF_FILENAME, DEF_FILTER, DEF_FILTERINDEX, DEF_SAVE_TITLE, out filePath);
        }
        
        public static bool TryGetSaveStream(string fileName, string filter, int filterIndex, string title, out Stream stream)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = fileName;

                sfd.Filter = filter;

                sfd.FilterIndex = filterIndex;

                sfd.Title = title;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    stream = sfd.OpenFile();
                    if (stream != null)
                    {
                        return true;
                    }

                }
            }

            stream = null;
            return false;
        }

        public static bool TryGetSaveStream(out Stream stream)
        {
            return TryGetSaveStream(DEF_FILENAME, DEF_FILTER, DEF_FILTERINDEX, DEF_SAVE_TITLE, out stream);
        }

    }
}
