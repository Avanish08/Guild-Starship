using UnityEngine;

public class FirePowerUp : MonoBehaviour
{
    public int amount = 5;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerMovement pm = col.GetComponent<PlayerMovement>();

            pm.fireAmmo += amount;
            pm.UpdateFireUI();

            Destroy(gameObject);
        }
    }
}
