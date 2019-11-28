using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    public void HighlightOn()
    {
        GetComponent<Renderer>().material.color = Color.magenta;
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
