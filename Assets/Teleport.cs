using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
   PlayerShootportal playerShootPortal;

    public static Teleport teleport;

    public GameObject _effect;


    private void Awake()
    {
        teleport = this;
    }

    void Start()
    {
        playerShootPortal = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShootportal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerShootPortal.TeleportPosition(transform);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(_effect, transform.position, transform.rotation);

        Destroy(gameObject);

    }
}
