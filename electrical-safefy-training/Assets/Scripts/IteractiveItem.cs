using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IteractiveItem : MonoBehaviour
{
    public void OnPointerExit()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void OnPointerEnter()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void OnPointerClick()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
