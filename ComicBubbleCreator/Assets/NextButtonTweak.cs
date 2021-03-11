using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonTweak : MonoBehaviour
{
    public float bubbleRescale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNextButtonTweakPressed()
    {
        GameObject bubbleCanvas = GameObject.Find("BubbleCanvas");

        MyCanvasUtility bubbleCanvasUtility = bubbleCanvas.GetComponent<MyCanvasUtility>();

        Utilities.SearchChild("MoveTextUp", bubbleCanvas).SetActive(false);
        Utilities.SearchChild("MoveTextDown", bubbleCanvas).SetActive(false);
        bubbleCanvasUtility.ScaleAllChildren(bubbleRescale);
        //bubbleCanvasUtility.PositionAllChildren(bubbleReposition);

        this.transform.parent.GetComponent<MyCanvasUtility>().Hide();
        GameObject.Find("ExportCanvas").GetComponent<MyCanvasUtility>().Show();
    }
}
