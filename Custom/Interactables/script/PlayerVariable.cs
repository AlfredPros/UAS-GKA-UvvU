using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerVariable : MonoBehaviour
{
    public GameObject keyCard;
    public bool nearKeyCard;
    public Text info;
    public Text mission;
    public bool have_keycard;
    public bool generatorOff;
    // Start is called before the first frame update
    void Awake()
    {
        mission.text = "Mission:\nGet the key card";
        have_keycard = false;
        generatorOff = false;
        nearKeyCard = false;
    }
    private void OnGUI() {
        if (nearKeyCard) {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "card")
        {
            info.text = "Press E to \n take the key card";
            nearKeyCard = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
      
        info.text = "";
        nearKeyCard = false;
    }

    public void restartGame() {
         SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    public void endGame() {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}



