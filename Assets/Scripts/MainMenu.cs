using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject settingsWindow;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void SettingOpen()
    {
        settingsWindow.SetActive(true);
    }

    public void SettingClose()
    {
        settingsWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
