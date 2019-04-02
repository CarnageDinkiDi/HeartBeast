using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float time;
    public Text _time;

    public float slowtime;
    public float slowrate;

    void Start()
    {
        time = Time.time;
    }

    void FixedUpdate()
    {
        _time.text = ((int)Time.time -(int)time).ToString();

        Time.timeScale += (1f / slowtime) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void slowdown()
    {
        Time.timeScale = slowrate;
    }
}
