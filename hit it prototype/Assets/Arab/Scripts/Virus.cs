using UnityEngine;

public class Virus : MonoBehaviour
{
    public float rotateSpeed = 4f;
    private void Update()
    {
        Rotate();
    }
    public void Rotate()
    {
        transform.Rotate(transform.forward, 25 * Time.deltaTime * rotateSpeed);
    }
}
