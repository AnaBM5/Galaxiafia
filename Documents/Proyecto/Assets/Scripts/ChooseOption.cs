using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseOption : MonoBehaviour
{
    private Vector2 initialPosition;
    private int lives = 3;
    public Lives livesCanvas;
    public static bool answered = false;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        livesCanvas = GameObject.FindObjectOfType<Lives>();
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

    void RightAnswer()
    {
        ShowScore.scoreValue += 10;
        answered = true;
        //new WaitForSeconds(1);
        transform.position = initialPosition;
        
    }

    void WrongAnswer()
    {
        ShowLives.livesAmount--;
        lives--;
        livesCanvas.currentHealth(lives);
        answered = true;
        transform.position = initialPosition;
        
        if (lives <= 0)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        Destroy(this.gameObject);
    }
}
