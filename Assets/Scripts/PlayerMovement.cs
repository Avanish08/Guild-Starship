using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Forward Movement")]
    public float speed = 5f;
    public float speedGrowth = 0.05f;

    [Header("Vertical Movement")]
    public float verticalSpeed = 5f;
    public float minY = -4f;
    public float maxY = 5f;

    private int verticalDirection = 0;

    [Header("Fire Shooting")]
    public GameObject fireBulletPrefab;
    public Transform firePoint;
    public int fireAmmo = 0;             // Fire count
    public GameObject fireVisual;        // UI or FX showing fire mode ON
    public TMP_Text fireAmmoText;        // TextMeshPro UI for ammo display

    [Header("Shield System")]
    public GameObject shieldVisual; 
    public float shieldDuration = 10f;
    private bool isShieldActive = false;
    private float shieldTimer = 0f;

    void Start()
    {
        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        if (fireVisual != null)
            fireVisual.SetActive(false);

        UpdateFireUI();
    }

    void Update()
    {
        MoveForward();
        HandleInputMovement();
        ApplyVerticalMovement();
        ClampY();
        UpdateShield();
    }

    // -------- Movement ----------
    void MoveForward()
    {
        speed += speedGrowth * Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void HandleInputMovement()
    {
        verticalDirection = 0;
        float halfScreen = Screen.width * 0.5f;

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x <= halfScreen)
            {
                Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                verticalDirection = (clickPos.y > transform.position.y) ? 1 : -1;
            }
        }
#endif

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x <= halfScreen)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                if (touch.phase == TouchPhase.Began ||
                    touch.phase == TouchPhase.Stationary ||
                    touch.phase == TouchPhase.Moved)
                {
                    verticalDirection = (touchPos.y > transform.position.y) ? 1 : -1;
                }
            }
        }
    }

    void ApplyVerticalMovement()
    {
        transform.Translate(Vector2.up * verticalDirection * verticalSpeed * Time.deltaTime);
    }

    void ClampY()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    // -------- Collision ----------
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            if (isShieldActive) return;
            Die();
        }
    }

    void Die()
    {
        DeathUI.instance.ShowDeathPanel();
    }

    // --------- Shooting ----------
    public void Shoot()
    {
        if (fireAmmo > 0)
        {
            Instantiate(fireBulletPrefab, firePoint.position, firePoint.rotation);
            fireAmmo--;

            UpdateFireUI();
        }
    }

    // --------- Fire UI ----------
    public void UpdateFireUI()
    {
        // Update text
        if (fireAmmoText != null)
            fireAmmoText.text = fireAmmo.ToString();

        // Fire visual
        if (fireVisual != null)
            fireVisual.SetActive(fireAmmo > 0);
    }

    // --------- Shield ----------
    public void ActivateShield()
    {
        isShieldActive = true;
        shieldTimer = shieldDuration;

        if (shieldVisual != null)
            shieldVisual.SetActive(true);
    }

    void UpdateShield()
    {
        if (!isShieldActive) return;

        shieldTimer -= Time.deltaTime;

        if (shieldTimer <= 0)
        {
            isShieldActive = false;

            if (shieldVisual != null)
                shieldVisual.SetActive(false);
        }
    }
}
