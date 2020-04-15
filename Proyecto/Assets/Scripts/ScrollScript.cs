using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float scrollSpeed = -5f;
    private float deathSpeed = -2f;
    Vector2 startPos;
    public float length = 10;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, length);
        transform.position = startPos + Vector2.up * newPos;
        if(ShowLives.livesAmount<=0)
        {
            scrollSpeed = deathSpeed;

        }
    }
}
