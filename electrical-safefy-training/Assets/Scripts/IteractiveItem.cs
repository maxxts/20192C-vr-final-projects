using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IteractiveItem : MonoBehaviour
{
    public void HighlightOn()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void HighlightOff()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }


    public void Interact()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
