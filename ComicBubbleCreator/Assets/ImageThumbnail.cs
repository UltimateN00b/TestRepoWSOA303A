using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageThumbnail : MonoBehaviour
{
    private static GameObject _useThisImageQuestion;

    public Color mouseOverColour;
    public Color clickColour;

    // Start is called before the first frame update
    void Start()
    {
        if (_useThisImageQuestion == null)
        {
            _useThisImageQuestion = GameObject.Find("UseThisImageQuestion");
            _useThisImageQuestion.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        this.GetComponent<SpriteRenderer>().color = mouseOverColour;
    }

    private void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().color = clickColour;
        OnThumbnailClicked();
    }

    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnThumbnailClicked()
    {
        InformationSaver.SetCurrImage(this.GetComponent<SpriteRenderer>().sprite);
        _useThisImageQuestion.SetActive(true);
    }
}
