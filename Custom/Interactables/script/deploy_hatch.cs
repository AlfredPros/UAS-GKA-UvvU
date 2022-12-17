using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deploy_hatch : MonoBehaviour
{
    public Text info;
    public Text mission;
    public Animator anim;
    private bool isOpen;
    private bool triggerOnce;
    private bool isCollide;

    private void Awake()
    {
        isOpen = false;
        triggerOnce = false;
        isCollide = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        isCollide = true;
    }

    private void Update()
    {
        if(isCollide && !triggerOnce)
        {
            info.text = "Press E to open the hatch";
        }
        if (Input.GetKeyDown(KeyCode.E) && !isOpen && !triggerOnce && isCollide)
        {
            mission.text = "Mission:\nRefill Your Oxygen";
            anim.SetBool("isOpen", true);
        }
        if(isCollide)
        {
            info.text = "hatch has already been opened";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        info.text = "";
        isCollide = false;
    }
}
