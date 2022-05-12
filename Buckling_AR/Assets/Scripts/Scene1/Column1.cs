using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;



[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class Column1 : MonoBehaviour
{
    public static int boundarycondition = BoundaryConditionPage.Parameter1;
    public static int section = SectionPage.Parameter1;
    public static int length = LengthPage.Parameter1;
    public static int bracing = BracingPage.Parameter1;

    static public int index = 1;
    public static string dataLocation = PreGamePage.dataLocation; 
    public static string dataConnectivity = dataLocation + @"/BoundaryCondition" + boundarycondition + @"/Section" + section + @"/Length" + length + @"/Bracing" + bracing + @"/connectivity.txt";
    public static string dataOriginal = dataLocation + @"/BoundaryCondition" + boundarycondition + @"/Section" + section + @"/Length" + length + @"/Bracing" + bracing + @"/1.txt";
    public static int elementNumber = CalculateLine(dataConnectivity);
    public static int pointNumber = CalculateLine(dataOriginal);

    float[] stressArray; //# element
    public static float[] pointStressArray = new float[pointNumber]; //# points
    private static int fileCount;

    static public float color1_Bottom;
    static public float color1_Top;
    static public float color2_Bottom;
    static public float color2_Top;
    static public float color3_Bottom;
    static public float color3_Top;
    static public float color4_Bottom;
    static public float color4_Top;
    static public float color5_Bottom;
    static public float color5_Top;
    static public float color6_Bottom;
    static public float color6_Top;
    static public float color7_Bottom;
    static public float color7_Top;
    static public float color8_Bottom;
    static public float color8_Top;
    static public float color9_Bottom;
    static public float color9_Top;
    static public float color10_Bottom;
    static public float color10_Top;

    public static Color32 color0 = new Color32(255, 255, 255, 255); //white;
    public static Color32 color1 = new Color32(0, 0, 255, 255); //Blue;
    public static Color32 color2 = new Color32(65, 105, 225, 255); //RoyalBlue;
    public static Color32 color3 = new Color32(0, 191, 255, 255); //DeepSkyBlue;
    public static Color32 color4 = new Color32(0, 250, 154, 255); //MedianSpringGreen;
    public static Color32 color5 = new Color32(124, 252, 0, 255); //LawnGreen;
    public static Color32 color6 = new Color32(0, 255, 0, 255); //Lime;
    public static Color32 color7 = new Color32(173, 255, 47, 255); //GreenYellow;
    public static Color32 color8 = new Color32(255, 215, 0, 255); //Gold;
    public static Color32 color9 = new Color32(255, 140, 0, 255); //DarkOrange;
    public static Color32 color10 = new Color32(255, 0, 0, 255); //Red;

    Mesh mesh;
    public static List<Vector3> vertices;
    public static List<int> triangles;
    public static Color32[] colors;

    public void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        DirectoryInfo File = new DirectoryInfo(dataLocation + @"/BoundaryCondition" + boundarycondition + @"/Section" + section + @"/Length" + length + @"/Bracing" + bracing);
        FileInfo[] files = File.GetFiles("*.txt");
        fileCount = files.Length - 2;

        CreateElementStressArray(1);
        CreateTriangle(boundarycondition, section, length, bracing);
        MeshData(boundarycondition, section, length, bracing, index);
    }

    public void Update()
    {
        CreateElementStressArray(index);
        CreatePointStressArray();

        MeshData(boundarycondition, section, length, bracing, index);
        ChangeStressColor();
        CreateMesh();
        print(vertices.Count);
    }


    public static void Renew()
    {
        index = 1;
    }

    public static void Load()
    {
        if (Column1.index < Column1.fileCount)
        {
            Column1.index++;
        }
    }


    void CreateTriangle(int boundarycondition, int section, int length, int bracing)
    {
        StreamReader streamreaderConnectivity = new StreamReader(dataConnectivity, Encoding.Default);
        string String1 = streamreaderConnectivity.ReadLine();
        string[] StringArray = new string[8];
        triangles = new List<int>();
        int elementNum = 0;

        while (String1 != null)
        {
            StringArray = String1.Split(',');

            for (int k = 0; k < StringArray.Length; k++)
            {
                pointStressArray[Convert.ToInt32(StringArray[k]) - 1] = stressArray[elementNum];
            }


            int[][] faceTriangles =
            {
                new int[]{Convert.ToInt32(StringArray[4]) - 1, Convert.ToInt32(StringArray[5]) - 1, Convert.ToInt32(StringArray[1]) - 1, Convert.ToInt32(StringArray[0]) - 1},
                new int[]{Convert.ToInt32(StringArray[5]) - 1, Convert.ToInt32(StringArray[6]) - 1, Convert.ToInt32(StringArray[2]) - 1, Convert.ToInt32(StringArray[1]) - 1},
                new int[]{Convert.ToInt32(StringArray[6]) - 1, Convert.ToInt32(StringArray[7]) - 1, Convert.ToInt32(StringArray[3]) - 1, Convert.ToInt32(StringArray[2]) - 1},
                new int[]{Convert.ToInt32(StringArray[7]) - 1, Convert.ToInt32(StringArray[4]) - 1, Convert.ToInt32(StringArray[0]) - 1, Convert.ToInt32(StringArray[3]) - 1},
                new int[]{Convert.ToInt32(StringArray[7]) - 1, Convert.ToInt32(StringArray[6]) - 1, Convert.ToInt32(StringArray[5]) - 1, Convert.ToInt32(StringArray[4]) - 1},
                new int[]{Convert.ToInt32(StringArray[0]) - 1, Convert.ToInt32(StringArray[1]) - 1, Convert.ToInt32(StringArray[2]) - 1, Convert.ToInt32(StringArray[3]) - 1},
            };
            for (int i = 0; i < 6; i++)
            {
                triangles.Add(faceTriangles[i][0]);
                triangles.Add(faceTriangles[i][1]);
                triangles.Add(faceTriangles[i][2]);
                triangles.Add(faceTriangles[i][0]);
                triangles.Add(faceTriangles[i][2]);
                triangles.Add(faceTriangles[i][3]);
            }
            String1 = streamreaderConnectivity.ReadLine();
            elementNum++;
        }
        streamreaderConnectivity.Close();
    }



    void MeshData(int boundarycondition, int section, int length, int bracing, int index)
    {
        var data = dataLocation + @"/BoundaryCondition" + boundarycondition + @"/Section" + section + @"/Length" + length + @"/Bracing" + bracing + @"/" + index + @".txt";

        StreamReader streamReader = new StreamReader(data, Encoding.Default);

        string eachLine = streamReader.ReadLine();
        string[] StringArray = new string[3];
        vertices = new List<Vector3>();

        int k = 0;
        while (eachLine != null)
        {
            StringArray = eachLine.Split(',');

            CultureInfo providers = new CultureInfo("en-US");
            NumberStyles styles = NumberStyles.Float;

            float a = Single.Parse(StringArray[0], styles, providers);
            float b = Single.Parse(StringArray[1], styles, providers);
            float c = Single.Parse(StringArray[2], styles, providers);
            vertices.Add(new Vector3(a, c, b));

            k++;
            eachLine = streamReader.ReadLine();
        }
        streamReader.Close();

    }
    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.colors32 = colors;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
    public static int CalculateLine(string path)
    {
        Stopwatch stopwatch = new Stopwatch();
        StreamReader LineCount = new StreamReader(path, Encoding.Default);

        int Lines = 0;
        stopwatch.Restart();
        using (LineCount)
        {
            var lines = "";
            while ((lines = LineCount.ReadLine()) != null)
            {
                Lines++;
            }
        }
        stopwatch.Stop();

        return Lines;
    }

    void CreateElementStressArray(int elementIndex)
    {
        int elementNumberTotal = CalculateLine(dataConnectivity); //3600
        stressArray = new float[elementNumberTotal];

        var data = dataLocation + @"/BoundaryCondition" + boundarycondition + @"/Section" + section + @"/Length" + length + @"/Bracing" + bracing + @"/Zstress/" + elementIndex + @".txt";
        StreamReader stressLine = new StreamReader(data, Encoding.Default);
        string StressLine = stressLine.ReadLine();

        for (int i = 0; i < elementNumberTotal; i++)
        {
            stressArray[i] = float.Parse(StressLine);
            StressLine = stressLine.ReadLine();
        }
        stressLine.Close();
    }


    void CreatePointStressArray()
    {
        StreamReader streamreaderConnectivity = new StreamReader(dataConnectivity, Encoding.Default);
        string String1 = streamreaderConnectivity.ReadLine();
        string[] StringArray = new string[8];

        int elementNum = 0;

        while (String1 != null)
        {
            StringArray = String1.Split(',');

            for (int k = 0; k < StringArray.Length; k++)
            {
                pointStressArray[Convert.ToInt32(StringArray[k]) - 1] = stressArray[elementNum];
            }

            String1 = streamreaderConnectivity.ReadLine();
            elementNum++;
        }
        streamreaderConnectivity.Close();
    }


    public static void ChangeStressColor()
    {
        // color ref: https://www.chai3d.org/download/doc/html/chapter14-colors.html
        float Max = 0;
        float Min = 0;
        for (int k = 0; k < pointStressArray.Length; k++)
        {
            if (pointStressArray[k] > Max)
            {
                Max = pointStressArray[k];
            }
            if (pointStressArray[k] < Min)
            {
                Min = pointStressArray[k];
            }
        }
        float intervalNumber = 10f;
        float intervalValue = (Max - Min) / intervalNumber;

        color1_Bottom = Min;
        color1_Top = Min + intervalValue * 1;
        color2_Bottom = color1_Top;
        color2_Top = Min + intervalValue * 2;
        color3_Bottom = color2_Top;
        color3_Top = Min + intervalValue * 3;
        color4_Bottom = color3_Top;
        color4_Top = Min + intervalValue * 4;
        color5_Bottom = color4_Top;
        color5_Top = Min + intervalValue * 5;
        color6_Bottom = color5_Top;
        color6_Top = Min + intervalValue * 6;
        color7_Bottom = color6_Top;
        color7_Top = Min + intervalValue * 7;
        color8_Bottom = color7_Top;
        color8_Top = Min + intervalValue * 8;
        color9_Bottom = color8_Top;
        color9_Top = Min + intervalValue * 9;
        color10_Bottom = color9_Top;
        color10_Top = Min + intervalValue * 10;


        colors = new Color32[vertices.Count];

        for (int i = 0; i < vertices.Count; i += 1)
        {
            float value = pointStressArray[i];
            if (value == 0f)
            {
                colors[i] = color0;
            }
            else if (value > color1_Bottom && value <= color1_Top)
            {
                colors[i] = Color32.Lerp(color0, color1, vertices[i].y);
            }
            else if (value > color2_Bottom && value <= color2_Top)
            {
                colors[i] = Color32.Lerp(color1, color2, vertices[i].y);
            }
            else if (value > color3_Bottom && value <= color3_Top)
            {
                colors[i] = Color32.Lerp(color2, color3, vertices[i].y);
            }
            else if (value > color4_Bottom && value <= color4_Top)
            {
                colors[i] = Color32.Lerp(color3, color4, vertices[i].y);
            }
            else if (value > color5_Bottom && value <= color5_Top)
            {
                colors[i] = Color32.Lerp(color4, color5, vertices[i].y);
            }
            else if (value > color6_Bottom && value <= color6_Top)
            {
                colors[i] = Color32.Lerp(color5, color6, vertices[i].y);
            }
            else if (value > color7_Bottom && value <= color7_Top)
            {
                colors[i] = Color32.Lerp(color6, color7, vertices[i].y);
            }
            else if (value > color8_Bottom && value <= color8_Top)
            {
                colors[i] = Color32.Lerp(color7, color8, vertices[i].y);
            }
            else if (value > color9_Bottom && value <= color9_Top)
            {
                colors[i] = Color32.Lerp(color8, color9, vertices[i].y);
            }
            else if (value > color10_Bottom && value <= color10_Top)
            {
                colors[i] = Color32.Lerp(color9, color10, vertices[i].y);
            }

        }
    }
}
