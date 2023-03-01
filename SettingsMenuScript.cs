using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource test_sound;
    public Toggle toogle;
    public void SettingButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        toogle.onValueChanged.AddListener(ChangeValue);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
    }

    public void TestButton()
    {
        if (!test_sound.isPlaying)
        {
            test_sound.Play();
        }
        else
        {
            test_sound.Stop();
        }
    }

    public void ChangeValue(bool val)
    {
        GameValues.GameMusic = val;
        if (val == true) {
            PlayerPrefs.SetInt("IsOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("IsOn", 0);
        }
    }
}
