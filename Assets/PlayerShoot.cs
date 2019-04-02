using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullets;

    public float  firerate;
    private float timebtwfire;
    public float speed;
    public float numberofBullets;

    private Vector3 startpoint;

    void Start()
    {
    }

    private void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dirtolook = (mousepos - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, dirtolook);
        rot.x = rot.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 100f * Time.deltaTime);
    }

    void FixedUpdate()
    {
        startpoint = transform.position;
            if (timebtwfire <= 0)
            {
                float bulpos = 360f / numberofBullets;
                float angle = 0f;

                for (int i = 0; i <= numberofBullets - 1; i++)
                {
                    float xdir = startpoint.x + Mathf.Sin((angle * Mathf.PI) / 180);
                    float ydir = startpoint.y + Mathf.Cos((angle * Mathf.PI) / 180);

                    Vector3 direction = new Vector3(xdir, ydir, 0f);
                    Vector3 move = (direction - startpoint).normalized * speed;
                    GameObject temp = Instantiate(bullets, startpoint, transform.rotation);
                    temp.GetComponent<Rigidbody2D>().AddRelativeForce((new Vector3(move.x, move.y, 0f)) * 90f, ForceMode2D.Force);


                    angle += bulpos;

                    timebtwfire = firerate;
                }
            }
            else
            {
                timebtwfire -= Time.fixedDeltaTime;
            }
        }
       
  }

