using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject mainMenuPanel;
    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        mainMenuPanel.SetActive(false);
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        mainMenuPanel.SetActive(true);
    }
     public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
