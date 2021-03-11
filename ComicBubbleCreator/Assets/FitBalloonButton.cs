using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FitBalloonButton : MonoBehaviour
{

    public void FitBalloon()
    {
        string line = Utilities.SearchChild("TweakField", GameObject.Find("TweakTextCanvas")).GetComponent<TMP_InputField>().text;
        Utilities.SearchChild("BubbleText", GameObject.Find("BubbleCanvas")).GetComponent<BubbleText>().AdjustBalloonText(line);
    }
}
