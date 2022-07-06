using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    private Vector3 degreesPerSecond = new Vector3(0.0f, 6.0f, 0.0f);
    private DateTime current;
    // Start is called before the first frame update
    void Start()
    {
        InitializeClock();
    }

    // Update is called once per frame
    void Update()
    {
        //every time change rotate the clock
        if (this.CompareTag("Seconds"))
        {
            transform.Rotate(degreesPerSecond * Time.deltaTime);
            //transform.localRotation *= Quaternion.Euler(degreesPerSecond * Time.deltaTime);
        }
        if (this.CompareTag("Minutes"))
        {
            transform.Rotate(degreesPerSecond * (Time.deltaTime / 60));
        }
        if (this.CompareTag("Hours"))
        {
            transform.Rotate(degreesPerSecond * (Time.deltaTime / 3600));
        }
    }

    void InitializeClock()
    {
        //initialize time on clock = current
        current = DateTime.Now;
        if (this.CompareTag("Seconds"))
        {
            transform.Rotate(degreesPerSecond * current.Second);
        }
        if (this.CompareTag("Minutes"))
        {
            transform.Rotate(degreesPerSecond * (current.Minute));
        }
        if (this.CompareTag("Hours")) //30 degrees per hour
        {
            //rotate the hours
            transform.Rotate((degreesPerSecond * 5) * (current.Hour));
            //rotate the minutes, 1 minute = 0.5degree
            transform.Rotate((degreesPerSecond / 60 * 5) * (current.Minute));
        }
    }
}
