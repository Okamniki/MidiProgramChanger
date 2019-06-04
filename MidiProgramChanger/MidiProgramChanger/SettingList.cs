using System.Collections.Generic;

public class SettingList
{
    /// <summary>
    /// 楽器リスト
    /// </summary>
    /// <returns></returns>
    public List<Instrument> InstrumentList { get; set; }

    public const string SettingFileName = "SettingList.xml";
}

/// <summary>

/// ''' 楽器クラス

/// ''' </summary>
public class Instrument
{
    private int _Channnel;
    public string TrackName { get; set; }
    public string InstrumentName { get; set; }
    private int _ProgramChange;

    public int Channnel
    {
        get
        {
            return _Channnel;
        }
        set
        {
            if (value < 0 || 16 < value)
                _Channnel = 0;
            else
                _Channnel = value;
        }
    }

    public int ProgramChange
    {
        get
        {
            return _ProgramChange;
        }
        set
        {
            if (value < 0 || 128 < value)
                _ProgramChange = 0;
            else
                _ProgramChange = value;
        }
    }
}
