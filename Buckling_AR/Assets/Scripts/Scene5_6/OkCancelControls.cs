using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OkCancelControls : MonoBehaviour
{
    public Toggle RetangleToggle;
    public Toggle CircleToggle;

    public GameObject Sectiontype;
    public GameObject ColumnHeight_InputWindow;
    public GameObject ColumnWidth_InputWindow;

    public static bool onRectangle;

    public static float ColumnHeight;
    private float DefaultColumnHeight = 10f;
    public static float ColumnWidth;
    private float DefaultColumnWidth = 10f;
    public static float ColumnRadius;


    public TMP_InputField ColumnHeightInputField;
    public TMP_InputField ColumnWidthInputField;


    private void Start()
    {
        onRectangle = false;
        Sectiontype.SetActive(true);
        ColumnHeight_InputWindow.SetActive(false);
        ColumnWidth_InputWindow.SetActive(false);
    }
    //For Section OK Button
    public void TypeSelection()
    {
        if (RetangleToggle.isOn == true)
        {
            Sectiontype.SetActive(false);
            ColumnHeight_InputWindow.SetActive(true);
            onRectangle = true;

        }
        if (CircleToggle.isOn == true)
        {
            Sectiontype.SetActive(false);
            //還要改
            ColumnHeight_InputWindow.SetActive(true);
        }
    }
    //For Section Cancel Button
    public void BackToCreateScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void BackToChoosingTypeWindow()
    {
        if (onRectangle==true)
        {
            Sectiontype.SetActive(true);
            ColumnHeight_InputWindow.SetActive(false);
            onRectangle = false;
        }
    }

    public void GetColumnHeight()
    {

        ColumnHeight_InputWindow.SetActive(false);
        ColumnWidth_InputWindow.SetActive(true);

        string inputText = ColumnHeightInputField.text;
        // Try to Parse input string
        if (float.TryParse(inputText, out float _f))
        {
            ColumnHeight = _f;
        }
        else
        {
            ColumnHeight = DefaultColumnHeight;
        }
    }

    public void GetColumnWidth()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        string inputText = ColumnWidthInputField.text;
        // Try to Parse input string
        if (float.TryParse(inputText, out float _f))
        {
            ColumnWidth = _f;
        }
        else
        {
            ColumnWidth = DefaultColumnWidth;
        }


    }

    public void BackToColumnHeight()
    {
        ColumnHeight_InputWindow.SetActive(true);
        ColumnWidth_InputWindow.SetActive(false);
    }


}
