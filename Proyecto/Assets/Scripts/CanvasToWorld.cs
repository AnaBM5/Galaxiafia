using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToWorld : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform recTransform;
    void Start()
    {
        recTransform = GetComponent<Transform>();
       Camera.main.ScreenToWorldPoint(recTransform.transform.position); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CanvasPosition()
    {
        
    }
}
