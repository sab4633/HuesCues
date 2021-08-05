using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    SpriteRenderer sprite;
    SpriteRenderer[] squares = new SpriteRenderer[4];
    Text[] labels = new Text[4];
    Dictionary<string, Color> COLORDICT = new Dictionary<string, Color>();
    Dictionary<string, Color> currentCard = new Dictionary<string, Color>();
    Color selectedColor;
    string selectedLabel;
    Text maintext;
    string[] keyArray;
    



    void Start()
    {
        //set up spriterenders for card colors
        squares[0] = GameObject.Find("color1").GetComponent<SpriteRenderer>();
        squares[1] = GameObject.Find("color2").GetComponent<SpriteRenderer>();
        squares[2] = GameObject.Find("color3").GetComponent<SpriteRenderer>();
        squares[3] = GameObject.Find("color4").GetComponent<SpriteRenderer>();

        //adding labels for each color
        labels[0] = GameObject.Find("text1").GetComponent<Text>();
        labels[1] = GameObject.Find("text2").GetComponent<Text>();
        labels[2] = GameObject.Find("text3").GetComponent<Text>();
        labels[3] = GameObject.Find("text4").GetComponent<Text>();



        //setup colors for board
        COLORDICT.Add("A1", new Color(97f / 255f, 43f / 255f, 15f / 255f, 1f));
        COLORDICT.Add("B1",new Color(136f / 255f, 75f / 255f, 31f / 255f, 1f));
        COLORDICT.Add("C1", new Color(166f / 255f, 97f / 255f, 40f / 255f, 1f));
        COLORDICT.Add("D1", new Color(201f / 255f, 130f / 255f, 42f / 255f, 1f));
        COLORDICT.Add("E1", new Color(230f / 255f, 156f / 255f, 35f / 255f, 1f));
        COLORDICT.Add("F1", new Color(254f / 255f, 180f / 255f, 21f / 255f, 1f));
        COLORDICT.Add("G1", new Color(253f / 255f, 193f / 255f, 19f / 255f, 1f));


        keyArray = COLORDICT.Keys.ToArray();
        maintext = GameObject.Find("maintext").GetComponent<Text>();
        




        //sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && maintext.text.Equals("Select a color"))
        {
            Texture2D MyTexture = ScreenCapture.CaptureScreenshotAsTexture();
            selectedColor = MyTexture.GetPixel((int)Input.mousePosition.x,
                                                   (int)Input.mousePosition.y);
            for(int i =0;i<4;i++)
            {
                if(squares[i].color == selectedColor)
                {
                    selectedLabel = labels[i].text;
                    maintext.text = "Select "+ selectedLabel + "?";
                }
            }



        }




        // Change the 'color' property of the 'Sprite Renderer'
        //sprite.color = Color.blue;


    }

    public void NewCard()
    {
        currentCard = new Dictionary<string, Color>();
        while(currentCard.Count < 4) 
        {
            var randomKey = keyArray[Random.Range(0, COLORDICT.Keys.Count)];
            if (!currentCard.ContainsKey(randomKey))
            {
                squares[currentCard.Count].color = COLORDICT[randomKey];
                labels[currentCard.Count].text = randomKey;
                currentCard[randomKey] = COLORDICT[randomKey];
            }
        }
    }

    public void ClearCard()
    {
        for(int i =0; i<4; i++)
        {
            squares[i].color = Color.black;
            labels[i].text = "";
        }
    }

    public string Guess(Color col)
    {
        if (COLORDICT.ContainsValue(col))
        {
            foreach(var key in keyArray)
            {
                if(col == COLORDICT[key])
                {
                    return key;
                }
            }
        }
        return "";
    }




}
