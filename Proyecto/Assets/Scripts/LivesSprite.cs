using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesSprite : MonoBehaviour{

    public Sprite[] corazones;

    public void CambioVida(int pos)
    {
        this.GetComponent<Image>().sprite = corazones[pos];
    }

    // Start is called before the first frame update
    void Start()
    {
        CambioVida(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}