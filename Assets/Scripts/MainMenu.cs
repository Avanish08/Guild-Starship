using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("References")]
    public GameObject mainMenuPanel;     // Assign your MainMenu panel here
    public GameObject gameplayObjects;   // Assign your gameplay objects root here
    public GameObject controlerObjects;
    void Start()
    {
        // Show menu, hide gameplay at game start
        mainMenuPanel.SetActive(true);
        gameplayObjects.SetActive(false);
        controlerObjects.SetActive(false);
    }

    public void Play()
    {
        // Hide menu, start gameplay
        mainMenuPanel.SetActive(false);
        gameplayObjects.SetActive(true);
        controlerObjects.SetActive(true);
        // Optionally reset player position, scores, etc. here
    }

   

    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
