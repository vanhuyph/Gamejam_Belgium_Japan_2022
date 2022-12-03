using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{   
    [SerializeField] private bool orbDoor = false;
    
    Collider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.transform.position.x < this.transform.position.x)
            {
                Debug.Log("Passed " + Inventory.instance.GetBlackOrbRate());
                if (orbDoor)
                {
                    if (Inventory.instance.GetBlackOrbRate() < 0.5f)
                    {
                        this.transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
                else
                {
                    this.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            else
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
