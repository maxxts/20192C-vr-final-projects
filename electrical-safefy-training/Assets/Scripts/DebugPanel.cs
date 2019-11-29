using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
    private Text output;

    // Start is called before the first frame update
    void Start()
    {
        output = GetComponentInChildren<Text>();
    }

    public void print(string text)
    {
        output.text = text;
    }
}
