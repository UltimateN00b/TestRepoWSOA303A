using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = InformationSaver.GetCurrImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
