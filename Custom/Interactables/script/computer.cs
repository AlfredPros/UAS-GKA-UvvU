using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computer : MonoBehaviour
{
    public Text info;
    public Text mission;
    public Text comp_info;
    private bool isCollide;
    private bool isGeneratorOn;
    public bool have_keycard;
    public GameObject player;
    public GameObject ComputerUI;
    public bool door_lock;

    private void Awake()
    {
        door_lock = true;
        ComputerUI.SetActive(false);
        have_keycard = false;
        isCollide = false;
        isGeneratorOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isCollide = true;
            PlayerVariable dv = player.GetComponent<PlayerVariable>();
            have_keycard = dv.have_keycard;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        info.text = "";
        isCollide = false;
    }

    public void exitButtonPressed()
    {
        ComputerUI = GameObject.Find("computerUI");
        ComputerUI.SetActive(false);
    }

    public void generatorButtonPressed()
    {
        if(!isGeneratorOn)
        {
            //turn off generator code here...
            comp_info.text = "Generator has been turn off";
            isGeneratorOn = true;
        }
        else
        {
            //turn on generator code here...
            comp_info.text = "Generator has been turn on";
            isGeneratorOn = false;
        }

    }

    public void unlockButtonPressed()
    {
        door_lock = false;
        comp_info.text = "Storage room has been Unlocked";
    }

    void Update()
    {
        if (isCollide && !have_keycard)
        {
            info.text = "ACCESS DENIED\n(take the keycard to gain access)";
        }

        else if(isCollide && have_keycard)
        {
            info.text = "Press E to have access to control/panel";
            if (Input.GetKeyDown(KeyCode.E)) {
                ComputerUI.SetActive(true);
            }
        }
    }
}
