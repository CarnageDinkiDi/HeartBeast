using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float x, y;

    public GameObject NextBall;
    private void Start()
    {
       float _x = Random.Range(x, x*2);
        float _y = Random.Range(y*2, y);
        rb.AddForce(new Vector2(_x,_y), ForceMode2D.Impulse);
    }


    public void Split()
    {
        if (NextBall!= null)
        {
            GameObject ball1 = Instantiate(NextBall, rb.position + Vector2.up / 2f, Quaternion.identity);
            GameObject ball2 = Instantiate(NextBall, rb.position + Vector2.left / 2f, Quaternion.identity);

            ball1.GetComponent<Ball>().x = 3f;
            ball1.GetComponent<Ball>().y = -2f;

            ball2.GetComponent<Ball>().x = 5f;
            ball1.GetComponent<Ball>().y = 2f;

        }

        Destroy(gameObject);
    }
}
