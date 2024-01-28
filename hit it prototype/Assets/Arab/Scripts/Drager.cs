using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drager : MonoBehaviour
{
    public RectTransform startPoint;
    public RectTransform endPoint;
    public RectTransform goalPoint;
    public RectTransform movingBar;
    public List<RectTransform> hajebZghabList = new List<RectTransform>();
    public float speed = 5f;
    public Image face;
    public Sprite[] faces = new Sprite[3];
    Vector2 zaghbaInitialposition;
    quaternion zaghbaInitialrotation;
    Vector2 zaghbaInitialscale;

    bool canMove;
    float distance;

    void Start()
    {
        face.sprite = faces[0];

        zaghbaInitialposition = GetComponent<RectTransform>().localPosition;
        zaghbaInitialrotation = GetComponent<RectTransform>().localRotation;
        zaghbaInitialscale = GetComponent<RectTransform>().localScale;

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);

        StartCoroutine(ChangeGoalPosition());
    }
    private void Update()
    {
        if (canMove)
        {
            MoveObject();
        }
        //win condition
        if (hajebZghabList.Count<=0)
        {
            FindObjectOfType<Manager>().winPanel.SetActive(true);
        }
        
    }

    public void OnDragDelegate(PointerEventData data)
    {
        LookAtMouse();
    }
    private void OnMouseDown()
    {
        //percentage : p = 1/distance*(transform.position.x * 100)
        canMove = true;
    }
    private void OnMouseUp()
    {
        SoundManager.Instance.MouseUp();
        //isMoving = false;
        canMove = false;

        float _distance = Mathf.Abs(movingBar.transform.localPosition.x - goalPoint.localPosition.x);
        float p = (_distance * 100) / distance;

        switch (p)
        {
            case < 1:
                print(" You're From the Target by: " + p);
                for (int i = 0; i< hajebZghabList.Count; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);

                    SoundManager.Instance.HajebUp();
  
                    hajebZghabList.Remove(hajebZghabList[i]);
                    
                }    
                break;
            case < 5:
                print(" You're From the Target by: " + p);

                for (int i = 0; i < hajebZghabList.Count-1; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 10:
                print(" You're From the Target by: " + p);
                
                for (int i = 0; i < hajebZghabList.Count-2; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 15:
                print(" You're From the Target by: " + p);

                for (int i = 0; i < hajebZghabList.Count-3; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 20:
                print(" You're From the Target by: " + p);

                for (int i = 0; i < hajebZghabList.Count-4; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 25:
                print(" You're From the Target by: " + p);

                for (int i = 0; i < hajebZghabList.Count-5; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 30:
                print(" You're From the Target by: " + p);

                for (int i = 0; i < hajebZghabList.Count-6; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();
                    hajebZghabList.Remove(hajebZghabList[i]);

                }
                break;
            case < 35:
                print(" You're From the Target by: " + p);

                for (int i = 0; i < hajebZghabList.Count-7; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 40:
                print(" You're From the Target by: " + p);
                for (int i = 0; i < hajebZghabList.Count-8; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 100:
                print(" You're From the Target by: " + p);

                for (int i = 0; i < hajebZghabList.Count-9; i++)
                {
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            default:
                break;
        }
        switch (hajebZghabList.Count)
        {
            case <= 3:
                face.sprite = faces[3];
                StartCoroutine(ResetSpite(1.5f, 3));
                break;
            case <= 7:
                face.sprite = faces[2];
                StartCoroutine(ResetSpite(1.5f, 2));
                break;
            case <= 9:
                face.sprite = faces[1];
                StartCoroutine(ResetSpite(1.5f, 1));
                break;
            case <= 10:
                face.sprite = faces[0];
                break;
            default:
                break;
        }

        //initialize transform
        print("initialize");
        transform.localPosition = zaghbaInitialposition;
        transform.localScale = zaghbaInitialscale;
        transform.localRotation = zaghbaInitialrotation;


    }
    private void LookAtMouse()
    {
        Vector2 direction = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.localPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);


        ScaleTowardsMouse(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.localPosition));
    }
    private void ScaleTowardsMouse(float scaleDistance)
    {
        SoundManager.Instance.MouseDrag(scaleDistance);

        if (scaleDistance < .65f) return;
        transform.localScale = new Vector3(scaleDistance, 1,1);
    }
    void MoveObject()
    {
        float step = speed * Time.deltaTime;
        movingBar.transform.localPosition = Vector3.MoveTowards(movingBar.transform.localPosition, endPoint.localPosition, step);

        if (movingBar.transform.position == endPoint.position || Vector2.Distance(movingBar.transform.localPosition, endPoint.localPosition) <= 0)
        {
            // Swap start and end points to move back and forth
            Vector3 temp = startPoint.localPosition;
            startPoint.localPosition = endPoint.localPosition;
            endPoint.localPosition = temp;
        }
    }
    IEnumerator ChangeGoalPosition()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(2.5f,5f)); 
            goalPoint.localPosition = new Vector2((int)UnityEngine.Random.Range(startPoint.localPosition.x, endPoint.localPosition.x), goalPoint.localPosition.y);
            //initialize the distance between the goal & the moving bar
            distance = Mathf.Abs(movingBar.transform.localPosition.x - goalPoint.localPosition.x);
        }
    }
    IEnumerator ResetSpite(float time,int index)
    {
        yield return new WaitForSecondsRealtime(time);
        face.sprite = faces[index-1];
    }
}
