using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public float speed;

     static float moveDistance;
    public float moveY;
    void Start()
    {
        moveDistance = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0f,moveDistance,0f), speed * Time.fixedDeltaTime);
    }

    public void MoveMent()
    {
        moveDistance+=moveY;
    }
}
