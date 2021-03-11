using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExportButton : MonoBehaviour
{
    private bool _startTimer = false;
    private float _timer = 0.0f;
    private float _returnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_startTimer)
        {
            _timer += Time.deltaTime;
            if (_timer>=_returnTime)
            {
                Utilities.SearchChild("BackToTweak", this.gameObject).SetActive(true);
                Utilities.SearchChild("NewLine", this.gameObject).SetActive(true);
                Utilities.SearchChild("Export", this.gameObject).SetActive(true);
                _startTimer = false;
            }
        }
    }

    public void OnExportButtonClicked()
    {
        Utilities.SearchChild("BackToTweak", this.gameObject).SetActive(false);
        Utilities.SearchChild("NewLine", this.gameObject).SetActive(false);
        Utilities.SearchChild("Export", this.gameObject).SetActive(false);
        this.gameObject.GetComponent<ScreenshotCompanion>().LeiasTakeScreenshot();

        _startTimer = true;
    }
}
