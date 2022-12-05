using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonGameScript : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        GameObject.Find("SceneChangerGameScene").GetComponent<SceneChange>().FadeToLevel(sceneIndex);
    }
}
