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

    public int limit = 15;

    public GameObject player;

    public Image deathScreen;
    public Text deathMessage;

    public Button restartButton, endButton;

    private Color color;

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
        color = Color.red;
        color.a = 0f;
        deathScreen.color = color;
        deathScreen.gameObject.SetActive(true);
    }

    IEnumerator CheckOxygenLevel()
    {
        for(;oxygenLevel >= 0; oxygenLevel -= 1 ) {
            oxygenText.text = "Oxygen" + oxygenLevel + "%";
            if (oxygenLevel > 0) yield return new WaitForSeconds(5f);
        }
        player.GetComponent<PlayerControl>().isAlive = false;
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
        if (oxygenLevel > 0) { 
            color.a = Mathf.SmoothStep(0f,0.5f, (float) (limit - oxygenLevel)/limit);
            deathScreen.color = color;
            Debug.Log("Death Screen" + deathScreen.color);
            Debug.Log("Color: " + color);
        }

        if (oxygenLevel < 0) {
            deathMessage.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            endButton.gameObject.SetActive(true);
        }

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
