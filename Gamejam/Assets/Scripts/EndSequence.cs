using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using TMPro;

public class EndSequence : MonoBehaviour
{
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private bool isEndSequence = false;
    private float timer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        scorePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndSequence)
        {
            timer += Time.deltaTime;
            
            if (timer >= 2.5f)
            {
                GameObject.Find("Rain").GetComponent<RainScript>().StartEndSequence();
            }
            
            if (timer > 6.5f)
            {
                scorePanel.SetActive(true);
                
                var score = 100.0f - Inventory.instance.GetTotalOrbCount();
                scoreText.text = new string("Score: " + score);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player" && !isEndSequence)
        {
            // End sequence
            AudioManager.instance.Stop("WaterLevelBGM");
            
            other.gameObject.GetComponent<PlayerControl>().SetAtEnd();
            
            isEndSequence = true;
            StartCoroutine(loadCreditsScene());
        }
    }

    public IEnumerator loadCreditsScene()
    {
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("CreditsScene");
    }
}