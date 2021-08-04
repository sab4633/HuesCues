using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Header : MonoBehaviour
{
    Text maintext;
    CardScript cs;
    Round round;
    Button headerButton;
    
    // Start is called before the first frame update
    void Start()
    {
        cs = GameObject.Find("Card").GetComponent<CardScript>();
        round = GameObject.Find("Players").GetComponent<Round>();
      //  headerButton = GameObject.Find("headerButton").GetComponent<Button>();
        maintext = GameObject.Find("maintext").GetComponent<Text>();
        maintext.text = "Draw Card";

    }

    

    
    public void onButton()
    {
        if (maintext.text.Equals("Draw Card"))
        {
            maintext.text = "Select a color";
            cs.NewCard();
        }
        if (maintext.text.Contains("?"))
        {
            maintext.text = "Round Started";
            cs.ClearCard();
            round.StartRound();

        }
    }
}
