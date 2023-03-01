using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform _rotator;
    public AudioSource menu_music;
    void Start()
    {
        //степа топ
        _rotator = GetComponent<Transform>();
        menu_music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _rotator.Rotate(0, 0, (Time.deltaTime * speed));
    }
}
