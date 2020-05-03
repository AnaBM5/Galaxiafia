using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{

    public Animator canvasAnim;
    public Animator characterAnim;

    public void canvasShake()
    {
        canvasAnim.SetTrigger("Damage");
        characterAnim.SetTrigger("Damage");
    }

    public void RightAnwer()
    {
        canvasAnim.SetTrigger("Correct");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
