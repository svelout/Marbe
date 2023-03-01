using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeTransform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float LeftEnd = -3.74f;
    public float RightEnd = 4.296f;
    public KeyCode A;
    public KeyCode D;
    public Vector3 targetPosition;
    public Rigidbody rb;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public bool lose_animate_end;
    public AudioSource LoseSound;
    public AudioSource gm;

    void Start()
    {
        targetPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        lose_animate_end = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameValues.End = true;
    }

    void Update()
    {
        if (GameValues.restart == true)
        {
            transform.position = GameValues.default_cube_pos;
            lose_animate_end=false;
            text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
            text2.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
            text3.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
            GameValues.End = false;
        }
        if (lose_animate_end != true)
        {
            if (GameValues.End != true)
            {
                if (Input.GetKey(A))
                {
                    if (transform.position.x >= LeftEnd)
                    {
                        targetPosition.x -= 0.1f * (Time.deltaTime * speed);
                        transform.localPosition = targetPosition;
                    }
                    else
                    {
                        transform.position = transform.position;
                    }
                }
                if (Input.GetKey(D))
                {
                    if (transform.position.x <= RightEnd)
                    {
                        targetPosition.x += 0.1f * (Time.deltaTime * speed);
                        transform.localPosition = targetPosition;
                    }
                    else
                    {
                        transform.position = transform.position;
                    }
                }
            }
            else
            {
                var gc = new GameController();
                if (gm.isPlaying != false)
                {
                    gm.Stop();
                }
                gc.Stop(gameObject, text, text2, text3, true);
                LoseSound.Play();
                lose_animate_end = true;
            }
        }
    }
}
