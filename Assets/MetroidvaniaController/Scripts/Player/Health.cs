﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    private float health;
    private int numOfHearts;

    public Image [] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<CharacterController2D>().life;
        numOfHearts = (int)health/2;

        if(health > numOfHearts){
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if( i < health){
                hearts[i].sprite = fullHeart;
            }

            else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts){
                hearts[i].enabled = true;
            } 
            
            else {
                hearts[i].enabled = false;
            }
        }
        
    }
}
