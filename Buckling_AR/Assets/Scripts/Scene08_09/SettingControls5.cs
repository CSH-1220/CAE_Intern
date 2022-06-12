using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControls5 : MonoBehaviour
{
    public GameObject RectangleInfo;
    public GameObject CircleInfo;

    public Text ColumnHeightText;
    public Text ColumnWidthText;

    public void ShowInfo()
    {
        if (OkCancelControls.onRectangle==true)
        {
            RectangleInfo.SetActive(true);
            ColumnHeightText.text = $"Section Height: {OkCancelControls.ColumnHeight.ToString("F2")} cm";
            ColumnWidthText.text = $"Section Width: {OkCancelControls.ColumnWidth.ToString("F2")} cm";
        }
    }

    public void CloseInfo()
    {
        if (OkCancelControls.onRectangle == true)
        {
            RectangleInfo.SetActive(false);
        }
    }
}
