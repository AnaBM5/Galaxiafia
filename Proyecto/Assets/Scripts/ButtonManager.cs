using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{ 
    public void onclickOnMouseUp()
    {
        
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

   
 
}
