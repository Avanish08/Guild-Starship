using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Level Pieces / Obstacles")]
    public GameObject[] pieces;

    [Header("Random Y Range")]
    public float minY = -2f;
    public float maxY = 2f;

    [Header("Spawn Speed Settings")]
    public float startPieceLength = 20f;
    public float minPieceLength = 10f;
    public float speedIncreaseRate = 0.1f;

    [Header("Border Cleanup")]
    public Transform border;        // Reference to Border object
    public float destroyOffset = 1f;

    [Header("Spawn Delay")]
    public float initialSpawnDelay = 15f;  // Distance before first obstacle appears

    private float spawnX;
    private float currentPieceLength;

    // Tags to clean up
    private readonly string[] cleanupTags = { "Shield", "Coin", "Obstacle", "Fire" };

    void Start()
    {
        // Start spawning after some distance ahead of player
        spawnX = player.position.x + initialSpawnDelay;
        currentPieceLength = startPieceLength;
    }

    void Update()
    {
        // Gradually decrease distance between pieces to speed up gameplay
        if (currentPieceLength > minPieceLength)
            currentPieceLength -= speedIncreaseRate * Time.deltaTime;

        // Spawn next piece when player is near
        if (player.position.x + 30f > spawnX)
            SpawnPiece();

        // Clean up old objects
        CleanupBehindBorder();
    }

    void SpawnPiece()
    {
        int i = Random.Range(0, pieces.Length);
        float randomY = Random.Range(minY, maxY);

        Instantiate(pieces[i], new Vector3(spawnX, randomY, 0), Quaternion.identity);

        spawnX += currentPieceLength;
    }

    void CleanupBehindBorder()
    {
        if (border == null) return;

        foreach (string tag in cleanupTags)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objects)
            {
                if (obj.transform.position.x < border.position.x - destroyOffset)
                    Destroy(obj);
            }
        }
    }
}
