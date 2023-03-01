using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toogle;
    public Slider slider;
    void Start()
    {
        if (GameValues.GameMusic != false)
        {
            toogle.isOn = true;
        }
        else
        {
            toogle.isOn = false;
        }
        slider.value = GameValues.volume;
    }
}
