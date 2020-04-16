using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barTime : MonoBehaviour
{
    public GameObject bar;
    public int time;
    private ChooseOption GameOver;
    private void doit()
    {
        GameOver = FindObjectOfType<ChooseOption>();
        GameOver.KillPlayer();
    }
    // Start is called before the first frame update
    public void animedBar()
    {
       
        LeanTween.scaleX(bar, 1, time).setOnComplete(doit);
    }
    void Start()
    {
        animedBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
