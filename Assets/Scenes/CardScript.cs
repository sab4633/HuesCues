using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GameObject.Find("color").GetComponent<SpriteRenderer>();
        
        //sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Change the 'color' property of the 'Sprite Renderer'
        sprite.color = Color.blue;
        
    }
}
