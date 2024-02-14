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
    public Button mineSelectButton;
    public Button farmSelectButton;

    private bool IsBuildMenuOpen;

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

    private void Start()
    {
        Instance.buildButton.onClick.AddListener(OnBuildButtonPressed);

        //Dinamic buttons (Disabled on start)
        mineSelectButton.gameObject.SetActive(false);
        farmSelectButton.gameObject.SetActive(false);
    }


    public void UpdateBuildingNumber(int mineNumber, int farmNumber)
    {
        mineNumber_text.text = mineNumber.ToString();
        farmNumber_text.text = farmNumber.ToString();
    }

    private void OnBuildButtonPressed()
    {
        OpenBuildButtonMenu();
    }

    private void OpenBuildButtonMenu()
    {
        mineSelectButton.transform.position = buildButton.transform.position + new Vector3(-40, 50);
        farmSelectButton.transform.position = buildButton.transform.position + new Vector3(40, 50);
        if (!IsBuildMenuOpen)
        {
            mineSelectButton.gameObject.SetActive(true);
            farmSelectButton.gameObject.SetActive(true);
            IsBuildMenuOpen = true;
        }
        else
        {
            mineSelectButton.gameObject.SetActive(false);
            farmSelectButton.gameObject.SetActive(false);
            IsBuildMenuOpen = false;
        }
    }
}
