using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float speed = 12f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
