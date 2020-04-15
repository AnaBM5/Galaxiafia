using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Sprite[] hearts;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void currentHealth(int pos)
    {
        this.GetComponent<Image>().sprite = hearts[pos];
    }
}
