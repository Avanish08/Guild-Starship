using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    public static DeathUI instance;

    [Header("UI Panels")]
    public GameObject deathPanel;       // Game Over UI
    public GameObject mainMenuCanvas;   // Main Menu UI
    public GameObject gameplayUI;       // Gameplay HUD (score, fire UI)

    [Header("Player Controls")]
    public GameObject controlerObjects; // Buttons / Joystick panel

    void Awake()
    {
        instance = this;
    }

    // ------------------ SHOW DEATH PANEL ------------------
    public void ShowDeathPanel()
    {
        Time.timeScale = 0f; // Pause game

        deathPanel.SetActive(true);
        controlerObjects.SetActive(false);
        gameplayUI.SetActive(false);
    }

    // ------------------ RETRY (RESTART GAME) ------------------
    public void Retry()
    {
        Time.timeScale = 1f;

        // Hide death panel
        if (deathPanel != null)
            deathPanel.SetActive(false);

        // Reload gameplay scene completely (fresh start)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ------------------ MAIN MENU ------------------
    public void MainMenu()
    {
        Time.timeScale = 1f;

        // Hide gameplay panels
        deathPanel.SetActive(false);
        controlerObjects.SetActive(false);
        gameplayUI.SetActive(false);

        // Destroy all spawned objects
        DestroyAllTagged("Obstacle");
        DestroyAllTagged("Coin");
        DestroyAllTagged("Fire");
        DestroyAllTagged("Shield");

        // Show Main Menu UI
        if (mainMenuCanvas != null)
            mainMenuCanvas.SetActive(true);
    }

    void DestroyAllTagged(string tag)
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in list)
            Destroy(obj);
    }
}
