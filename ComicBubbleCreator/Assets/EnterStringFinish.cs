using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterStringFinish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishString()
    {
        Utilities.SearchChild("BubbleText", GameObject.Find("BubbleCanvas")).GetComponent<BubbleText>().EnterLine(GameObject.Find("LineInput").GetComponent<InputField>().text);
        this.transform.parent.GetComponent<MyCanvasUtility>().Hide();
    }
}
