using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text mineNumber_text;
    [SerializeField] TMP_Text farmNumber_text;
    public Button buildButton;
    public Button destroyButton;
    public Button selectButton;

    public static UIManager Instance { get; private set; }

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

}
