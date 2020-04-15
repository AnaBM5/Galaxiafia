﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseOption : MonoBehaviour
{
    private Vector2 initialPosition;
    private Vector2 rightAnswer;
    private Vector2 wrongAnswer;
    public GameObject perdiste;
    public GameObject principal;
    private PlayerText nextQuestions;
    public static bool answered = false;

    // Start is called before the first frame update
    void Start()
    {
        nextQuestions = FindObjectOfType<PlayerText>();
        perdiste.SetActive(false);
        initialPosition = transform.position;        
        ShowLives.livesAmount = 3;
        ShowScore.scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RightOption"))
        {
            RightAnswer();
            
        }else if (other.CompareTag("WrongOption"))
        {   
            WrongAnswer();
        }
    }
    public void onClickAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void RightAnswer()
    {
        ShowScore.scoreValue += 10;    
	    answered = true;
	    transform.position = initialPosition;    
        nextQuestions = FindObjectOfType<PlayerText>();
        nextQuestions.NextButton();
    }

    void WrongAnswer()
    {
        ShowLives.livesAmount--; 
	    answered = true;
	    transform.position = initialPosition;       
        
        if (ShowLives.livesAmount <= 0)
        {
            KillPlayer();          
            
        }
        else
        {
            nextQuestions.NextButton();
        }
    }
    
    

    void KillPlayer()
    {
        this.gameObject.SetActive(false);
        perdiste.SetActive(true);
        principal.SetActive(false);
        
               
        

    }
}
