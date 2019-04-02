using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncingbullet : MonoBehaviour
{
    public static Bouncingbullet bouncingbullet;
    public GameObject _effect;
    public GameObject _effect2;
    private void Awake()
    {
        bouncingbullet = this;
    }
    private void Start()
    {
        StartCoroutine(effect());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(_effect2, collision.gameObject.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);

    }

    IEnumerator effect()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
