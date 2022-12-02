using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddOrbPoints(1, gameObject.tag);
            Destroy(gameObject);
        }
    }
}
