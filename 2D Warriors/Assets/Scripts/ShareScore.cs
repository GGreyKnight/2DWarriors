using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareScore : MonoBehaviour
{
    public LadderBoard tablica;

    string TWITTER_ADDRESS = "https://twitter.com/intent/tweet";
    string TWEET_LANGUAGE = "en";
    string text_to_display = "Hey guys! Check out my highest score on Warriors 2D: ";

    public void shareScoreOnTwitter()
    {
        Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(text_to_display) + tablica.highScoreValues[0] + "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }

}
