using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Start = true;
    public static bool End = false;
    public static bool First_Start = true;
    public static bool restart = false;
    public static int global_record = 0;
    public static Vector3 default_cube_pos = new Vector3(0.33f, 0.609f, -7.2526f);
    public static string record_file = Application.dataPath + @"//GameData//GameRecord.txt";
}
