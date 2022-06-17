using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System.IO;
using System.Globalization;


public class Graph_Force : MonoBehaviour
{
    //static int boundarycondition1 = BoundaryConditionPage.Parameter1;
    //static int section1 = SectionPage.Parameter1;
    //static int length1 = LengthPage.Parameter1;
    //static int bracing1 = BracingPage.Parameter1;

    //static int boundarycondition2 = BoundaryConditionPage.Parameter2;
    //static int section2 = SectionPage.Parameter2;
    //static int length2 = LengthPage.Parameter2;
    //static int bracing2 = BracingPage.Parameter2;


    static int boundarycondition1 = 2;
    static int section1 = 2;
    static int length1 = 2;
    static int bracing1 = 1;

    static int boundarycondition2 = 2;
    static int section2 = 2;
    static int length2 = 2;
    static int bracing2 = 1;



    string dataLocation = PreGamePage.dataLocation;

    private static Graph_Force instance;
    [SerializeField] private Sprite dotSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private List<GameObject> gameObjectsList;

    public static List<float> valueList1 = new List<float> { 0 };
    public static List<float> valueList2 = new List<float> { 0 };

    private readonly List<float> valueList0 = new List<float> { };
    private IGraphVisual graphVisual1;
    private IGraphVisual graphVisual2;
    public static int maxVisibleValueAmount;
    private Func<int, string> getAxisLabelX;
    private Func<float, string> getAxisLabelY;

    static public int index1 = 0;
    static public int index2 = 0;

    public static string file1;
    public static string file2;
    public static int file1Count;
    public static int file2Count;
    public int MaxFileCount;

    private string[] valueString = new string[3];

    public Font Font;
    GameObject LoadGameObject1;
    GameObject LoadGameObject2;


    private void Awake()
    {
        instance = this;
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        gameObjectsList = new List<GameObject>();

        var textFile1 = Resources.Load<TextAsset>(@"ColumnData/BoundaryCondition" + boundarycondition1 + @"/Section" + section1 + @"/Length" + length1 + @"/Bracing" + bracing1 + @"/forceresultant");
        file1 = textFile1.text;
        file1Count = file1.Split('\n').Length;
        var textFile2 = Resources.Load<TextAsset>(@"ColumnData/BoundaryCondition" + boundarycondition2 + @"/Section" + section2 + @"/Length" + length2 + @"/Bracing" + bracing2 + @"/forceresultant");
        file2 = textFile2.text;
        file2Count = file2.Split('\n').Length;
        MaxFileCount = Mathf.Max(file1Count, file2Count);
        LoadValueSetting();
    }

    void Update()
    {
        IGraphVisual graphVisual1 = new LineGraphVisual(graphContainer, dotSprite, Color.green, new Color(0, 1, 0, 1));
        IGraphVisual graphVisual2 = new LineGraphVisual(graphContainer, dotSprite, Color.red, new Color(1, 0, 0, 1));

        this.graphVisual1 = graphVisual1;
        this.graphVisual2 = graphVisual2;

        ShowGraph(Graph_Force.valueList1, Graph_Force.valueList2, this.graphVisual1, this.graphVisual2, -1, (int _i) => "", (float _f) => Mathf.RoundToInt(_f) + " kN");
        ShowCurrentLoad();

    }
    public static void Column1Load()
    {
        if (Graph_Force.valueList1.Count <= Graph_Force.file1Count)
        {
            Graph_Force.index1++;
            Graph_Force.valueList1 = Graph_Force.ChanegeValueList1(index1);
        }
    }
    public static void Column2Load()
    {
        if (Graph_Force.valueList2.Count <= Graph_Force.file2Count)
        {
            Graph_Force.index2++;
            Graph_Force.valueList2 = ChanegeValueList2(index2);
        }

    }
    public static void Column1Renew()
    {
        Graph_Force.valueList1.Clear();
        index1 = 0;
        Graph_Force.valueList1 = Graph_Force.ChanegeValueList1(index1);
    }

    public static void Column2Renew()
    {
        Graph_Force.valueList2.Clear();
        index2 = 0;
        Graph_Force.valueList2 = Graph_Force.ChanegeValueList2(index2);
    }

    private void LoadValueSetting()
    {
        LoadGameObject1 = new GameObject("Load", typeof(Text), typeof(Shadow));
        LoadGameObject1.transform.SetParent(transform, false);
        LoadGameObject1.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 100);
        LoadGameObject1.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        LoadGameObject1.transform.localPosition = new Vector2(420, 100);
        LoadGameObject1.GetComponent<Text>().text = "Load : " + "\n" + "0 kN";
        LoadGameObject1.GetComponent<Text>().font = Font;
        LoadGameObject1.GetComponent<Text>().fontStyle = FontStyle.Bold;
        LoadGameObject1.GetComponent<Text>().fontSize = 28;
        LoadGameObject1.GetComponent<Text>().color = new Color32(0, 255, 0, 255);

        LoadGameObject1.GetComponent<Shadow>().effectColor = new Color32(0, 0, 0, 255);
        LoadGameObject1.GetComponent<Shadow>().effectDistance = new Vector2(1, -1);

        LoadGameObject2 = new GameObject("Load", typeof(Text), typeof(Shadow));
        LoadGameObject2.transform.SetParent(transform, false);
        LoadGameObject2.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 100);
        LoadGameObject2.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        LoadGameObject2.transform.localPosition = new Vector2(420, 0);
        LoadGameObject2.GetComponent<Text>().text = "Load : " + "\n" + "0 kN";
        LoadGameObject2.GetComponent<Text>().font = Font;
        LoadGameObject2.GetComponent<Text>().fontStyle = FontStyle.Bold;
        LoadGameObject2.GetComponent<Text>().fontSize = 28;
        LoadGameObject2.GetComponent<Text>().color = new Color32(255, 0, 0, 255);

        LoadGameObject2.GetComponent<Shadow>().effectColor = new Color32(0, 0, 0, 255);
        LoadGameObject2.GetComponent<Shadow>().effectDistance = new Vector2(1, -1);

    }

    public static List<float> ChanegeValueList1(int index)
    {
        string[] forceResultantList = file1.Split('\n');
        string valueLine1 = forceResultantList[index];
        float value1 = float.Parse(valueLine1) / 1000;
        Graph_Force.valueList1.Add(value1);
        Graph_Force.maxVisibleValueAmount = Graph_Force.valueList1.Count + Graph_Force.valueList2.Count;
        return Graph_Force.valueList1;
    }

    public static List<float> ChanegeValueList2(int index)
    {
        string[] forceResultantList = file2.Split('\n');
        string valueLine2 = forceResultantList[index];
        float value2 = float.Parse(valueLine2) / 1000;
        Graph_Force.valueList2.Add(value2);
        Graph_Force.maxVisibleValueAmount = Graph_Force.valueList1.Count + Graph_Force.valueList2.Count;
        return Graph_Force.valueList2;
    }

    public void ShowCurrentLoad()
    {
        LoadGameObject1.GetComponent<Text>().text = "Load : " + "\n" + Graph_Force.valueList1[Graph_Force.valueList1.Count - 1] + " kN";
        LoadGameObject2.GetComponent<Text>().text = "Load : " + "\n" + Graph_Force.valueList2[Graph_Force.valueList2.Count - 1] + " kN";
    }
    private void ShowGraph(List<float> valueList1, List<float> valueList2, IGraphVisual graphVisual1, IGraphVisual graphVisual2, int maxVisibleValueAmount = -1, Func<int, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null)
    {
        Graph_Force.valueList1 = valueList1;
        Graph_Force.valueList2 = valueList2;

        this.graphVisual1 = graphVisual1;
        this.graphVisual2 = graphVisual2;

        this.getAxisLabelX = getAxisLabelX;
        this.getAxisLabelY = getAxisLabelY;

        if (maxVisibleValueAmount <= 0)
        {
            maxVisibleValueAmount = valueList1.Count + valueList2.Count;
        }
        if (maxVisibleValueAmount > valueList1.Count + valueList2.Count)
        {
            maxVisibleValueAmount = valueList1.Count + valueList2.Count;
        }

        Graph_Force.maxVisibleValueAmount = maxVisibleValueAmount;

        if (getAxisLabelX == null)
        {
            getAxisLabelX = delegate (int _i) { return _i.ToString(); };
        }

        if (getAxisLabelY == null)
        {
            getAxisLabelY = delegate (float _f) { return Mathf.RoundToInt(_f).ToString(); };
        }


        foreach (GameObject gameObject in gameObjectsList)
        {
            Destroy(gameObject);
        }
        gameObjectsList.Clear();
        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        float yMaximum = valueList1[0];
        float yMinimum = valueList1[0];

        for (int i = Mathf.Max(valueList1.Count - maxVisibleValueAmount, 0); i < valueList1.Count; i++)
        {
            float value = valueList1[i];

            if (value > yMaximum)
            {
                yMaximum = value;
            }
            if (value < yMinimum)
            {
                yMinimum = value;
            }
        }
        for (int j = Mathf.Max(valueList2.Count - maxVisibleValueAmount, 0); j < valueList2.Count; j++)
        {
            float value = valueList2[j];

            if (value > yMaximum)
            {
                yMaximum = value;
            }
            if (value < yMinimum)
            {
                yMinimum = value;
            }
        }

        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0)
        {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - (yDifference * 0.2f);

        float xSize = graphWidth / (MaxFileCount + 1);

        int xIndex1 = 0;
        int xIndex2 = 0;
        for (int i = Mathf.Max(valueList1.Count - maxVisibleValueAmount, 0); i < valueList1.Count; i++)
        {
            float xPosition1 = xSize + xIndex1 * xSize;
            float yPosition1 = ((valueList1[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;
            gameObjectsList.AddRange(this.graphVisual1.AddGraphVisual(new Vector2(xPosition1, yPosition1), xSize));

            xIndex1++;
        }

        for (int j = Mathf.Max(valueList2.Count - maxVisibleValueAmount, 0); j < valueList2.Count; j++)
        {
            float xPosition2 = xSize + xIndex2 * xSize;
            float yPosition2 = ((valueList2[j] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;
            gameObjectsList.AddRange(this.graphVisual2.AddGraphVisual(new Vector2(xPosition2, yPosition2), xSize));

            xIndex2++;
        }

        int separatorCount = 4;
        for (int i = 0; i <= separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;

            labelY.anchoredPosition3D = new Vector3(-30f, normalizedValue * graphHeight + 1f, 0f);
            labelY.GetComponent<Text>().text = getAxisLabelY(yMinimum + (normalizedValue * (yMaximum - yMinimum)));
            labelY.GetComponent<Text>().font = Font;
            labelY.GetComponent<Text>().fontSize = 11;
            gameObjectsList.Add(labelY.gameObject);
        }

    }


    private interface IGraphVisual
    {
        List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositionWidth);
    }


    private class LineGraphVisual : IGraphVisual
    {
        private RectTransform graphContainer;
        private Sprite dotSprite;
        private GameObject lastDotGameObject;
        private Color dotColor;
        private Color dotConnectionColor;
        public LineGraphVisual(RectTransform graphContainer, Sprite dotSprite, Color dotColor, Color dotConnectionColor)
        {
            this.graphContainer = graphContainer;
            this.dotSprite = dotSprite;
            this.lastDotGameObject = null;
            this.dotColor = dotColor;
            this.dotConnectionColor = dotConnectionColor;
        }

        public List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositionWidth)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            GameObject dotGameObject = CreateDot(graphPosition);
            gameObjectList.Add(dotGameObject);
            if (lastDotGameObject != null)
            {
                GameObject dotConnectionGameObject = CreateDotConnection(lastDotGameObject.GetComponent<RectTransform>().anchoredPosition, dotGameObject.GetComponent<RectTransform>().anchoredPosition);

                gameObjectList.Add(dotConnectionGameObject);
            }
            lastDotGameObject = dotGameObject;

            return gameObjectList;
        }

        private GameObject CreateDot(Vector2 ancordedPosition)
        {
            GameObject gameObject = new GameObject("dot", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().sprite = dotSprite;
            gameObject.GetComponent<Image>().color = dotColor;
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = ancordedPosition;
            rectTransform.sizeDelta = new Vector2(1, 1);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            return gameObject;
        }

        private GameObject CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
        {
            GameObject gameObject = new GameObject("dotConnection", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().color = dotConnectionColor;
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            Vector2 direction = (dotPositionB - dotPositionA).normalized;
            float distance = Vector2.Distance(dotPositionA, dotPositionB);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.sizeDelta = new Vector2(distance, 1f);
            rectTransform.anchoredPosition = dotPositionA + direction * distance * .5f;
            rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(direction));
            return gameObject;
        }
    }
}
