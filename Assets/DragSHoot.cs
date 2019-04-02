using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSHoot : MonoBehaviour
{
    Vector3 startpoint;
    Vector3 endpoint;

    public GameObject LaunchBall;

    Preview preview;

    private void Awake()
    {
        preview = GetComponent<Preview>();
    }
    private void FixedUpdate()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        if (Bouncingbullet.bouncingbullet == null && Teleport.teleport==null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartShoot(pos);
            }
            else if (Input.GetMouseButton(1))
            {
                ContinueToShoot(pos);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                Launch();
            }
        }

        


    }



    void StartShoot(Vector3 pos)
    {
        startpoint = pos;
        preview.StartPoint(transform.position);
    }

    void ContinueToShoot(Vector3 pos)
    {
        endpoint = pos;

        Vector3 direction = endpoint - startpoint;
        preview.EndPoint(transform.position-direction);
    }

    void Launch()
    {
        preview.Launched();
        Vector3 direToLaunch = endpoint - startpoint;

        GameObject launchBall = Instantiate(LaunchBall, transform.position, transform.rotation);

        launchBall.GetComponent<Rigidbody2D>().AddForce(-direToLaunch*100f);



    }
}
