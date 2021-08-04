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
    SpriteRenderer[] playerSprites = new SpriteRenderer[3];


    CardScript cs;

    // Start is called before the first frame update
    void Start()
    {
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
                playerSprites[currentPlayer].transform.position = new Vector3(Input.mousePosition.x-533.21f, Input.mousePosition.y-587.9f, 3f);
                //playerSprites[currentPlayer].color = Color.blue;
                nextPlayer();
            }

            
        }
    }

    public void StartRound()
    {
        turntracker.text = players[currentPlayer]+" give cue";
    }

    void nextPlayer()
    {
        currentPlayer++;
        currentPlayer %= playerCount;
        turntracker.text = players[currentPlayer] + "'s turn";
    }

}
