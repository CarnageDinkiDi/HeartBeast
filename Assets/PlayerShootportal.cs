using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootportal : MonoBehaviour
{
    public GameObject PortalBullet;

    public float speed;

    Vector3 posToMove;
    void Start()
    {
        posToMove = transform.position;
    }

    private void Update()
    {
        LookAtCursor();
    }

    void LookAtCursor()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dirtolook = (mousepos - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, dirtolook);
        rot.x = rot.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 100f * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && Teleport.teleport==null && Bouncingbullet.bouncingbullet==null)
        {
            GameObject temp = Instantiate(PortalBullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = temp.transform.up * speed;
        }

        if(Input.GetMouseButtonDown(0) && Teleport.teleport != null)
        {
            Debug.Log("Cant shoot");
        }

    }


    public void TeleportPosition(Transform position)
    {
        transform.position = position.position;
    }
    
    }

