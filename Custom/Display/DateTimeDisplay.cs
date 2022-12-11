using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeDisplay : MonoBehaviour
{
    public GameObject dateTimeDisplay;
    private string time, date;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        date = System.DateTime.Now.ToString("dd MMMM yyyy");
        time = System.DateTime.Now.ToString("HH:mm:ss");
        dateTimeDisplay.GetComponent<Text>().text = time + "\n" + date;
    }
}
