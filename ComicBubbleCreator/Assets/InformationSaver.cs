using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationSaver : MonoBehaviour
{
    private static Sprite currImage;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static void SetCurrImage(Sprite s)
    {
        currImage = s;
    }

    public static Sprite GetCurrImage()
    {
        return currImage;
    }
}
