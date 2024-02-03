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

    public Texture2D defaultCursor;
    public Texture2D hoverCursor;

    private void Start()
    {
        cam = FindObjectOfType<CameraShake>();
        rendrer = GetComponent<SpriteRenderer>();
        rendrer.sprite = hold;

        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //drrop cool
            DropCool();
            rendrer.sprite = press;
            StartCoroutine(Wait());
            Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
    public void DropCool()
    {
        SoundManager.Instance.ShootEye();
        Instantiate(bullet,startPoint.position,Quaternion.identity);
        cam.ShakeCamera();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(.2f);
        rendrer.sprite = hold;

    }
}
