using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public TimeManager timeManager;
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 dirToFollow =(mousePos - transform.position).normalized;

        if (Vector2.Distance(mousePos, transform.position) > 0.4f)
        {
            transform.position = Vector3.Lerp(transform.position, mousePos, speed * Time.fixedDeltaTime);
        }


        if (Input.GetMouseButtonDown(1))
        {
            timeManager.slowdown();
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ball")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
