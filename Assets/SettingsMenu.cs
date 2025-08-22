using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void SetVolume(float volume)
    {
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
