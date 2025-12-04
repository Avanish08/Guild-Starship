using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // end game
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }
}
