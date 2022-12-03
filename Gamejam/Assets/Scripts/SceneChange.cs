using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private Animator animator;
    private int sceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeToLevel(int sceneIndex)
    {
        sceneToLoad = sceneIndex;
        animator.SetTrigger("FadeOut");
    }
    
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
