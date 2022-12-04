using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSequence : MonoBehaviour
{
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scorePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            // End sequence
            GameObject.Find("Rain").GetComponent<RainScript>().StartEndSequence();
            AudioManager.instance.Stop("WaterLevelBGM");
            
            scorePanel.SetActive(true);
            scoreText.text = new string("Score: " + Inventory.instance.GetBlackOrbRate());
            
            other.gameObject.GetComponent<PlayerControl>().SetAtEnd();
        }
    }
}