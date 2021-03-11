using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToTweak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackButtonPressed()
    {
        GameObject bubbleCanvas = GameObject.Find("BubbleCanvas");

        MyCanvasUtility bubbleCanvasUtility = bubbleCanvas.GetComponent<MyCanvasUtility>();

        Utilities.SearchChild("MoveTextUp", bubbleCanvas).SetActive(true);
        Utilities.SearchChild("MoveTextDown", bubbleCanvas).SetActive(true);

        float bubbleRescale = Utilities.SearchChild("NextButtonTWEAK", GameObject.Find("TweakTextCanvas")).GetComponent<NextButtonTweak>().bubbleRescale;
        bubbleCanvasUtility.ScaleAllChildren(1/bubbleRescale);

        GameObject.Find("TweakTextCanvas").GetComponent<MyCanvasUtility>().Show();
        GameObject.Find("ExportCanvas").GetComponent<MyCanvasUtility>().Hide();
    }
}
