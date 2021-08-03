using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Header : MonoBehaviour
{
    Text maintext;
    CardScript cs;
    Button headerButton;
    
    // Start is called before the first frame update
    void Start()
    {
        cs = GameObject.Find("Card").GetComponent<CardScript>();
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
    }
}
