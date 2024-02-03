using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drager : MonoBehaviour
{
    public RectTransform startPoint;
    public RectTransform endPoint;
    public RectTransform startPoint_m;
    public RectTransform endPoint_m;
    public RectTransform goalPoint;
    public RectTransform movingBar;
    public TextMeshProUGUI noticerMessage;
    public Transform noticerMessageStartPoint;
    public ParticleSystem particleHajebUp;
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

    private void NoticeMessage(float pourcentage)
    {
        string[] str = { "Good !!", "Great !!", "Nice !", "Awesome !!" };
        GameObject obj = Instantiate(noticerMessage.gameObject, noticerMessageStartPoint.transform.position, Quaternion.identity,noticerMessageStartPoint);
        obj.GetComponent<TextMeshProUGUI>().text = str[(int)UnityEngine.Random.Range((int)0, (int)str.Length)];
        Destroy(obj,2f);
    }
    private void OnMouseDown()
    {
        //percentage : p = 1/distance*(transform.position.x * 100)
        canMove = true;
    }
    private void OnMouseUp()
    {
        SoundManager.Instance.MouseUp();
        SoundManager.Instance.MouseDrag(1/5, 4.3f, false);
        //isMoving = false;
        canMove = false;

        float _distance = Mathf.Abs(movingBar.transform.localPosition.x - goalPoint.localPosition.x);
        float p = (_distance * 100) / distance;

        switch (p)
        {
            case < 10:

                NoticeMessage(p);

                for (int i = 0; i < hajebZghabList.Count; i++)
                {
                    NoticeMessage(p);
                    ParticleSystem part =Instantiate(particleHajebUp, hajebZghabList[i].localPosition, Quaternion.identity);
                    part.Play();
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 20:
                NoticeMessage(p);

                for (int i = 0; i < hajebZghabList.Count-2; i++)
                {
                    NoticeMessage(p);
                    ParticleSystem part = Instantiate(particleHajebUp, hajebZghabList[i].localPosition, Quaternion.identity);
                    part.Play();
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 30:
                NoticeMessage(p);

                for (int i = 0; i < hajebZghabList.Count-3; i++)
                {
                    NoticeMessage(p);
                    ParticleSystem part = Instantiate(particleHajebUp, hajebZghabList[i].localPosition, Quaternion.identity);
                    part.Play();
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 40:
                NoticeMessage(p);

                for (int i = 0; i < hajebZghabList.Count-4; i++)
                {
                    NoticeMessage(p);
                    ParticleSystem part = Instantiate(particleHajebUp, hajebZghabList[i].localPosition, Quaternion.identity);
                    part.Play();
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 50:
                NoticeMessage(p);

                for (int i = 0; i < hajebZghabList.Count-5; i++)
                {
                    NoticeMessage(p);
                    ParticleSystem part = Instantiate(particleHajebUp, hajebZghabList[i].localPosition, Quaternion.identity);
                    part.Play();
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 60:
                NoticeMessage(p);

                for (int i = 0; i < hajebZghabList.Count-6; i++)
                {
                    NoticeMessage(p);
                    ParticleSystem part = Instantiate(particleHajebUp, hajebZghabList[i].localPosition, Quaternion.identity);
                    part.Play();
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();
                    hajebZghabList.Remove(hajebZghabList[i]);

                }
                break;
            case < 70:
                NoticeMessage(p);

                for (int i = 0; i < hajebZghabList.Count-7; i++)
                {
                    NoticeMessage(p);
                    ParticleSystem part = Instantiate(particleHajebUp, hajebZghabList[i].localPosition, Quaternion.identity);
                    part.Play();
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 80:
                NoticeMessage(p);
                for (int i = 0; i < hajebZghabList.Count-8; i++)
                {
                    NoticeMessage(p);
                    ParticleSystem part = Instantiate(particleHajebUp, hajebZghabList[i].localPosition, Quaternion.identity);
                    part.Play();
                    hajebZghabList[i].gameObject.SetActive(false);
                    SoundManager.Instance.HajebUp();

                    hajebZghabList.Remove(hajebZghabList[i]);
                }
                break;
            case < 90: // TODO : drop it to 50%

                for (int i = 0; i < hajebZghabList.Count-9; i++)
                {
                    NoticeMessage(p);

                    ParticleSystem part = Instantiate(particleHajebUp, hajebZghabList[i].localPosition, Quaternion.identity);
                    part.Play();
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
                    SoundManager.Instance.HitNose();
                StartCoroutine(ResetSpite(1.5f, 3));
                break;
            case <= 7:
                face.sprite = faces[2];
                    SoundManager.Instance.HitNose();
                StartCoroutine(ResetSpite(1.5f, 2));
                break;
            case <= 9:
                face.sprite = faces[1];
                    SoundManager.Instance.HitNose();
                StartCoroutine(ResetSpite(1.5f, 1));
                break;
            case <= 10:
                face.sprite = faces[0];
                break;
            default:
                break;
        }

        //initialize transform
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
        SoundManager.Instance.MouseDrag(scaleDistance, 4.3f,true);

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
            goalPoint.localPosition = new Vector2((int)UnityEngine.Random.Range(startPoint_m.localPosition.x, endPoint_m.localPosition.x), goalPoint.localPosition.y);
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
