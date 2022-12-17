using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class open_door : MonoBehaviour
{
    public Animator doorAnim;
    public Text info;
    private bool doorFlag;
    private bool isCollide;

    private bool generatorOff;

    public GameObject player;

    private void Awake()
    {
        isCollide = false;
        doorFlag = false;
        generatorOff = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isCollide = true;
        }
    }

    private void Update()
    {
        generatorOff = player.GetComponent<PlayerVariable>().generatorOff;
        if(isCollide)
        {
            if (generatorOff) {
                info.text = "Generator is off.";
                return;
            }
            info.text = "Press E to \nopen/close door";
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

    private void OnTriggerExit(Collider other)
    {
        info.text = "";
        isCollide = false;
    }
}
