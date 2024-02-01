using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int minHealth;

    public GameObject particle;
    public Animator anim;
    public GameObject DiePanel;
    public GameObject healthbarFill;

    public Sprite[] EyeSprites = new Sprite[3];
    public GameObject sp;

    private void Start()
    {
        if (particle != null)
            particle?.SetActive(false);
        if (this.tag == "Eye")
        {
            health = 100;
        }
        else if (this.tag == "Virus")
        {
            maxHealth = Random.Range(minHealth, maxHealth);
        }
        if (healthbarFill != null)
        {
            healthbarFill.transform.localScale = new Vector2(1, 1);
        }
            if (DiePanel != null)
                DiePanel?.SetActive(false);
    }

    private void Update()
    {

        if(health <= 0)
        {
            float t = .25f;
            if (particle!=null)
                particle?.SetActive(true);
            if (this.tag == "Virus")
            {
                Spawner.vuris.Remove(this.gameObject);
            }
            if(this.tag == "Enemy")
            {
                t = 1.5f;
                anim.SetBool("isDie", true);
                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<Collider2D>().enabled = false;
                
            }
            if (this.tag == "Player")
            {
                t = 1.5f;
                anim.SetBool("isDie", true);
                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<Collider2D>().enabled = false;
                if(DiePanel!=null)
                    DiePanel?.SetActive(true);
                SoundManager.Instance.Interacte();

            }
            if (this.tag == "Eye")
            {
                if (DiePanel != null)
                    DiePanel?.SetActive(true);
                SoundManager.Instance.Interacte();
            }
            Destroy(gameObject, t);
        }
        
    }

    public void Damage(int damageAmount)
    {
        health-=damageAmount;
        if (this.tag == "Eye")
        {
            if (sp != null)
            {
                if (health > 90 && health < 100)
                {
                    sp.GetComponent<SpriteRenderer>().sprite = EyeSprites[0];
                }
                else if (health > 70)
                {
                    sp.GetComponent<SpriteRenderer>().sprite = EyeSprites[1];

                }
                else if (health >50)
                {
                    sp.GetComponent<SpriteRenderer>().sprite = EyeSprites[2];

                }
                else if (health > 30)
                {
                    sp.GetComponent<SpriteRenderer>().sprite = EyeSprites[3];

                }
                else if (health > 10)
                {
                    sp.GetComponent<SpriteRenderer>().sprite = EyeSprites[4];

                }
            }
            
        }
        if (healthbarFill != null && health>=0)
        {
            healthbarFill.GetComponent<RectTransform>().localScale = new Vector3((float)health / 100, 1, 1);
            print((float)health / 100);
        }
    }
}
