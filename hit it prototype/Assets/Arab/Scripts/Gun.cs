using UnityEngine;
public class Gun : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public float shootingDistance;
    public Transform startPoint;
    public Transform playerManager;
    public GameObject muzzelFlash;
    public GameObject muzzelFlash_Hit;
    public LayerMask layerMask;
    public float hitForce = 2f;
    RaycastHit2D results;
    CameraShake cam;


    private void Start()
    {
        cam= FindObjectOfType<CameraShake>();
    }
    private void Update()
    {
        RotateGun();
        Shoot();
        
    }
    private void Shoot()
    {

        results = Physics2D.Raycast(startPoint.position, transform.right * playerManager.localScale.x, shootingDistance, layerMask);
        Debug.DrawRay(startPoint.position, transform.right * playerManager.localScale.x, Color.red, .1f);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            cam.ShakeCamera();
            SoundManager.Instance.ShootHero();
            if (results.collider != null) {
                results.transform.GetComponent<Rigidbody2D>().AddForce(results.transform.right * hitForce, ForceMode2D.Impulse);
                results.transform.GetComponent<Health>().Damage(10);
                
                GameObject mh = Instantiate(muzzelFlash_Hit, results.point, Quaternion.identity);
                Destroy(mh, .2f);
            }
            GameObject m =Instantiate(muzzelFlash, startPoint.position, Quaternion.identity);
            Destroy(m,.2f);

        }
        
    }
    private void RotateGun()
    {

        Vector2 direction = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y * playerManager.localScale.x, direction.x * playerManager.localScale.x) * Mathf.Rad2Deg;
        float clampedAngle = Mathf.Clamp(angle, -80f, 80f);
        transform.eulerAngles = new Vector3(0,0, clampedAngle);
    }
}