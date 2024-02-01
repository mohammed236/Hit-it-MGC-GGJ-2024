using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public float shootingDistance;
    public Transform startPoint;
    public Transform EnemyManager;
    public GameObject muzzelFlash;
    public GameObject muzzelFlash_Hit;
    public LayerMask layerMask;
    RaycastHit2D results;
    public float hitForce = 2f;
    public float radus = 6;
    Transform player;
    public float shootTimer = .9f;
    bool shoot = true;
    private void Start()
    {
        player = FindObjectOfType<playerMovements>().transform;

    }
    private void Update()
    {
        RotateGun();
        if (Physics2D.OverlapCircle(transform.position, radus, layerMask))
        {
            print("entered");
            Shoot();

        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(shootTimer);
        shoot = true;
    }
    private void Shoot()
    {
        results = Physics2D.Raycast(startPoint.position, transform.right * (transform.parent.localScale.x/.4f), shootingDistance, layerMask);
        Debug.DrawRay(startPoint.position, transform.right * (transform.parent.localScale.x / .4f), Color.red, .1f);
        if (!shoot) return;
        SoundManager.Instance.Shoot();
        if (results.collider != null)
        {
            results.transform.GetComponent<Rigidbody2D>().AddForce(results.transform.right * hitForce, ForceMode2D.Impulse);
            results.transform.GetComponent<Health>().Damage(10);

            GameObject mh = Instantiate(muzzelFlash_Hit, results.point, Quaternion.identity);
            Destroy(mh, .2f);
        }
        GameObject m = Instantiate(muzzelFlash, startPoint.position, Quaternion.identity);
        Destroy(m, .2f);
        shoot = false;
        StartCoroutine(Wait());

    }
    private void RotateGun()
    {
        /*Vector3 VectorResult;
        float DotResult = Vector3.Dot(transform.right, player.right);
        if (DotResult > 0)
        {
            VectorResult = transform.right + player.right;
        }
        else
        {
            VectorResult = transform.right - player.right;
        }
        Debug.DrawRay(transform.position, VectorResult * 100, Color.green);
        Vector2 direction = (Vector2)(player.localPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float clampedAngle = Mathf.Clamp(angle, -80f, 80f);
        transform.eulerAngles = new Vector3(0, 0, clampedAngle);
        float _angle = Mathf.Atan2(direction.y * EnemyManager.localScale.x, direction.x * EnemyManager.localScale.x) * Mathf.Rad2Deg;
        transform.parent.eulerAngles = new Vector3(0, _angle, 0);

        if (AngleDir(Vector3.right, player.position, Vector3.up)<1)
        {
            //left
            EnemyManager.localScale = new Vector3(-1, 1, 1);
        }
        else if (AngleDir(Vector3.right, player.position, Vector3.up) > 1)
        {
            //he is on the right
            EnemyManager.localScale = new Vector3(1,1,1);
        }*/
    }
    //returns -1 when to the left, 1 to the right, and 0 for forward/backward
    public float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0.0f)
        {
            return 1.0f;
        }
        else if (dir < 0.0f)
        {
            return -1.0f;
        }
        else
        {
            return 0.0f;
        }
    }
}
