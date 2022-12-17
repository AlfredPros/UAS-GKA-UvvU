using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class addText : MonoBehaviour
{
    public Text time;
    public Text date;


    // Update is called once per frame
    void Update()
    { 
        time.text = System.DateTime.Now.ToString("hh:mm:ss");
        date.text = System.DateTime.Now.ToString("dd MMMM yy");
    }
}
