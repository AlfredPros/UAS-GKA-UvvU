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
    private computer cs;

    private void Awake()
    {
        cs = computer.GetComponent<computer>();
        isCollide = false;
        doorLocked = true;
        doorFlag = false;
        triggerOnce = false;
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

        if (!doorLocked)
        {
            if (!triggerOnce)
            {
                this.GetComponent<MeshRenderer>().material = green_one;
                indicator.color = Color.green;
            }
            if (Input.GetKeyDown(KeyCode.E) && !doorFlag && isCollide)
            {
                doorAnim.SetBool("isOpen", true);
                doorFlag = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && doorFlag && isCollide)
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
