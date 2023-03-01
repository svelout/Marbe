using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class SaveRecord : MonoBehaviour
{
    // Start is called before the first frame update
    public static void WriteValueRecordFile(int record, string path)
    {
        File.WriteAllText(path, $"YOUR RECORD\n\n********\n{record}\n********");
    }
    public static int GetRecordFromRecordFile(string path)
    {
        var lines = File.ReadAllLines(path);
        return Convert.ToInt32(lines[3]);
    }
}
