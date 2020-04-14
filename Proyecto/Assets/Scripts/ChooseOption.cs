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

    // Start is called before the first frame update
    void Start()
    {
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
        transform.position = initialPosition;

    }

    void WrongAnswer()
    {
        ShowLives.livesAmount--;
        transform.position = initialPosition;
        if (ShowLives.livesAmount <= 0)
        {
            KillPlayer();          
            
        }
    }
    
    

    void KillPlayer()
    {
        perdiste.SetActive(true);
        principal.SetActive(false);
        
               
        

    }
}
