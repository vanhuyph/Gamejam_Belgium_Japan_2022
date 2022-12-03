using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("OrbCollect");
            Inventory.instance.AddOrbPoints(1, gameObject.tag);
            PlayerKarma playerKarma = collision.transform.GetComponent<PlayerKarma>();
            playerKarma.TakeKarma(1, gameObject.tag);
            Destroy(gameObject);
        }
    }
}
