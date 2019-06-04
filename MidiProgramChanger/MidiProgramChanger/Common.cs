using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Common
{
    public static int BMSearch(byte[] target, byte[] pattern)
    {
        int i = pattern.Length - 1;
        while (i < target.Length)
        {
            int p = pattern.Length - 1;

            while (p >= 0 && i < target.Length)
            {
                if (target[i] == pattern[p])
                {
                    i -= 1;
                    p -= 1;
                }
                else
                    break;
            }

            if (p < 0)
                return i + 1;
            Dictionary<byte, int> table = CreateTable(pattern);
            int shift1 = table.ContainsKey(pattern[p]) ? table[pattern[p]] : pattern.Length;
            int shift2 = pattern.Length - p;
            i += Math.Max(shift1, shift2);
        }

        return -1;
    }

    public static Dictionary<byte, int> CreateTable(byte[] pattern)
    {
        var table = new Dictionary<byte, int>();

        for (int i = 0; i <= pattern.Length - 1; i++)
            table[pattern[i]] = pattern.Length - i - 1;

        return table;
    }

    public enum ExportType
    {
        Date = 0,
        SerialNumber
    }

    static public string GetNewFilePath(string srcFilePath, ExportType exType)
    {
        string srcFolderPath = SplitWithoutLast(srcFilePath, '\\');
        string srcFileName = SplitWithoutLast(srcFilePath.Split('\\').Last(), '.');
        string srcExtension = "." + srcFilePath.Split('.').Last();

        string dstIdentifier = "_";
        switch (exType)
        {
            case ExportType.Date:
                dstIdentifier += DateTime.Now.ToString("yyyyMMdd HHmmss");
                break;

            case ExportType.SerialNumber:
                dstIdentifier += GetMaxSerialNumer(srcFolderPath, srcFileName) ;
                break;
        }

        return srcFolderPath + "\\" + srcFileName + dstIdentifier + srcExtension;
    }

    static private string GetMaxSerialNumer(string srcFolderPath, string srcFileName)
    {
        int max_n = 0;
        foreach (string dstFileFullName in Directory.GetFiles(srcFolderPath, srcFileName + "*", SearchOption.TopDirectoryOnly))
        {
            string dstFileName = SplitWithoutLast(dstFileFullName, '.');
            if (Int32.TryParse(dstFileName.Split('_').Last(), out int n))
            {
                max_n = Math.Max(max_n, n);
            }
        }
        max_n++;
        return max_n.ToString();
    }

    static private string SplitWithoutLast(string source, params char[] separator)
    {
        string[] List = source.Split(separator);

        if (List.Length == 0)
        {
            return source;
        }
        return List.Take(List.Count() - 1).Aggregate((a, b) => a + string.Join("", separator) + b);
    }
}