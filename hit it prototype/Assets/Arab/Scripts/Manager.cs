using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject winPanel;

    private void Start()
    {
        helpPanel?.SetActive(false);
        winPanel?.SetActive(false);
    }
    public void Help()
    {
        SoundManager.Instance.Interacte();
        helpPanel?.SetActive(true);
    }
    public void Close()
    {
        SoundManager.Instance.Interacte();
        helpPanel?.SetActive(false);
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
}
