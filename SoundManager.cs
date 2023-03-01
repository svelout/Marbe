using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volume;
    public TextMeshProUGUI cur;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else Load();
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
        cur.text = $"{Mathf.FloorToInt(AudioListener.volume * 100)}%";
        Save();
    }

    private void Load()
    {
        volume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volume.value);
    }
}
