using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    // public Light light;

    void Start()
    {
        // Debug.Log(GetComponent<Light>().color);
        // GetComponent<Light>().color =  Color.blue;
        // Debug.Log(GetComponent<Light>().color);
        // lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeColor1()
    {
        if (GetComponent<Light>().color == Color.red)
        {
            GetComponent<Light>().color = Color.white;
        }
        if (GetComponent<Light>().color == Color.white)
        {
            GetComponent<Light>().color = Color.red;
        }
    }

    void changeColor2()
    {
        if (GetComponent<Light>().color == Color.red)
        {
            GetComponent<Light>().color = Color.white;
        }
        if (GetComponent<Light>().color == Color.white)
        {
            GetComponent<Light>().color = Color.red;
        }
    }
}
