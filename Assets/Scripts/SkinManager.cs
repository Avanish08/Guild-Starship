using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public GameObject[] skins;
    private int selectedSkin = 0;

    void Start()
    {
        SelectSkin(PlayerPrefs.GetInt("SelectedSkin", 0));
    }

    public void SelectSkin(int index)
    {
        selectedSkin = index;
        PlayerPrefs.SetInt("SelectedSkin", index);

        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(i == selectedSkin);
        }
    }
}
