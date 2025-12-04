using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 0.1f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
       rend.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);

    }
}
