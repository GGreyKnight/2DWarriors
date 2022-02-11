using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LadderBoard : MonoBehaviour
{
    public Text[] highScores;
    public int[] highScoreValues;
    string[] highScoreNames;

    // Start is called before the first frame update
    void Start()
    {
        highScoreValues = new int[highScores.Length];
        highScoreNames = new string[highScores.Length];
        for(int x=0;x<highScores.Length;x++)
        {
            highScoreValues[x] = PlayerPrefs.GetInt("highScoreValues" + x);
            highScoreNames[x] = PlayerPrefs.GetString("highScoreNames" + x);
        }
        DrawScores();
    }

    void SaveScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            PlayerPrefs.SetInt("highScoreValues" + x, highScoreValues[x]);
            PlayerPrefs.SetString("highScoreNames" + x, highScoreNames[x]);
        }
    }

    public void DrawScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            highScores[x].text = highScoreNames[x] + ":" + highScoreValues[x].ToString();
        }
    }

    public void CheckForHighScore(int _value, string _userName)
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            if(_value > highScoreValues[x])
            {
                for(int y=highScores.Length - 1;y>x;y--)
                {
                    highScoreValues[y] = highScoreValues[y - 1];
                    highScoreNames[y] = highScoreNames[y - 1];
                }
                highScoreValues[x] = _value;
                highScoreNames[x] = _userName;
                DrawScores();
                SaveScores();
                break;
            }
        }
    }

    public bool CheckIfHighScore(int _value)
    {
        if (_value > highScoreValues[highScoreValues.Length-1])
        {
            return true;
        }
        return false;
    }

    int returnFirstScore()
    {
        return highScoreValues[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
