using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerVariable : MonoBehaviour
{
    public GameObject keyCard;
    public Text info;
    public Text mission;
    public bool have_keycard;
    // Start is called before the first frame update
    void Awake()
    {
        mission.text = "Mission:\nGet the key card";
        have_keycard = false;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "card")
        {
            info.text = "Press E to \n take the key card";
            if (Input.GetKeyDown(KeyCode.E))
            {
                have_keycard = true;
                keyCard.SetActive(false);
            }

            if (have_keycard)
            {
                mission.text = "Mission:\nOpen the storage room";
                info.text = "";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
      
        info.text = "";
     
    }
}



