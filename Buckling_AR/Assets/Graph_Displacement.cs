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


public class Graph_Displacement : MonoBehaviour
{
    static int boundarycondition1 = BoundaryConditionPage.Parameter1;
    static int section1 = SectionPage.Parameter1;
    static int length1 = LengthPage.Parameter1;
    static int bracing1 = BracingPage.Parameter1;

    static int boundarycondition2 = BoundaryConditionPage.Parameter2;
    static int section2 = SectionPage.Parameter2;
    static int length2 = LengthPage.Parameter2;
    static int bracing2 = BracingPage.Parameter2;

    static string dataLocation = PreGamePage.dataLocation;

    static int index1 = Column1.index;
    static int index2 = Column2.index;

    public Font Font;
    private static Graph_Displacement instance;
    [SerializeField] private Sprite dotSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private List<GameObject> gameObjectsList;
    private GameObject tooltipGameObject;


    private static List<float> valueList1 = new List<float> { 0 };
    private static List<float> valueList2 = new List<float> { 0 };

    private IGraphVisual graphVisual1;
    private IGraphVisual graphVisual2;
    private static int maxVisibleValueAmount;
    private Func<float, string> getAxisLabelX;
    private Func<int, string> getAxisLabelY;

    private static StreamReader file1;
    private static StreamReader file2;
    private string[] valueString = new string[3];
    private int fileCount1;
    private int fileCount2;


    //bool Reverse = false;

    GameObject MaxDispGameObject1;
    GameObject MaxDispGameObject2;
    GameObject MaxDisplacementLocationObject1;
    GameObject MaxDisplacementLocationObject2;
    float yValue;


    private void Awake()
    {
        instance = this;
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        gameObjectsList = new List<GameObject>();
        tooltipGameObject = graphContainer.Find("tooltip").gameObject;

        string pathOfFile1 = dataLocation + @"/BoundaryCondition" + boundarycondition1 + @"/Section" + section1 + @"/Length" + length1 + @"/Bracing" + bracing1 + @"/Displacement/" + Graph_Displacement.index1 + ".txt"; ;
        string pathOfFile2 = dataLocation + @"/BoundaryCondition" + boundarycondition2 + @"/Section" + section2 + @"/Length" + length2 + @"/Bracing" + bracing2 + @"/Displacement/" + Graph_Displacement.index2 + ".txt"; ;
        file1 = new StreamReader(pathOfFile1, Encoding.Default);
        file2 = new StreamReader(pathOfFile2, Encoding.Default);

        Graph_Displacement.valueList1 = ChanegeValueList1(Graph_Displacement.index1);
        Graph_Displacement.valueList2 = ChanegeValueList2(Graph_Displacement.index2);

        FileCount();
        ShowMaxDisplacement();

    }


    void Update()
    {
        graphVisual1 = new LineGraphVisual(graphContainer, dotSprite, Color.green, new Color(0, 1, 0, 1));
        graphVisual2 = new LineGraphVisual(graphContainer, dotSprite, Color.red, new Color(1, 0, 0, 1));

        ShowGraph(Graph_Displacement.valueList1, Graph_Displacement.valueList2, this.graphVisual1, this.graphVisual2, -1, (float _i) => Mathf.RoundToInt(_i) + "", (int _i) => _i.ToString());

        ChangeMaxDisplacement();
    }

    public static void Column1Load()
    {
        Graph_Displacement.index1++;
        Graph_Displacement.valueList1 = ChanegeValueList1(Graph_Displacement.index1);
    }

    public static void Column2Load()
    {
        Graph_Displacement.index2++;
        Graph_Displacement.valueList2 = ChanegeValueList2(Graph_Displacement.index2);
    }
    public static void Column1Renew()
    {
        Graph_Displacement.index1 = 1;
        Graph_Displacement.valueList1 = ChanegeValueList1(Graph_Displacement.index1);
    }
    public static void Column2Renew()
    {
        Graph_Displacement.index2 = 1;
        Graph_Displacement.valueList2 = ChanegeValueList2(Graph_Displacement.index2);
    }


    private void FileCount()
    {
        DirectoryInfo File1 = new DirectoryInfo(dataLocation + @"/BoundaryCondition" + boundarycondition1 + @"/Section" + section1 + @"/Length" + length1 + @"/Bracing" + bracing1 + @"/Displacement");
        FileInfo[] files1 = File1.GetFiles("*.txt");
        fileCount1 = files1.Length - 1; 

        DirectoryInfo File2 = new DirectoryInfo(dataLocation + @"/BoundaryCondition" + boundarycondition2 + @"/Section" + section2 + @"/Length" + length2 + @"/Bracing" + bracing2 + @"/Displacement");
        FileInfo[] files2 = File2.GetFiles("*.txt");
        fileCount2 = files2.Length - 1; 
    }
    private static List<float> ChanegeValueList1(int index)
    {
        Graph_Displacement.valueList1.Clear();
        CultureInfo providers = new CultureInfo("en-US");
        NumberStyles styles = NumberStyles.Float;
        string pathOfFile = dataLocation + @"/BoundaryCondition" + boundarycondition1 + @"/Section" + section1 + @"/Length" + length1 + @"/Bracing" + bracing1 + @"/Displacement/" + index + ".txt"; ;
        file1 = new StreamReader(pathOfFile, Encoding.Default);
        string valueLine = file1.ReadLine();

        while (valueLine != null)
        {
            float value = Single.Parse(valueLine, styles, providers);
            Graph_Displacement.valueList1.Add(value);

            valueLine = file1.ReadLine();
        }

        Graph_Displacement.maxVisibleValueAmount = Graph_Displacement.valueList1.Count + Graph_Displacement.valueList2.Count;
        Graph_Displacement.valueList1.Reverse();
        return Graph_Displacement.valueList1;
    }

    private static List<float> ChanegeValueList2(int index)
    {
        Graph_Displacement.valueList2.Clear();
        CultureInfo providers = new CultureInfo("en-US");
        NumberStyles styles = NumberStyles.Float;
        string pathOfFile = dataLocation + @"/BoundaryCondition" + boundarycondition2 + @"/Section" + section2 + @"/Length" + length2 + @"/Bracing" + bracing2 + @"/Displacement/" + index + ".txt"; ;
        file2 = new StreamReader(pathOfFile, Encoding.Default);
        string valueLine = file2.ReadLine();

        while (valueLine != null)
        {
            float value = Single.Parse(valueLine, styles, providers);
            Graph_Displacement.valueList2.Add(value);

            valueLine = file2.ReadLine();
        }

        Graph_Displacement.maxVisibleValueAmount = Graph_Displacement.valueList1.Count + Graph_Displacement.valueList2.Count;
        Graph_Displacement.valueList2.Reverse();
        return Graph_Displacement.valueList2;
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

        MaxDispGameObject2 = new GameObject("MaxDisplacement1", typeof(Text), typeof(Shadow));
        MaxDispGameObject2.transform.SetParent(transform, false);
        MaxDispGameObject2.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 90);
        MaxDispGameObject2.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        MaxDispGameObject2.transform.localPosition = new Vector2(320, -90);
        MaxDispGameObject2.GetComponent<Text>().text = "Max Displacement:" + "\n" + "0 mm";
        MaxDispGameObject2.GetComponent<Text>().font = Font;
        MaxDispGameObject2.GetComponent<Text>().fontStyle = FontStyle.Bold;
        MaxDispGameObject2.GetComponent<Text>().fontSize = 23;
        MaxDispGameObject2.GetComponent<Text>().color = new Color32(255, 0, 0, 255);
        MaxDispGameObject2.GetComponent<Shadow>().effectColor = new Color32(0, 0, 0, 255);
        MaxDispGameObject2.GetComponent<Shadow>().effectDistance = new Vector2(1, -1);

        MaxDisplacementLocationObject2 = new GameObject("MaxDisplacementLocation1", typeof(Text), typeof(Shadow));
        MaxDisplacementLocationObject2.transform.SetParent(transform, false);
        MaxDisplacementLocationObject2.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 90);
        MaxDisplacementLocationObject2.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        MaxDisplacementLocationObject2.transform.localPosition = new Vector2(570, -90);
        MaxDisplacementLocationObject2.GetComponent<Text>().text = "Max Displacement at:" + "\n" + "0 m";
        MaxDisplacementLocationObject2.GetComponent<Text>().font = Font;
        MaxDisplacementLocationObject2.GetComponent<Text>().fontStyle = FontStyle.Bold;
        MaxDisplacementLocationObject2.GetComponent<Text>().fontSize = 23;
        MaxDisplacementLocationObject2.GetComponent<Text>().color = new Color32(255, 0, 0, 255);
        MaxDisplacementLocationObject2.GetComponent<Shadow>().effectColor = new Color32(0, 0, 0, 255);
        MaxDisplacementLocationObject2.GetComponent<Shadow>().effectDistance = new Vector2(1, -1);
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

        float MaxDispacement2 = 0;
        float Max2 = Graph_Displacement.valueList2.Max();
        float Min2 = Graph_Displacement.valueList2.Min();
        if (Mathf.Abs(Max2) > Mathf.Abs(Min2))
        {
            MaxDispacement2 = Max2;
        }
        else
        {
            MaxDispacement2 = Min2;
        }
        MaxDispGameObject2.GetComponent<Text>().text = "Max Displacement : " + "\n" + MaxDispacement2 + " mm";

        float MaxDisplacementLocation2 = (float)Graph_Displacement.valueList2.IndexOf(MaxDispacement2) * length2 * 4 / (Graph_Displacement.valueList2.Count() - 1);
        MaxDisplacementLocationObject2.GetComponent<Text>().text = "Max Displacement at : " + "\n" + MaxDisplacementLocation2 + " m";
    }
   
    private void ShowGraph(List<float> valueList1, List<float> valueList2, IGraphVisual graphVisual1, IGraphVisual graphVisual2, int maxVisibleValueAmount = -1, Func<float, string> getAxisLabelX = null, Func<int, string> getAxisLabelY = null)
    {
        Graph_Displacement.valueList1 = valueList1;
        Graph_Displacement.valueList2 = valueList2;
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
        float ratio2 = 1;

        if (length1 > length2)
        {
            ratio1 = 1;
            ratio2 = 2;
        }
        else if (length1 == length2)
        {
            ratio1 = 1;
            ratio2 = 1;
        }
        else if (length2 > length1)
        {
            ratio1 = 2;
            ratio2 = 1;
        }

        float ySize1 = graphHeight / (Graph_Displacement.valueList1.Count + 1) / ratio1;
        float ySize2 = graphHeight / (Graph_Displacement.valueList2.Count + 1) / ratio2; 

        int yIndex1 = 0;
        int yIndex2 = 0;

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


        for (int j = Mathf.Max(valueList2.Count - maxVisibleValueAmount, 0); j < valueList2.Count; j++)
        {
            float xPosition = ((valueList2[j] - xMinimum) / (xMaximum - xMinimum)) * graphWidth;
            float yPosition = ySize2 + yIndex2 * ySize2;
            //string tooltipText = getAxisLabelX(valueList2[j]);

            gameObjectsList.AddRange(graphVisual2.AddGraphVisual(new Vector2(xPosition, yPosition), ySize2));


            if (length2 > length1)
            {
                RectTransform labelY = Instantiate(labelTemplateY);
                labelY.SetParent(graphContainer);
                labelY.gameObject.SetActive(true);
                labelY.anchoredPosition3D = new Vector3(-20f, yPosition + 1f, 0f);

                if (j % 5 == 0)
                {
                    decimal yValue = decimal.Round((decimal)(float.Parse(getAxisLabelY(j)) * length2 * 4 / (valueList2.Count - 1)), 1);
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

            yIndex2++;
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
