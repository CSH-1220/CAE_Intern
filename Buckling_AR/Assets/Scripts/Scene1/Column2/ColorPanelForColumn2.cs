using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPanelForColumn2 : MonoBehaviour
{
    private RectTransform Color;
    public Font Font;

    public static float value0 = Column2.color1_Bottom;
    public static float value1 = Column2.color1_Top;
    public static float value2 = Column2.color2_Top;
    public static float value3 = Column2.color3_Top;
    public static float value4 = Column2.color4_Top;
    public static float value5 = Column2.color5_Top;
    public static float value6 = Column2.color6_Top;
    public static float value7 = Column2.color7_Top;
    public static float value8 = Column2.color8_Top;
    public static float value9 = Column2.color9_Top;
    public static float value10 = Column2.color10_Top;

    public static Color32 color0 = Column2.color0;
    public static Color32 color1 = Column2.color1;
    public static Color32 color2 = Column2.color2;
    public static Color32 color3 = Column2.color3;
    public static Color32 color4 = Column2.color4;
    public static Color32 color5 = Column2.color5;
    public static Color32 color6 = Column2.color6;
    public static Color32 color7 = Column2.color7;
    public static Color32 color8 = Column2.color8;
    public static Color32 color9 = Column2.color9;
    public static Color32 color10 = Column2.color10;

    Color32[] ColorArray = new Color32[] { color0, color1, color2, color3, color4, color5, color6, color7, color8, color9, color10 };
    float[] valueArray = new float[] { value0, value1, value2, value3, value4, value5, value6, value7, value8, value9, value10 };

    public void Update()
    {
        value0 = Column2.color1_Bottom;
        value1 = Column2.color1_Top;
        value2 = Column2.color2_Top;
        value3 = Column2.color3_Top;
        value4 = Column2.color4_Top;
        value5 = Column2.color5_Top;
        value6 = Column2.color6_Top;
        value7 = Column2.color7_Top;
        value8 = Column2.color8_Top;
        value9 = Column2.color9_Top;
        value10 = Column2.color10_Top;
        valueArray = new float[] { value0, value1, value2, value3, value4, value5, value6, value7, value8, value9, value10 };

        ChangeValue();
    }


    public void Start()
    {
        Color = transform.GetComponent<RectTransform>();
        for (int i = 0; i < 10; i++)
        {
            CreateColor(10 - i);
        }
    }

    public GameObject CreateColor(int colorNumber)
    {
        GameObject gameObject = new GameObject("Color" + colorNumber, typeof(Image));
        gameObject.transform.SetParent(Color, false);
        gameObject.GetComponent<Image>().color = ColorArray[colorNumber];

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(60, 60);

        GameObject value = new GameObject("value", typeof(Text));
        value.transform.SetParent(gameObject.transform, false);
        value.GetComponent<Text>().text = "0.00";
        value.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 40);
        value.transform.localPosition = new Vector2(-30, 20);
        value.GetComponent<Text>().alignment = TextAnchor.UpperLeft;
        value.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        value.GetComponent<Text>().font = Font;
        value.GetComponent<Text>().fontSize = 25;
        value.GetComponent<Text>().fontStyle = FontStyle.Bold;

        if (colorNumber == 1)
        {
            GameObject value_min = new GameObject("value_min", typeof(Text));
            value_min.transform.SetParent(gameObject.transform, false);
            value_min.GetComponent<Text>().text = "0.00";
            value_min.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 40);
            value_min.transform.localPosition = new Vector2(-30, -48);
            value_min.GetComponent<Text>().alignment = TextAnchor.UpperLeft;
            value_min.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
            value_min.GetComponent<Text>().font = Font;
            value_min.GetComponent<Text>().fontSize = 25;
            value_min.GetComponent<Text>().fontStyle = FontStyle.Bold;
        }

        return gameObject;
    }
    public void ChangeValue()
    {
        for (int i = 1; i <= 10; i++)
        {
            RectTransform ColorIndex = transform.Find("Color" + i).GetComponent<RectTransform>();
            decimal value = decimal.Round((decimal)valueArray[i], 1);
            ColorIndex.GetChild(0).GetComponent<Text>().text = value.ToString();
            if (i == 1)
            {
                decimal value2 = decimal.Round((decimal)valueArray[i - 1], 1);
                ColorIndex.GetChild(1).GetComponent<Text>().text = value2.ToString();
            }
        }
    }

}
