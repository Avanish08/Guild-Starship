using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetX = 3f;

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(
                player.position.x + offsetX,
                0,
                -10
            );
        }
    }
}
