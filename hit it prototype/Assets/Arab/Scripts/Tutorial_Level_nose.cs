using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Level_nose : MonoBehaviour
{
    public GameObject tutoBarObj;

    int refrence = 0;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("refrence")) {
            refrence = PlayerPrefs.GetInt("refrence");
            if(refrence == 1) { gameObject.SetActive(false); }
        }
        else
        {
            refrence = 0;
            PlayerPrefs.SetInt("refrence", 1);
            PlayerPrefs.Save();
        }

        tutoBarObj.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (refrence == 0) {
            //desactivate this
            Image i = gameObject.GetComponent<Image>();
            i.color = new Vector4(0, 0, 0, 0);
            i.transform.position = new Vector3(100000000, 1, 10);
            //gameObject.SetActive(false);
            //activate tutobar
            tutoBarObj.SetActive(true);
            StartCoroutine(StartTutoBar());
        }
        else
        {
            gameObject.SetActive(false);
            tutoBarObj.SetActive(false);
        }

    }
    IEnumerator StartTutoBar()
    {
        yield return new WaitForSecondsRealtime(5.5f);
        tutoBarObj.SetActive(false);
    }
}
