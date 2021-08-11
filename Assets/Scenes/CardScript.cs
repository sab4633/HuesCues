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
        COLORDICT.Add("H1", new Color(252f / 255f, 208f / 255f, 23f / 255f, 1f));
        COLORDICT.Add("I1", new Color(252f / 255f, 225f / 255f, 24f / 255f, 1f));
        COLORDICT.Add("J1", new Color(249f / 255f, 236f / 255f, 36f / 255f, 1f));
        COLORDICT.Add("K1", new Color(246f / 255f, 239f / 255f, 60f / 255f, 1f));
        COLORDICT.Add("L1", new Color(241f / 255f, 236f / 255f, 33f / 255f, 1f));
        COLORDICT.Add("M1", new Color(224f / 255f, 227f / 255f, 32f / 255f, 1f));
        COLORDICT.Add("N1", new Color(194f / 255f, 216f / 255f, 45f / 255f, 1f));
        COLORDICT.Add("O1", new Color(158f / 255f, 196f / 255f, 57f / 255f, 1f));
        COLORDICT.Add("P1", new Color(123f / 255f, 165f / 255f, 65f / 255f, 1f));

        COLORDICT.Add("A2", new Color(107f / 255f, 39f / 255f, 16f / 255f, 1f));
        COLORDICT.Add("B2", new Color(148f / 255f, 68f / 255f, 31f / 255f, 1f));
        COLORDICT.Add("C2", new Color(172f / 255f, 91f / 255f, 38f / 255f, 1f));
        COLORDICT.Add("D2", new Color(215f / 255f, 130f / 255f, 40f / 255f, 1f));
        COLORDICT.Add("E2", new Color(241f / 255f, 153f / 255f, 30f / 255f, 1f));
        COLORDICT.Add("F2", new Color(252f / 255f, 177f / 255f, 34f / 255f, 1f));
        COLORDICT.Add("G2", new Color(253f / 255f, 192f / 255f, 41f / 255f, 1f));
        COLORDICT.Add("H2", new Color(254f / 255f, 205f / 255f, 42f / 255f, 1f));
        COLORDICT.Add("I2", new Color(252f / 255f, 220f / 255f, 39f / 255f, 1f));
        COLORDICT.Add("J2", new Color(249f / 255f, 235f / 255f, 42f / 255f, 1f));
        COLORDICT.Add("K2", new Color(246f / 255f, 239f / 255f, 63f / 255f, 1f));
        COLORDICT.Add("L2", new Color(240f / 255f, 235f / 255f, 45f / 255f, 1f));
        COLORDICT.Add("M2", new Color(219f / 255f, 225f / 255f, 39f / 255f, 1f));
        COLORDICT.Add("N2", new Color(189f / 255f, 214f / 255f, 48f / 255f, 1f));
        COLORDICT.Add("O2", new Color(154f / 255f, 196f / 255f, 60f / 255f, 1f));
        COLORDICT.Add("P2", new Color(118f / 255f, 169f / 255f, 64f / 255f, 1f));

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
