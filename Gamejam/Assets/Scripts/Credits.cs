using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Stop("WaterLevelBGM");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
