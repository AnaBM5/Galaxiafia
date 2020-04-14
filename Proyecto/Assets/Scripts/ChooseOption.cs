using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        nextQuestions = FindObjectOfType<PlayerText>();
        perdiste.SetActive(false);
        initialPosition = transform.position;        
        ShowLives.livesAmount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RightOption"))
        {
            transform.position = initialPosition;
            RightAnswer();
        }else if (other.CompareTag("WrongOption"))
        {
            transform.position = initialPosition;
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
        nextQuestions = FindObjectOfType<PlayerText>();
        nextQuestions.NextButton();
    }

    void WrongAnswer()
    {
        ShowLives.livesAmount--;        
        
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
