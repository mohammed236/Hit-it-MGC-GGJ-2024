using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int minHealth;

    public GameObject particle;

    private void Start()
    {
        if (particle != null)
            particle.SetActive(false);
        if (this.tag == "Eye")
        {
            health = 100;
        }
        else if (this.tag == "Virus")
        {
            health = Random.Range(minHealth, maxHealth);
        }
    }

    private void Update()
    {
        if(health <= 0)
        {
            if (particle!=null)
                particle.SetActive(true);
            if (this.tag == "Virus")
            {
                Spawner.vuris.Remove(this.gameObject);
            }
            Destroy(gameObject,.25f);
            print(" this "+ name +" die");
        }
    }

    public void Damage(int damageAmount)
    {
        health-=damageAmount;
    }
}
