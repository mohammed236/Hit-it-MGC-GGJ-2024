using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public GameObject particleImpact;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(-transform.up* bulletSpeed);
        Destroy(gameObject,6f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject p = Instantiate(particleImpact,collision.transform.position,Quaternion.identity);
        Destroy(p,.25f);

        var cam = FindObjectOfType<CameraShake>();
        cam.ShakeCamera();

        if (collision.gameObject.CompareTag("Virus"))
        {
            //damage enemy
            SoundManager.Instance.HitVirus();
            collision.gameObject.GetComponent<Health>().Damage(10);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Eye"))
        {
            //damage player
            SoundManager.Instance.HitEye();
            collision.gameObject.GetComponent<Health>().Damage(5);
            Destroy(gameObject);
        }
    }
}
