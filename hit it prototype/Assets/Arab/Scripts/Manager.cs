using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject winPanel;
    public GameObject settingsPanel;
    public Slider slider_M;
    public Slider slider_S;

    private void Start()
    {
        helpPanel?.SetActive(false);
        winPanel?.SetActive(false);

        if(settingsPanel!=null)
            settingsPanel?.SetActive(false);

        Time.timeScale = 1;
        if(slider_M != null )
            slider_M.value = SoundManager.GetMusicValue();
        if (slider_S != null)
            slider_S.value = SoundManager.GetSoundValue();
    }
    public void Revive()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=sTjzbp1__iE");
        Application.OpenURL("https://www.youtube.com/watch?v=sTjzbp1__iE");
        Application.OpenURL("https://www.youtube.com/watch?v=sTjzbp1__iE");
        Application.OpenURL("https://www.youtube.com/watch?v=sTjzbp1__iE");
        Application.OpenURL("https://www.youtube.com/watch?v=sTjzbp1__iE");
    }
    public void SliderM()
    {
        SoundManager.Instance.SetMusicVolume(slider_M);
    }
    public void SliderS()
    {
        SoundManager.Instance.SetSoundVolume(slider_S);
    }
    public void Help()
    {
        SoundManager.Instance.Interacte();
        helpPanel?.SetActive(true);
        Time.timeScale = 0;
    }
    public void Close()
    {
        SoundManager.Instance.Interacte();
        helpPanel?.SetActive(false);
        Time.timeScale = 1;
    }
    public void Next()
    {
        SoundManager.Instance.Interacte();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Return()
    {
        SoundManager.Instance.Interacte();
        SceneManager.LoadSceneAsync(0);
    }
    public void Quit()
    {
        SoundManager.Instance.Interacte();
        Application.Quit();
    }
    public void closeSettings()
    {
        settingsPanel?.SetActive(false);
    }
    public void Settings()
    {
        settingsPanel?.SetActive(true);
    }
}
