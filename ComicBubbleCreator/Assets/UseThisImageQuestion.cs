using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseThisImageQuestion : MonoBehaviour
{

    public void Yes()
    {
        SceneManager.LoadScene("ComicTextCreator");
    }

    public void No()
    {
        InformationSaver.SetCurrImage(null);
        this.gameObject.SetActive(false);
    }
}
