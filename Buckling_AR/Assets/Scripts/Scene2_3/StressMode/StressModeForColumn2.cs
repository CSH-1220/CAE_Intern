using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressModeForColumn2 : MonoBehaviour
{
    public Material NormalMaterialForColumn2;
    public Material StressMaterial;
    public GameObject Column2;
    public GameObject ColorPanel2;
    private bool OnColumn2 = false;
    public void Start()
    {
        Column2.GetComponent<Renderer>().material = NormalMaterialForColumn2;
        ColorPanel2.SetActive(false);

    }
    public void StressModeColumn1()
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
