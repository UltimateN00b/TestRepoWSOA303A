using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCanvasUtility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ScaleAllChildren(float scaleIncrease)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;

            Vector3 currScale = currChild.GetComponent<RectTransform>().localScale;

            currChild.GetComponent<RectTransform>().localScale = currScale*scaleIncrease;
        }
    }

    public void PositionAllChildren(Vector3 newPosition)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject currChild = this.transform.GetChild(i).gameObject;

            currChild.GetComponent<RectTransform>().localPosition = newPosition;
        }
    }
}
