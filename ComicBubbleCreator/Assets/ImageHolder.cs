using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageHolder : MonoBehaviour
{
    public List<Sprite> myImages;

    public List<Sprite> GetAllImages()
    {
        return myImages;
    }
}
