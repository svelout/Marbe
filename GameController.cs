using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static int cubesPerAxis = 8;
    public static float delay = 1f;
    public static float force = 10f;
    public static float radius = 2f;
    public static List<GameObject> minicubes = new List<GameObject>();
    public Material material;
    public GameObject obj;
    public void Stop(GameObject obj, TextMeshProUGUI text, TextMeshProUGUI text2, TextMeshProUGUI text3, bool explote_cube = false)
    {
        this.obj = obj;
        material = obj.GetComponent<Renderer>().material;
        if (explote_cube != false)
        {
            ExploteCube();
        }
        obj.SetActive(false);       
        for (float i = text.fontMaterial.GetFloat(ShaderUtilities.ID_FaceDilate); i <= 0.14f; i += 0.001f)
        {
            text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, i * Time.deltaTime);
            text2.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, i * Time.deltaTime);
            text3.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, i * Time.deltaTime);
        } 
    }

    private void ExploteCube()
    {
        for (int x = 0; x < cubesPerAxis; x++)
        {
            for (int y = 0; y < cubesPerAxis; y++)
            {
                for (int z = 0; z < cubesPerAxis; z++)
                {
                    CreateMiniCube(obj.transform.position);
                }
            }
        }
        Destroy(obj);
    }

    private void CreateMiniCube(Vector3 pos)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = obj.transform.localScale / cubesPerAxis;
        Renderer rd = cube.GetComponent<Renderer>();
        rd.material = material;
        Vector3 firstcube = obj.transform.position - obj.transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstcube + Vector3.Scale(pos, cube.transform.localScale);
        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(force, obj.transform.position, radius);
        minicubes.Add(cube);
    }
}

