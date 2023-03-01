using System.IO;
using TMPro;
using UnityEngine;

public class LoadBestScore : MonoBehaviour
{
    // Start is called before the first frame update   
    public TextMeshProUGUI global_record_text;
    void Start()
    {
        if (Directory.Exists(Application.dataPath + "/GameData/") != true) Directory.CreateDirectory(Application.dataPath + "/GameData/");
        if (File.Exists(GameValues.record_file) != true)
        {
            Debug.Log("Файл найден!");
            SaveRecord.WriteValueRecordFile(0, GameValues.record_file);
        }
        Debug.Log("Файл найден!");
        GameValues.global_record = SaveRecord.GetRecordFromRecordFile(GameValues.record_file);
        global_record_text.text = $"GLOBAL RECORD\n\t\t\t\t\t    {GameValues.global_record}";
    }
}
