using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("UI")]
    public TMP_Text coinText;
    public TMP_Text runText;

    [Header("Scores")]
    int coins = 0;
    float runTime = 0f;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // time survived score
        runTime += Time.deltaTime;
        runText.text = Mathf.FloorToInt(runTime).ToString();
    }

    // Add exactly 1 coin
    public void AddCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }

    // Add any amount (this fixes your CS1061 error)
    public void AddCoins(int amount)
    {
        coins += amount;
        coinText.text = coins.ToString();
    }
}
