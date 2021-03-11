using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageThumbnailMaker : MonoBehaviour
{
    public GameObject imagePrefab;

    public int numColumns;
    public int numRows;
    public float xGap;
    public float yGap;

    // Start is called before the first frame update
    void Start()
    {
        List<Sprite> allImages = GameObject.Find("ImageHolder").GetComponent<ImageHolder>().GetAllImages();

        Vector3 instantiatePos = this.gameObject.transform.position;

        int picNum = 0;

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numColumns; j++)
            {
                if (picNum < allImages.Count)
                {
                    GameObject newThumbnail = Instantiate(imagePrefab, instantiatePos, Quaternion.identity);
                    newThumbnail.GetComponent<SpriteRenderer>().sprite = allImages[picNum];
                    picNum++;

                    instantiatePos.x += xGap;
                }
            }

            instantiatePos.x = this.gameObject.transform.position.x;
            instantiatePos.y -= yGap;
        }

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
