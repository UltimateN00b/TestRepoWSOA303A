using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bubble : MonoBehaviour
{
    private float _padding = 0.3f;
    private float _margin = -9f;
    // Start is called before the first frame update
    void Start()
    {
        Utilities.SearchChild("PaddingInput", GameObject.Find("TweakTextCanvas")).GetComponent<TMP_InputField>().text = _padding.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdaptBubble(Vector3 position, Vector3 scale, Vector2 sizeDelta, Quaternion rotation)
    {
        _padding = float.Parse(Utilities.SearchChild("PaddingInput", GameObject.Find("TweakTextCanvas")).GetComponent<TMP_InputField>().text);

        _padding = 1 / _padding;

        position.y += _margin;

        RectTransform bubbleRect = this.gameObject.GetComponent<RectTransform>();

        scale.x = scale.x + (scale.x/_padding);
        scale.y = scale.y + (scale.y/_padding);
        scale.z = scale.z + (scale.z/_padding);

        bubbleRect.position = position;
        bubbleRect.localScale = scale;
        bubbleRect.sizeDelta = sizeDelta;
        bubbleRect.rotation = rotation;
    }
}
