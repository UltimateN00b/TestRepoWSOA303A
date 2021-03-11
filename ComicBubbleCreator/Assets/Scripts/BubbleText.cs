using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class BubbleText : MonoBehaviour
{
    private Text _bubbleText;

    private List<float> _idealLineLengths = new List<float>();
    private bool _startLineLengthGeneration = false;
    private int _totalLineLength = -1;
    private int _totalLines;
    private int _linesProcessedCounter;
    private int _interval;
    private string _currentLine;

    // Start is called before the first frame update
    void Start()
    {
        _bubbleText = this.gameObject.GetComponent<Text>();
        this.transform.parent.GetComponent<MyCanvasUtility>().Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (_startLineLengthGeneration)
        {
            GenerateLineLengths();
        }
    }

    private int CalculateLengthOfString(string line)
    {
        int totalLength = 0;

        Font myFont = _bubbleText.font;  //chatText is my Text component
        CharacterInfo characterInfo = new CharacterInfo();

        char[] arr = line.ToCharArray();

        foreach (char c in arr)
        {
            if (!c.Equals(' '))
            {
                myFont.RequestCharactersInTexture(c.ToString(), _bubbleText.fontSize, _bubbleText.fontStyle);
                myFont.GetCharacterInfo(c, out characterInfo, _bubbleText.fontSize);
                totalLength += characterInfo.advance;
            }
        }

        return totalLength;
    }

    private List<string> StringToWordList(string line)
    {
        return new List<string>(line.Split(' '));
    }

    private List<float> StringToLengthList(List<string> allWords) //the percentage of the total line's length each word takes up.
    {
        List<float> allLengths = new List<float>();

        foreach (string word in allWords)
        {
            float currWordLength = CalculateLengthOfString(word);
            float currWordPercentage = 100.0f * currWordLength / _totalLineLength;
            allLengths.Add(currWordPercentage);
        }

        return allLengths;
    }

    private void StartLineLengthGeneration(int numLines)
    {
        _currentLine = _bubbleText.text;
        _totalLines = numLines;

        _idealLineLengths.Clear();
        _linesProcessedCounter = 0;
        _interval = 1;
        _startLineLengthGeneration = true;


        float x = 100 / _totalLines;

        for (int i = 0; i < _totalLines; i++)
        {
            _idealLineLengths.Add(x);
        }

        _startLineLengthGeneration = true;
    }

    private void GenerateLineLengths()
    {
        float x = 100 / _totalLines;
        float subNum = x / _totalLines;

        int numToResolve = 0;

        if (_totalLines % 2 == 0)
        {
            numToResolve = ((_totalLines + 1) - 2) * 2;
        }
        else
        {
            numToResolve = (_totalLines - 2) * 2;
        }

        if (_linesProcessedCounter < numToResolve)
        {
            if (_linesProcessedCounter < numToResolve)
            {
                _idealLineLengths[_interval - 1] = _idealLineLengths[_interval - 1] - subNum;
                _linesProcessedCounter++;
            }

            if (_linesProcessedCounter < numToResolve)
            {
                _idealLineLengths[_interval] = _idealLineLengths[_interval] + subNum;
                _linesProcessedCounter++;
            }

            if (_linesProcessedCounter < numToResolve)
            {
                _idealLineLengths[_idealLineLengths.Count - _interval] = _idealLineLengths[_idealLineLengths.Count - _interval] - subNum;
                _linesProcessedCounter++;
            }

            if (_linesProcessedCounter < numToResolve)
            {
                _idealLineLengths[(_idealLineLengths.Count - 1) - _interval] = _idealLineLengths[(_idealLineLengths.Count - 1) - _interval] + subNum;
                _linesProcessedCounter++;
            }

            _interval++;
        }
        else
        {
            foreach (float id in _idealLineLengths)
                Debug.Log("Ideal:" + id);

            List<string> finalLines = GenerateLines(_currentLine);

            int lineCount = 1;

            string finalBalloonText = "";

            foreach (string s in finalLines)
            {
                finalBalloonText += s + "\n";
                Debug.Log("Line " + lineCount + ": " + s);
                lineCount++;
            }

            AdjustBalloonText(finalBalloonText);

            _startLineLengthGeneration = false;
        }
    }

    private List<string> GenerateLines(string line)
    {
        int pos, lineNumber;
        List<string> finalLines = new List<string>(); //where all the lines go
        List<string> allWords = StringToWordList(line);
        List<int> lengthsByWord = GenerateLineLengthsByWord(allWords);

        foreach (int l in lengthsByWord)
            Debug.Log("Length:" + l);

        pos = 0;
        for (lineNumber = 0; lineNumber < _totalLines; lineNumber++)
        {
            var words = allWords.Skip(pos).Take(lengthsByWord[lineNumber]).ToArray();

            finalLines.Add(string.Join(" ", words));

            pos += lengthsByWord[lineNumber];
        }

        return finalLines;
    }

    private int GetNumWordsOnSingleLine(List<string> allWords, int lineNumber)
    {
        List<float> lengths = StringToLengthList(allWords);
        float currIdealLineLength = _idealLineLengths[lineNumber];
        float greaterLength = 0;

        int undershootIndex = 0;

        int numWords = 0;

        Debug.Log("Lengths = " + string.Join(", ",
    new List<float>(lengths)
    .ConvertAll(i => i.ToString())
    .ToArray()));

        for (int i = 0; i < allWords.Count; i++)
        {
            if (greaterLength < currIdealLineLength)
            {
                greaterLength += lengths[i];
                undershootIndex = i;
            }
        }

        float adjustment = greaterLength - currIdealLineLength;
        if (undershootIndex == 0)
        {
            numWords = 1;
        }
        else
        {
            float lesserLength = greaterLength - lengths[undershootIndex];
            float averageDistance = (greaterLength + lesserLength) / 2.0f;
            if (averageDistance > currIdealLineLength)
            {
                numWords = undershootIndex;
                adjustment = lesserLength - currIdealLineLength;
            }
            else
            {
                numWords = undershootIndex + 1;
            }
        }
        Debug.Log("calc: " + lineNumber + ": " + numWords + " : " + adjustment + " : " + greaterLength + ": " + currIdealLineLength);
        // _idealLineLengths[lineNumber + 1] = _idealLineLengths[lineNumber + 1] - adjustment;

        return numWords;
    }

    private List<int> GenerateLineLengthsByWord(List<string> allWords)
    {
        List<int> lineLengthsByWord = new List<int>();

        int numWords;

        _totalLineLength = CalculateLengthOfString(string.Join(" ", allWords));

        for (int i = 0; i < _idealLineLengths.Count - 1; i++)
        {
            numWords = GetNumWordsOnSingleLine(allWords, i);

            allWords = allWords.Skip(numWords).ToList();

            lineLengthsByWord.Add(numWords);
        }

        lineLengthsByWord.Add(allWords.Count);

        return lineLengthsByWord;
    }

    public void AdjustBalloonText(string line)
    {
        line = GenerateEmphasis(line);
        line = line.Trim();
        this.gameObject.GetComponent<Text>().text = line;

        if (this.GetComponent<ContentSizeFitter>() == null)
        {
            ContentSizeFitter textFitter = this.gameObject.AddComponent<ContentSizeFitter>();
            textFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            textFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }

        RectTransform myRect = this.GetComponent<RectTransform>();
        GameObject bubble = Utilities.SearchChild("Bubble", GameObject.Find("BubbleCanvas"));

        Vector2 mySizeDelta = new Vector2(this.gameObject.GetComponent<Text>().preferredWidth, this.gameObject.GetComponent<Text>().preferredHeight);

        bubble.GetComponent<Bubble>().AdaptBubble(myRect.position, myRect.localScale, mySizeDelta, myRect.rotation);

        Utilities.SearchChild("TweakField", GameObject.Find("TweakTextCanvas")).GetComponent<TMP_InputField>().text = line;
    }

    public void EnterLine(string text)
    {
        _bubbleText.text = text;

        string[] allWords = text.Split(' ');
        int numWords = allWords.Count()+1;
        int bestNumLines = 1;

        switch (numWords)
        {
            case 1:
            case 2:
                bestNumLines = numWords;
                break;
            case 3:
            case 4:
                bestNumLines = numWords - 1;
                break;
            case 5:
                bestNumLines = 5;
                break;
            default:
                bestNumLines = Mathf.RoundToInt(numWords * 0.5f);
                break;
        }

        StartLineLengthGeneration(bestNumLines);

        GameObject.Find("TweakTextCanvas").GetComponent<MyCanvasUtility>().Show();
        this.transform.parent.GetComponent<MyCanvasUtility>().Show();
    }

    private string GenerateEmphasis(string text)
    {
        List<string> replaceStrings = new List<string>();

        if (text.Contains("*"))
        {
            string emphasisString = "";
            bool startBolding = false;

            foreach (char c in text.ToCharArray())
            {
                if (c.Equals('*'))
                {
                    startBolding = !startBolding;
                }

                if (startBolding)
                {
                    emphasisString += c;
                }
                else
                {
                    emphasisString += c;

                    if (emphasisString != "")
                    {
                        
                        replaceStrings.Add(emphasisString);
                    }

                    emphasisString = "";
                }
            }

            foreach (string s in replaceStrings)
            {
                if (s.Contains("*"))
                {
                    Debug.Log("REPLACE STRING: " + replaceStrings);
                    string noStarsS = s.Replace("*", "");
                    text = text.Replace(s, "<b><i>" + noStarsS + "</i></b>");
                }
            }
        }

        return text;
    }

    public void RecalculateLines(int numLines)
    {
        _bubbleText.text = _bubbleText.text.Replace("\n", " ");
        StartLineLengthGeneration(numLines);
    }
}
