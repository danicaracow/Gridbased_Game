using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mineNumber_text;
    [SerializeField] TextMeshProUGUI farmNumber_text;
    [SerializeField] TextMeshProUGUI goldAmount_text;
    [SerializeField] TextMeshProUGUI foodAmount_text;

    public static PlayerStatsUI Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void UpdateBuildingNumber(int mineNumber, int farmNumber)
    {
        mineNumber_text.text = mineNumber.ToString();
        farmNumber_text.text = farmNumber.ToString();
    }

    public void UpdateResourcesNumber(int mineNumber, int farmNumber)
    {
        goldAmount_text.text = mineNumber.ToString();
        foodAmount_text.text = farmNumber.ToString();
    }
}
