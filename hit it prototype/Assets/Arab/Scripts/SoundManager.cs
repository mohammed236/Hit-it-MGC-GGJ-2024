using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { private set; get; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public AudioSource audioSource;
    public AudioClip[] clips;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (SceneManager.GetActiveScene().buildIndex==0 || SceneManager.GetActiveScene().buildIndex == 1))
        {
            Pointer();
        }
    }
    public void Interacte()
    {
        audioSource.PlayOneShot(clips[0]);
    }
    public void Pointer()
    {
        audioSource.PlayOneShot(clips[1]);
    }
    public void MouseDrag(float drag)
    {
        audioSource.PlayOneShot(clips[2]);
    }
    public void MouseUp()
    {
        audioSource.PlayOneShot(clips[3]);
    }
    public void HajebUp()
    {
        audioSource.PlayOneShot(clips[4]);
    }
    public void Shoot()
    {
        audioSource.PlayOneShot(clips[5]);
    }
    public void HitVirus()
    {
        audioSource.PlayOneShot(clips[6]);
    }
    public void HitEye()
    {
        audioSource.PlayOneShot(clips[7]);
    }
}
