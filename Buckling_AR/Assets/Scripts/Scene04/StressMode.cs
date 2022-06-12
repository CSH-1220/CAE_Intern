using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressMode : MonoBehaviour
{
    public Material NormalMaterialForColumn1;
    public Material NormalMaterialForColumn2;
    public Material StressMaterial;
    public GameObject Column1;
    public GameObject Column2;
    public GameObject ColorPanel1;
    public GameObject ColorPanel2;

    private bool OnColumn1 = false;
    private bool OnColumn2 = false;

    public void Start()
    {
        Column1.GetComponent<Renderer>().material = NormalMaterialForColumn1;
        Column2.GetComponent<Renderer>().material = NormalMaterialForColumn2;
        ColorPanel1.SetActive(false);
        ColorPanel2.SetActive(false);
    }

    public void StressModeForColumn1()
    {
        if (OnColumn1 == false)
        {
            Column1.GetComponent<Renderer>().material = StressMaterial;
            ColorPanel1.SetActive(true);
            OnColumn1 = true;
        }

        else
        {
            Column1.GetComponent<Renderer>().material = NormalMaterialForColumn1;
            ColorPanel1.SetActive(false);
            OnColumn1 = false;
        }
    }

    public void StressModeForColumn2()
    {
        if (OnColumn2 == false)
        {
            Column2.GetComponent<Renderer>().material = StressMaterial;
            ColorPanel2.SetActive(true);
            OnColumn2 = true;
        }

        else
        {
            Column2.GetComponent<Renderer>().material = NormalMaterialForColumn2;
            ColorPanel2.SetActive(false);
            OnColumn2 = false;
        }
    }
}
