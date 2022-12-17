using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class addText : MonoBehaviour
{
    public Text time;
    public Text date;

    private DateTime currTime;

    private void Awake() {
        currTime = DateTime.Now;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        currTime = currTime.AddSeconds(Time.fixedDeltaTime);
        time.text = currTime.ToString("hh:mm:ss");
        date.text = currTime.ToString("dd MMMM yy");
    }
}
