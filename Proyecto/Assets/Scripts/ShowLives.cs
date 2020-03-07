using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLives : MonoBehaviour
{
    public static int livesAmount = 3;
    private TextMeshProUGUI lives;
    
    // Start is called before the first frame update
    void Start()
    {
        lives = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "Vidas: " + livesAmount.ToString();
    }
}
