using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScaleandRotateSlider : MonoBehaviour
{
    //we need two sliders
    private Slider scaleSlider;
    private Slider rotateSlider;

    //we need min and max value of each slider
    public float scaleMinValue;
    public float scaleMaxValue;

    public float rotateMinValue;
    public float rotateMaxValue;

    void Start()
    {
        // find the sliders by name
        //initialize the min and max value when starting
        //add a listener to the slider when the value is changed

        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        scaleSlider.minValue = scaleMinValue;
        scaleSlider.maxValue = scaleMaxValue;
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        rotateSlider = GameObject.Find("RotateSlider").GetComponent<Slider>();
        rotateSlider.minValue = rotateMinValue;
        rotateSlider.maxValue = rotateMaxValue;
        rotateSlider.onValueChanged.AddListener(RotateSliderUpdate);
    }
    void ScaleSliderUpdate(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }
    void RotateSliderUpdate(float value)
    {
        transform.localEulerAngles = new Vector3(transform.rotation.x, value, transform.rotation.z);
    }

}
