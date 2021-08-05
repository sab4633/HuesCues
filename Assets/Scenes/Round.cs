using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{

    Text cuegiver;
    Text turntracker;
    Text cue;
    string[] players = { "Player1", "Player2", "Player3" };
    int currentPlayer;
    int playerCount;
    int round;
    int maxrounds;
    Vector3 baseCoordinates = new Vector3(-4.17f, 2.41f ,1f);
    float xdiff = 0.483f;
    float ydiff = 0.455f;
    Dictionary<string, int> alph = new Dictionary<string, int>();
    SpriteRenderer[] playerSprites = new SpriteRenderer[3];


    CardScript cs;

    // Start is called before the first frame update
    void Start()
    {
        alph.Add("A", 0); alph.Add("B", 1); alph.Add("C", 2); alph.Add("D", 3);
        alph.Add("E", 4); alph.Add("F", 5); alph.Add("G", 6); alph.Add("H", 7);
        alph.Add("I", 8); alph.Add("J", 9); alph.Add("L", 10); alph.Add("M", 11);
        alph.Add("N", 12); alph.Add("O", 13); alph.Add("P", 14);
        currentPlayer = 0;
        playerCount = players.Length;
        round = 0;
        maxrounds = playerCount * 2;
        cuegiver = GameObject.Find("cuegiver").GetComponent<Text>();
        turntracker = GameObject.Find("turntracker").GetComponent<Text>();
        cue = GameObject.Find("cue").GetComponent<Text>();
        cuegiver.text = "Cuegiver: " + players[currentPlayer];
        turntracker.text = players[currentPlayer]+" prep";
        cs = GameObject.Find("Card").GetComponent<CardScript>();

        playerSprites[0] = GameObject.Find("p1").GetComponent<SpriteRenderer>();
        playerSprites[1] = GameObject.Find("p2").GetComponent<SpriteRenderer>();
        playerSprites[2] = GameObject.Find("p3").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && turntracker.text.Contains("give cue"))
        {
            nextPlayer();
        }

        if (Input.GetMouseButtonDown(0) && turntracker.text.Contains("turn"))
        {
            Texture2D MyTexture = ScreenCapture.CaptureScreenshotAsTexture();
            var selectedColor = MyTexture.GetPixel((int)Input.mousePosition.x,
                                                   (int)Input.mousePosition.y);
            var key = cs.Guess(selectedColor);
            if (!key.Equals(""))
            {
                playerSprites[currentPlayer].transform.position = new Vector3(
                    baseCoordinates.x+(xdiff* (int.Parse(key.Substring(1))-1)),
                    baseCoordinates.y-(ydiff* alph[key.Substring(0, 1)]),
                    1f);
                //playerSprites[currentPlayer].color = Color.blue;
                nextPlayer();
            }

            
        }
    }

    public void StartRound()
    {
        turntracker.text = players[currentPlayer]+" give cue";
        round++;
    }

    void nextPlayer()
    {
        currentPlayer++;
        currentPlayer %= playerCount;
        turntracker.text = players[currentPlayer] + "'s turn";
    }

}
