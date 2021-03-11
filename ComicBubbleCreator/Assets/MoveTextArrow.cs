using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTextArrow : MonoBehaviour
{
    public void MoveArrowVertically (float interval)
    {
        GameObject bubble = Utilities.SearchChild("BubbleText", GameObject.Find("BubbleCanvas"));

        Vector3 bubblePos = bubble.GetComponent<RectTransform>().position;
        bubblePos.y += interval;

        bubble.GetComponent<RectTransform>().position = bubblePos;
    }
}
