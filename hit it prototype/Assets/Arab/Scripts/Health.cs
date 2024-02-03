using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
        Time.timeScale = 1f;

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
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                GetComponent<Collider2D>().enabled = false;
                try
                {
                    GetComponentInChildren<EnemyShoot>()?.gameObject.SetActive(false);
                }
                catch (System.Exception)
                {
                    throw;
                }
                
            }
            if (this.tag == "Player")
            {
                t = 2.5f;
                if(Time.timeScale >.35f)
                    Time.timeScale -= .1f;

                anim.SetBool("isDie", true);
                GetComponent<Rigidbody2D>().isKinematic = true;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                //GetComponent<playerMovements>().enabled = false;
                StartCoroutine(WaitForDie());
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
    IEnumerator WaitForDie()
    {
        yield return new WaitForSecondsRealtime(3f);

        if (DiePanel != null)
            DiePanel?.SetActive(true);
        SoundManager.Instance.Interacte();
        Time.timeScale = 1f;

    }

    public void Damage(int damageAmount)
    {
        health-=damageAmount;
        if (health> maxHealth) health = maxHealth;

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
            if(tag == "Eye")
            {
                healthbarFill.GetComponent<Image>().fillAmount = (float)health / maxHealth;
            }
            else
            {
                healthbarFill.GetComponent<RectTransform>().localScale = new Vector3((float)health / maxHealth, 1, 1);
            }
        }
    }
}
