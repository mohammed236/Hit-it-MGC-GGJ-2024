using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { private set; get; }
    bool canPlay = true;
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
    private const string MUSIC_SAVED_VALUE = "M";
    private const string SOUND_SAVED_VALUE = "S";

    public AudioSource audioSource;
    public AudioClip[] clips;
    public AudioMixer audioMixer_S;
    public AudioMixer audioMixer_M;
    public float scaleFactor = .5f;
    private void Start()
    {
        Application.targetFrameRate = 60;
        audioSource.pitch = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (SceneManager.GetActiveScene().buildIndex==0 || SceneManager.GetActiveScene().buildIndex == 1))
        {
            Pointer();
        }
    }
    public void Interacte()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[0]);
    }
    public void Pointer()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[1]);
    }
    public void MouseDrag(float drag,float maxDrag,bool canPlay)
    {
        if (!canPlay)
        {
            audioSource.Stop();
            return;
        }
        if (!audioSource.isPlaying)
        {
            audioSource.pitch = (drag / maxDrag) * scaleFactor;
            audioSource.PlayOneShot(clips[2],.6f);
        }
    }
    public void MouseUp()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[3]);
    }
    public void HajebUp()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[4],.5f);
    }
    public void HitNose()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[9]);
    }
    public void Shoot()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[5],.01f);
    }
    public void ShootHero()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[11], .1f);
    }
    public void HitVirus()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[6]);
    }
    public void HitEye()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[7]);
    }
    public void ShootEye()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[10]);
    }
    public void HealPlayer()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clips[12],.7f);
    }
    public void Step()
    {
        audioSource.pitch = 1;
        float clipDuration = clips[8].length;
        if (canPlay)
        {
            audioSource.PlayOneShot(clips[8]);
            StartCoroutine(Wait(clipDuration));
            canPlay = false;
        }
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        canPlay = true;

    }

    public void SetMusicVolume(UnityEngine.UI.Slider slider)
    {
        float volume = slider.value;

        audioMixer_M.SetFloat("Music", Mathf.Log10(volume) * 20);
        SaveMusicPrefs(volume);
    }
    public void SetSoundVolume(UnityEngine.UI.Slider slider)
    {
        float volume = slider.value;

        audioMixer_S.SetFloat("Sound", Mathf.Log10(volume) * 20);
        SaveSoundPrefs(volume);
    }
    public static float GetMusicValue()
    {
        return PlayerPrefs.HasKey(MUSIC_SAVED_VALUE) ? PlayerPrefs.GetFloat(MUSIC_SAVED_VALUE) : .35f;
    }
    public static float GetSoundValue()
    {
        return PlayerPrefs.HasKey(SOUND_SAVED_VALUE) ? PlayerPrefs.GetFloat(SOUND_SAVED_VALUE) : .35f;
    }
    public static void SaveMusicPrefs(float volume)
    {
        PlayerPrefs.SetFloat(MUSIC_SAVED_VALUE, volume);
        PlayerPrefs.Save();
    }
    public static void SaveSoundPrefs(float volume)
    {
        PlayerPrefs.SetFloat(SOUND_SAVED_VALUE, volume);
        PlayerPrefs.Save();
    }
}
