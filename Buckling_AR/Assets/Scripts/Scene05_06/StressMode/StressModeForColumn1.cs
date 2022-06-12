using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressModeForColumn1 : MonoBehaviour
{
    public Material NormalMaterialForColumn1;
    public Material StressMaterial;
    public GameObject Column1;
    public GameObject ColorPanel1;
    private bool OnColumn1 = false;
    public void Start()
    {
        Column1.GetComponent<Renderer>().material = NormalMaterialForColumn1;
        ColorPanel1.SetActive(false);

    }
    public void StressModeColumn1()
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
}
