using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public TextMeshProUGUI xd;
    public void onclickOnMouseUp()
    {
        
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    public void onclickReglas()
    {
        xd.text = "solo disfruta";
    }

   
 
}
