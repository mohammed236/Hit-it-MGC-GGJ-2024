using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDrpper : MonoBehaviour
{
    public GameObject bullet;
    public Transform startPoint;
    public Sprite press;
    public Sprite hold;
    SpriteRenderer rendrer;
    CameraShake cam;
    private void Start()
    {
        cam = FindObjectOfType<CameraShake>();
        rendrer = GetComponent<SpriteRenderer>();
        rendrer.sprite = hold;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //drrop cool
            DropCool();
            rendrer.sprite = press;
            StartCoroutine(Wait());

        }
    }
    public void DropCool()
    {
        SoundManager.Instance.Shoot();
        Instantiate(bullet,startPoint.position,Quaternion.identity);
        cam.ShakeCamera();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(.2f);
        rendrer.sprite = hold;

    }
}
