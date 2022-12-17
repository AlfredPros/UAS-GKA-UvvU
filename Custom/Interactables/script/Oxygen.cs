using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    public int oxygenLevel;
    public Text oxygenText;
    public Text info;
    public Text mission;
    public bool isCollide;
    private bool triggerOnce;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine("CheckOxygenLevel");
    }


    void Awake()
    {
        triggerOnce = false;
        isCollide = false;
        oxygenLevel = 80;
    }

    IEnumerator CheckOxygenLevel()
    {
        for(;;) {
            Debug.Log(oxygenLevel);
            oxygenText.text = "Oxygen" + oxygenLevel + "%";
            oxygenLevel -= 1;
            yield return new WaitForSeconds(5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isCollide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        info.text = "";
        isCollide = false;
    }

    void Update()
    {

        if (isCollide)
        {
            info.text = "Press E to \nrefill oxygen";
            if (Input.GetKeyDown(KeyCode.E)) {
                oxygenLevel = 100;
                oxygenText.text = "Oxygen" + oxygenLevel + "%";
            }

            if(!triggerOnce)
            {
                mission.text = "Mission:\nNext Mission..";
            }
        }
    }
}
