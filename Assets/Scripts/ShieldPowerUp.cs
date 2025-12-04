using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerMovement>().ActivateShield();
            Destroy(gameObject);
        }
    }
}
