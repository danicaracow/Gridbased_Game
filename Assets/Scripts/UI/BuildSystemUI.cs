using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BuildSystemUI : MonoBehaviour
{

    public Button buildButton;
    public Button destroyButton;
    public Button selectButton;
    public Button mineSelectButton;
    public Button farmSelectButton;

    private bool IsBuildMenuOpen;



    private void Start()
    {
        buildButton.onClick.AddListener(OnBuildButtonPressed);
        mineSelectButton.onClick.AddListener(BuildSystem.Instance.OnMineSelectButtonPressed);
        farmSelectButton.onClick.AddListener(BuildSystem.Instance.OnFarmSelectButtonPressed);
        mineSelectButton.onClick.AddListener(MouseSelection.Instance.OnBuildButtonPressed);
        farmSelectButton.onClick.AddListener(MouseSelection.Instance.OnBuildButtonPressed);
        buildButton.onClick.AddListener(MouseSelection.Instance.OnSelectButtonPressed);
        destroyButton.onClick.AddListener(MouseSelection.Instance.OnDestroyButtonPressed);
        selectButton.onClick.AddListener(MouseSelection.Instance.OnSelectButtonPressed);

        //Dynamic buttons (Disabled on start)
        mineSelectButton.gameObject.SetActive(false);
        farmSelectButton.gameObject.SetActive(false);
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
