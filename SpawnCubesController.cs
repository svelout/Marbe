using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using TMPro;

#nullable disable
public class SpawnCubes : MonoBehaviour
{
    // Start is called before the first frame update
    float platform_x = -4.723f;
    float _platform_x = 4.253f;
    float platform_z = -10.651f;
    float add_record_pos = -8.432f;
    float add_value = 1f;
    public float speed = 1f;
    public GameObject ScriptCube;
    public GameObject Platform;
    bool isgenerated;
    public Vector3 objects_pos;
    private List<GameObject> objects = new List<GameObject>();
    public Camera cam;
    bool IsEnd;
    public Timer timer;
    public bool StartGame = false;
    public bool TimerStarted;
    public int current_sec;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI RecordText;
    public TextMeshProUGUI NewRecordText;
    public int record = 0;
    public int global_record;
    public bool IsRecordAdd;
    public bool record_write;
    public AudioSource gm;
    // 7.13
    // 21.53

    void Start()
    {
        record_write = false;
        IsRecordAdd = false;
        current_sec = 3;
        global_record = 0;
        isgenerated = false;
        IsEnd = false;
        cam = Camera.current;
        TimerStarted = false;
        GameValues.Start = false;
        timer = new Timer();
        timer.Enabled = true;
        timer.Interval = 1000;
        timer.AutoReset = true;
        timer.Elapsed += new ElapsedEventHandler(OnTimerTick);
    }

    // add value = 0,996;
    // boolrelease(data)
    /*
     * if (StartGame != false && TimerStarted != true)
        {
            Timer.text = current_sec.ToString();
        }
     */
    void Update()
    {
        if (GameValues.End == true && record_write == false)
        {
            if (global_record > GameValues.global_record)
            {
                GameValues.global_record = global_record;
                SaveRecord.WriteValueRecordFile(GameValues.global_record, GameValues.record_file);
                NewRecordText.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -0.16f);
                record_write = true;
            }
        }
        if (GameValues.restart == true)
        {
            foreach (GameObject obj in objects)
            {
                Destroy(obj.gameObject);
            }
            objects.Clear();
            foreach (GameObject obj in GameController.minicubes)
            {
                Destroy(obj.gameObject);
            }
            GameController.minicubes.Clear();
            GameValues.End = false;
            GameValues.restart = false;
        }
        if (current_sec != 0)
        {
            Timer.text = current_sec.ToString();
        }        
        if (GameValues.End != true && GameValues.Start != false)
        {
            if (Timer.fontMaterial.GetFloat(ShaderUtilities.ID_FaceDilate) != -1f)
            {
                Timer.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
            }
            if (RecordText.fontMaterial.GetFloat(ShaderUtilities.ID_FaceDilate) == -1f)
            {
                RecordText.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -0.2f);
            }
            if (NewRecordText.fontMaterial.GetFloat(ShaderUtilities.ID_FaceDilate) != -1f)
            {
                NewRecordText.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
            }
            if (GameValues.GameMusic != false && gm.isPlaying != true)
            {
                gm.Play();
            }
            timer.Enabled = false;
            var r = Random.Range(1, 10);
            int count = 1;
            if (isgenerated != true)
            {
                for (float x = _platform_x; x >= platform_x; x -= add_value)
                {
                    if (count == r) count++;
                    else
                    {
                        var obj = Instantiate(ScriptCube, new Vector3(x, transform.position.y + (1f - 0.4f), Platform.transform.position.z + (21.53f - 7.13f)), Quaternion.identity);
                        objects.Add(obj);
                        count++;
                    }
                }
                isgenerated = true;
            }
            foreach (GameObject obj in objects)
            {
                if (GameValues.End == true) break;
                if (obj.transform.position.z >= platform_z)
                {
                    objects_pos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
                    objects_pos.z -= add_value * (Time.deltaTime * speed);
                    obj.transform.position = objects_pos;
                }
                if (obj.transform.position.z <= add_record_pos && IsRecordAdd != true)
                {                   
                    record++;
                    global_record = record;
                    RecordText.text = $"Score: {record}";
                    IsRecordAdd = true;
                }
                if (obj.transform.position.z <= platform_z)
                {
                    IsEnd = true;
                    break;
                }
            }   
            if (IsEnd == true)
            {                
                isgenerated = false;
                foreach (GameObject obj in objects)
                {
                    Destroy(obj.gameObject);
                }
                objects.Clear();
                isgenerated = false;
                IsEnd = false;
                IsRecordAdd = false;
            }
        }        
    }
    private void OnTimerTick(object sender, ElapsedEventArgs e)
    {
        if (current_sec == 1)
        {
            GameValues.Start = true;
            timer.Stop();
            timer.Enabled = false;
        }
        else
        {
            current_sec--;           
        }
    }
}
