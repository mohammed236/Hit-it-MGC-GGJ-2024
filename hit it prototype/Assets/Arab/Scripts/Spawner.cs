using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject vurisPref;
    public List<Transform> points = new List<Transform>();
    public static List<GameObject> vuris = new List<GameObject>();
    public TextMeshProUGUI roundText;
    public static int Round = 1;

    private void Start()
    {
        Round = 1;
        roundText.text = $" ROUND : {Round}";
        //Instantiate virus
        SpawnVuris();
    }
    public void Update()
    {
        if (vuris.Count<=0)
        {
            //Instantiate virus
            SpawnVuris();
            Round += 1;
            roundText.text = $" ROUND : {Round}";
        }
    }
    void SpawnVuris()
    {
        for (int i = 0; i < points.Count; i++)
        {
            var g = Instantiate(vurisPref, points[i].position, Quaternion.identity,transform);
            vuris.Add(g);
        }
    }
}
