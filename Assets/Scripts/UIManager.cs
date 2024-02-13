using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text mineNumber_text;
    [SerializeField] TMP_Text farmNumber_text;

    public void UpdateBuildingNumber(int mineNumber, int farmNumber)
    {
        mineNumber_text.text = mineNumber.ToString();
        farmNumber_text.text = farmNumber.ToString();
    }

}
