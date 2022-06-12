using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System.IO;
using System.Globalization;
using System.Linq;


public class Graph_Displacement_Column1 : MonoBehaviour
{
    static int boundarycondition1 = BCPage.Parameter1;
    static int section1 = SPage.Parameter1;
    static int length1 = LPage.Parameter1;
    static int bracing1 = BPage.Parameter1;

    string dataLocation = PreGamePage.dataLocation;

    static int index1 = Column1.index;
    static int index2 = Column2.index;

    public Font Font;
    private static Graph_Displacement_Column1 instance;
    [SerializeField] private Sprite dotSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private List<GameObject> gameObjectsList;
    private GameObject tooltipGameObject;


    private static List<float> valueList1 = new List<float> { 0 };

    private IGraphVisual graphVisual1;
    private static int maxVisibleValueAmount;
    private Func<float, string> getAxisLabelX;
    private Func<int, string> getAxisLabelY;

    private static StreamReader file1;
    private string[] valueString = new string[3];
    private static int fileCount1;

    GameObject MaxDispGameObject1;
    GameObject MaxDisplacementLocationObject1;
    float yValue;


    private void Awake()
    {
        instance = this;
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        gameObjectsList = new List<GameObject>();
        tooltipGameObject = graphContainer.Find("tooltip").gameObject;

        FileCount();
        ShowMaxDisplacement();

    }

    void Update()
    {
        graphVisual1 = new LineGraphVisual(graphContainer, dotSprite, Color.green, new Color(0, 1, 0, 1));
        ShowGraph(Graph_Displacement.valueList1, this.graphVisual1, -1, (float _i) => Mathf.RoundToInt(_i) + "", (int _i) => _i.ToString());
        ChangeMaxDisplacement();
    }

    private void FileCount()
    {
        DirectoryInfo File1 = new DirectoryInfo(dataLocation + @"/BoundaryCondition" + boundarycondition1 + @"/Section" + section1 + @"/Length" + length1 + @"/Bracing" + bracing1 + @"/Displacement");
        FileInfo[] files1 = File1.GetFiles("*.txt");
        fileCount1 = files1.Length - 1;
    }
    public void ShowMaxDisplacement()
    {
        MaxDispGameObject1 = new GameObject("MaxDisplacement1", typeof(Text), typeof(Shadow));
        MaxDispGameObject1.transform.SetParent(transform, false);
        MaxDispGameObject1.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 90);
        MaxDispGameObject1.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        MaxDispGameObject1.transform.localPosition = new Vector2(320, 40);
        MaxDispGameObject1.GetComponent<Text>().text = "Max Displacement:" + "\n" + "0 mm";
        MaxDispGameObject1.GetComponent<Text>().font = Font;
        MaxDispGameObject1.GetComponent<Text>().fontStyle = FontStyle.Bold;
        MaxDispGameObject1.GetComponent<Text>().fontSize = 23;
        MaxDispGameObject1.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
        MaxDispGameObject1.GetComponent<Shadow>().effectColor = new Color32(0, 0, 0, 255);
        MaxDispGameObject1.GetComponent<Shadow>().effectDistance = new Vector2(1, -1);

        MaxDisplacementLocationObject1 = new GameObject("MaxDisplacementLocation1", typeof(Text), typeof(Shadow));
        MaxDisplacementLocationObject1.transform.SetParent(transform, false);
        MaxDisplacementLocationObject1.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 90);
        MaxDisplacementLocationObject1.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        MaxDisplacementLocationObject1.transform.localPosition = new Vector2(570, 40);
        MaxDisplacementLocationObject1.GetComponent<Text>().text = "Max Displacement at:" + "\n" + "0 m";
        MaxDisplacementLocationObject1.GetComponent<Text>().font = Font;
        MaxDisplacementLocationObject1.GetComponent<Text>().fontStyle = FontStyle.Bold;
        MaxDisplacementLocationObject1.GetComponent<Text>().fontSize = 23;
        MaxDisplacementLocationObject1.GetComponent<Text>().color = new Color32(0, 255, 0, 255);
        MaxDisplacementLocationObject1.GetComponent<Shadow>().effectColor = new Color32(0, 0, 0, 255);
        MaxDisplacementLocationObject1.GetComponent<Shadow>().effectDistance = new Vector2(1, -1);
    }

    public void ChangeMaxDisplacement()
    {
        float MaxDispacement1 = 0;
        float Max1 = Graph_Displacement.valueList1.Max();
        float Min1 = Graph_Displacement.valueList1.Min();
        if (Mathf.Abs(Max1) > Mathf.Abs(Min1))
        {
            MaxDispacement1 = Max1;
        }
        else
        {
            MaxDispacement1 = Min1;
        }
        MaxDispGameObject1.GetComponent<Text>().text = "Max Displacement : " + "\n" + MaxDispacement1 + " mm";

        float MaxDisplacementLocation1 = (float)Graph_Displacement.valueList1.IndexOf(MaxDispacement1) * length1 * 4 / (Graph_Displacement.valueList1.Count() - 1);
        MaxDisplacementLocationObject1.GetComponent<Text>().text = "Max Displacement at : " + "\n" + MaxDisplacementLocation1 + " m";
    }
    private void ShowGraph(List<float> valueList1, IGraphVisual graphVisual1, int maxVisibleValueAmount = -1, Func<float, string> getAxisLabelX = null, Func<int, string> getAxisLabelY = null)
    {
        Graph_Displacement.valueList1 = valueList1;

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

        Graph_Displacement.maxVisibleValueAmount = maxVisibleValueAmount;

        if (getAxisLabelX == null)
        {
            getAxisLabelX = delegate (float _f) { return Mathf.RoundToInt(_f).ToString(); };

        }

        if (getAxisLabelY == null)
        {
            getAxisLabelY = delegate (int _i) { return _i.ToString(); };

        }

        foreach (GameObject gameObject in gameObjectsList)
        {
            Destroy(gameObject);
        }
        gameObjectsList.Clear();

        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;
        float xMaximum = 1500;
        float xMinimum = -1500;
        float xDifference = xMaximum - xMinimum;
        float ratio1 = 1;
        int length2 = 0;

        if (length1 > length2)
        {
            ratio1 = 1;
        }
        else if (length1 == length2)
        {
            ratio1 = 1;
        }
        else if (length2 > length1)
        {
            ratio1 = 2;
        }

        float ySize1 = graphHeight / (Graph_Displacement.valueList1.Count + 1) / ratio1;

        int yIndex1 = 0;
        for (int i = Mathf.Max(valueList1.Count - maxVisibleValueAmount, 0); i < valueList1.Count; i++)
        {
            float xPosition = ((valueList1[i] - xMinimum) / (xMaximum - xMinimum)) * graphWidth;
            float yPosition = ySize1 + yIndex1 * ySize1;


            gameObjectsList.AddRange(graphVisual1.AddGraphVisual(new Vector2(xPosition, yPosition), ySize1));


            if (length1 > length2 || length1 == length2)
            {
                RectTransform labelY = Instantiate(labelTemplateY);
                labelY.SetParent(graphContainer);
                labelY.gameObject.SetActive(true);
                labelY.anchoredPosition3D = new Vector3(-20f, yPosition + 1f, 0f);

                if (i % 5 == 0)
                {
                    decimal yValue = decimal.Round((decimal)(float.Parse(getAxisLabelY(i)) * length1 * 4 / (valueList1.Count - 1)), 1);
                    labelY.GetComponent<Text>().text = yValue.ToString() + " m";
                }
                else
                {
                    labelY.GetComponent<Text>().text = "";
                }

                labelY.GetComponent<Text>().fontSize = 10;
                labelY.GetComponent<Text>().fontStyle = FontStyle.Bold;
                gameObjectsList.Add(labelY.gameObject);
            }
            yIndex1++;
        }
        int XSeparatorCount = 4;
        for (int i = 0; i <= XSeparatorCount; i++)
        {

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer);
            labelX.gameObject.SetActive(true);
            float normalizedValue = i * 1f / XSeparatorCount;
            labelX.anchoredPosition3D = new Vector3(normalizedValue * graphWidth, -20f, 0f);
            labelX.GetComponent<Text>().text = getAxisLabelX((int)(xMinimum + (normalizedValue * xDifference)));
            labelX.GetComponent<Text>().font = Font;
            labelX.GetComponent<Text>().fontSize = 10;
            labelX.GetComponent<Text>().fontStyle = FontStyle.Bold;
            gameObjectsList.Add(labelX.gameObject);
        }
    }


    private interface IGraphVisual
    {
        List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositionHeight);
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

        public List<GameObject> AddGraphVisual(Vector2 graphPosition, float graphPositionHeight)
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
            rectTransform.sizeDelta = new Vector2(2, 2);
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
            rectTransform.sizeDelta = new Vector2(distance, 2f);
            rectTransform.anchoredPosition = dotPositionA + direction * distance * .5f;
            rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(direction));
            return gameObject;
        }
    }
}
