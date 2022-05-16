using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System.IO;
using System.Globalization;


public class Graph_Force_Column1 : MonoBehaviour
{
    static int boundarycondition1 = BoundaryConditionPage.Parameter1;
    static int section1 = SectionPage.Parameter1;
    static int length1 = LengthPage.Parameter1;
    static int bracing1 = BracingPage.Parameter1;


    string dataLocation = PreGamePage.dataLocation;
    private static Graph_Force_Column1 instance;
    [SerializeField] private Sprite dotSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private List<GameObject> gameObjectsList;

    private static List<float> valueList1 = new List<float> { 0 };


    private readonly List<float> valueList0 = new List<float> { };
    private IGraphVisual graphVisual1;
    private static int maxVisibleValueAmount;
    private Func<int, string> getAxisLabelX;
    private Func<float, string> getAxisLabelY;

    private static StreamReader file1;
    private static int file1Count;
    private int MaxFileCount;

    private string[] valueString = new string[3];

    public Font Font;
    GameObject LoadGameObject1;
    private void Awake()
    {
        instance = this;
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        gameObjectsList = new List<GameObject>();
        string pathOfFile1 = dataLocation + @"/BoundaryCondition" + boundarycondition1 + @"/Section" + section1 + @"/Length" + length1 + @"/Bracing" + bracing1 + @"/forceresultant.txt"; ;
        file1 = new StreamReader(pathOfFile1, Encoding.Default);
        file1Count = IndexCount(file1);
        MaxFileCount = Mathf.Max(file1Count);
        file1 = new StreamReader(pathOfFile1, Encoding.Default);
        LoadValueSetting();
    }
    void Update()
    {
        IGraphVisual graphVisual1 = new LineGraphVisual(graphContainer, dotSprite, Color.green, new Color(0, 1, 0, 1));

        this.graphVisual1 = graphVisual1;
        ShowGraph(Graph_Force.valueList1, this.graphVisual1, -1, (int _i) => "", (float _f) => Mathf.RoundToInt(_f) + " kN");
        ShowCurrentLoad();

    }
    private int IndexCount(StreamReader file)
    {
        int LinesCount = 0;

        string Line = file.ReadLine();
        while (Line != null)
        {
            LinesCount++;
            Line = file.ReadLine();
        }

        return LinesCount;

    }
    private void LoadValueSetting()
    {
        LoadGameObject1 = new GameObject("Load", typeof(Text), typeof(Shadow));
        LoadGameObject1.transform.SetParent(transform, false);
        LoadGameObject1.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 100);
        LoadGameObject1.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        LoadGameObject1.transform.localPosition = new Vector2(320, 10);
        LoadGameObject1.GetComponent<Text>().text = "Load : " + "\n" + "0 kN";
        LoadGameObject1.GetComponent<Text>().font = Font;
        LoadGameObject1.GetComponent<Text>().fontStyle = FontStyle.Bold;
        LoadGameObject1.GetComponent<Text>().fontSize = 28;
        LoadGameObject1.GetComponent<Text>().color = new Color32(0, 255, 0, 255);

        LoadGameObject1.GetComponent<Shadow>().effectColor = new Color32(0, 0, 0, 255);
        LoadGameObject1.GetComponent<Shadow>().effectDistance = new Vector2(1, -1);

    }
    public void ShowCurrentLoad()
    {
        LoadGameObject1.GetComponent<Text>().text = "Load : " + "\n" + Graph_Force.valueList1[Graph_Force.valueList1.Count - 1] + " kN";
    }

    private void ShowGraph(List<float> valueList1, IGraphVisual graphVisual1, int maxVisibleValueAmount = -1, Func<int, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null)
    {
        Graph_Force.valueList1 = valueList1;
        this.graphVisual1 = graphVisual1;
        this.getAxisLabelX = getAxisLabelX;
        this.getAxisLabelY = getAxisLabelY;

        if (maxVisibleValueAmount <= 0)
        {
            maxVisibleValueAmount = valueList1.Count;
        }
        if (maxVisibleValueAmount > valueList1.Count)
        {
            maxVisibleValueAmount = valueList1.Count;
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

        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0)
        {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - (yDifference * 0.2f);

        float xSize = graphWidth / (MaxFileCount + 1);

        int xIndex1 = 0;
        for (int i = Mathf.Max(valueList1.Count - maxVisibleValueAmount, 0); i < valueList1.Count; i++)
        {
            float xPosition1 = xSize + xIndex1 * xSize;
            float yPosition1 = ((valueList1[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;
            gameObjectsList.AddRange(this.graphVisual1.AddGraphVisual(new Vector2(xPosition1, yPosition1), xSize));

            xIndex1++;
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
