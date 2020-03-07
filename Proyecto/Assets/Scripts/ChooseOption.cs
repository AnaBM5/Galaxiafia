using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseOption : MonoBehaviour
{
    private Vector2 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
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
        Destroy(this.gameObject);
    }
}
