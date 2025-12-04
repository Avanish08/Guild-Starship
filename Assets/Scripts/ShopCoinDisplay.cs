using UnityEngine;
using TMPro;

public class ShopCoinDisplay : MonoBehaviour
{
    public TMP_Text coinText;

    void Start()
    {
        int coins = PlayerPrefs.GetInt("TotalCoins", 0);
        coinText.text = coins.ToString();
    }
}
