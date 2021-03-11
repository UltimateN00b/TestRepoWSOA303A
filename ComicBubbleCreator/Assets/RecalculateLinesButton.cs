using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecalculateLinesButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecalculateLines()
    {
        int numLines = int.Parse(Utilities.SearchChild("LineNumInput", GameObject.Find("TweakTextCanvas")).GetComponent<TMP_InputField>().text);

        Utilities.SearchChild("BubbleText", GameObject.Find("BubbleCanvas")).GetComponent<BubbleText>().RecalculateLines(numLines);
    }
}
