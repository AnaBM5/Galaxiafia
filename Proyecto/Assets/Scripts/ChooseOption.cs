using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI Losetext;
    public TextMeshProUGUI scoreFinal;
    public static bool answered = false;
    public static bool correct;
    private AnimScript canvasAnimation;
    public GameObject bar;
    private static int time = 120;   
    
    private void doit()
    {        
        Losetext.text = "TIEMPO";
        KillPlayer();
    }
    public void animedBar()
    {

        LeanTween.scaleX(bar, 1, time).setOnComplete(doit);


    }
    // Start is called before the first frame update
    void Start()
    {
        nextQuestions = FindObjectOfType<PlayerText>();
        perdiste.SetActive(false);
        initialPosition = transform.position;
        ShowLives.livesAmount = 3;
        ShowScore.scoreValue = 0;
        animedBar();
        canvasAnimation = GameObject.FindGameObjectWithTag("CanvasShake").GetComponent<AnimScript>();
    }

    // Update is called once per frame
    void Update()
    {
        correct = false;
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
        
        SceneManager.LoadScene("Game");
    }
    public void onclickMenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    void RightAnswer()
    {
        ShowScore.scoreValue += 10;
        //barTime.time += 10;
        correct = true;        
	    answered = true;
	    transform.position = initialPosition;    
        nextQuestions = FindObjectOfType<PlayerText>();
        nextQuestions.NextButton();
        
    }

    void WrongAnswer()
    {
        canvasAnimation.canvasShake();
        ShowLives.livesAmount--; 
	    answered = true;
        correct = false;
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
    
    

    public void KillPlayer()
    {
        scoreFinal.text = "Puntuación: " + ShowScore.scoreValue;
        this.gameObject.SetActive(false);
        perdiste.SetActive(true);
        principal.SetActive(false);
        
               
        

    }
}
