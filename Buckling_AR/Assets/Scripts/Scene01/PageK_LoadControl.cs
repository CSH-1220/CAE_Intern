using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageK_LoadControl : MonoBehaviour
{
    public GameObject Fixed_Free_Original;
    public GameObject Fixed_Free_Load;

    public GameObject Fixed_Pinned_Original;
    public GameObject Fixed_Pinned_Load;

    public GameObject Fixed_Fixed_Original;
    public GameObject Fixed_Fixed_Load;

    public GameObject Pinned_Pinned_Original;
    public GameObject Pinned_Pinned_Load;
    public Toggle LoadToggle;

    public void Start()
    {
        Fixed_Free_Load.SetActive(false);
        Pinned_Pinned_Load.SetActive(false);
        Fixed_Pinned_Load.SetActive(false);
        Fixed_Fixed_Load.SetActive(false);
    }
    public void LoadUnload()
    {
        if (LoadToggle.isOn == true)
        {
            Fixed_Free_Original.SetActive(false);
            Fixed_Free_Load.SetActive(true);

            Pinned_Pinned_Original.SetActive(false);
            Pinned_Pinned_Load.SetActive(true);

            Fixed_Pinned_Original.SetActive(false);
            Fixed_Pinned_Load.SetActive(true);

            Fixed_Fixed_Original.SetActive(false);
            Fixed_Fixed_Load.SetActive(true);
        }
        if (LoadToggle.isOn == false)
        {
            Fixed_Free_Original.SetActive(true);
            Fixed_Free_Load.SetActive(false);

            Pinned_Pinned_Original.SetActive(true);
            Pinned_Pinned_Load.SetActive(false);

            Fixed_Pinned_Original.SetActive(true);
            Fixed_Pinned_Load.SetActive(false);

            Fixed_Fixed_Original.SetActive(true);
            Fixed_Fixed_Load.SetActive(false);
        }
    }
}
