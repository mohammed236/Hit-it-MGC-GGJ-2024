using UnityEngine;

public class Consumable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //health
            collision.gameObject.GetComponent<Health>().Damage(-100);
            SoundManager.Instance.HealPlayer();
            Destroy(gameObject);
        }
    }
}
