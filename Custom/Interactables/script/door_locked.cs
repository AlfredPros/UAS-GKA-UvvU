using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class door_locked : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject player;
    public GameObject computer;
    public Light indicator;
    public Material green_one;
    public Text info;
    public Text mission;
    private bool doorFlag;
    private bool isCollide;
    private bool triggerOnce;
    public bool doorLocked;
    private bool generator;
    private computer cs;

    private void Awake()
    {
        cs = computer.GetComponent<computer>();
        isCollide = false;
        doorLocked = true;
        doorFlag = false;
        triggerOnce = false;
        generator = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {       
            isCollide = true;
        }
        
    }

    private void Update()
    {
        doorLocked = cs.door_lock;
        generator = cs.isGeneratorOn;
    

        if (!doorLocked )
        {
            if (!triggerOnce && !generator)
            {
                this.GetComponent<MeshRenderer>().material = green_one;
                indicator.color = Color.green;
            }
            if (Input.GetKeyDown(KeyCode.E) && !doorFlag && isCollide && !generator)
            {
                doorAnim.SetBool("isOpen", true);
                doorFlag = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && doorFlag && isCollide && generator)
            {

                doorAnim.SetBool("isOpen", false);
                doorFlag = false;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (!doorLocked)
        {
            if (generator) {
                info.text = "Generator is off.";
                return;    
            }
            info.text = "Press E to \nopen/close door";
            mission.text = "Mission:\ncreate yellow spheres in the storage room";         
        }


        else
        {
            info.text = "door is locked\nunlocked it using the computer";
        }
    }


    private void OnTriggerExit(Collider other)
    {
        info.text = "";
        isCollide = false;
    }

}
