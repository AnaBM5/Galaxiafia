using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barTime : MonoBehaviour
{
    public GameObject bar;
    public static int time=10;
    private ChooseOption GameOver;
    private LTDescr B;
    private void doit()
    {
        GameOver = FindObjectOfType<ChooseOption>();
        GameOver.Losetext.text = "TIEMPO";
        GameOver.KillPlayer();
    }
    private void FixedUpdate()
    {
        if (!ChooseOption.correct)
        {
            B.setOnComplete(doit);
        }
        else
        {
            B.reset();
            B = LeanTween.scaleX(bar, 1, time);
        }
    }
    // Start is called before the first frame update
    public void animedBar()
    {

        B=LeanTween.scaleX(bar, 1, time);
        

    }
    
    
    void  Start()
    {
        animedBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
