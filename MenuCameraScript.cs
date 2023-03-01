using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform _rotator;
    void Start()
    {
        //степа топ
        _rotator = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rotator.Rotate(0, 0, (Time.deltaTime * speed));
    }
}
