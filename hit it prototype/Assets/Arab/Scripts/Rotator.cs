using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 4f;
    public float rotateSpeed_min = 1.5f;
    public float rotateSpeed_max = 8f;
    private void Start()
    {
        StartCoroutine(Reverse());
        StartCoroutine(ChangeSpeed());
    }
    private void Update()
    {
        _Rotate();
    }
    public void _Rotate()
    {
        transform.Rotate(transform.forward, 25 * Time.deltaTime * rotateSpeed);
    }
    IEnumerator Reverse() { 
        while (true) {
            yield return new WaitForSecondsRealtime(Random.Range(5,15));
            rotateSpeed =- rotateSpeed;
        }
    }
    IEnumerator ChangeSpeed()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(3, 15));
            rotateSpeed = Random.Range(rotateSpeed_min * (Spawner.Round > 1 ? Spawner.Round / 2 : 1), rotateSpeed_max * (Spawner.Round>1? Spawner.Round/2 : 1));
        }
    }
}
