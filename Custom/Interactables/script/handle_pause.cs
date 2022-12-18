using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class handle_pause : MonoBehaviour
{
    private bool paused;
    public Image darken;
    public Text pausedText;

    public GameObject player;
     

    private void Awake() {
        paused = false;
        darken.gameObject.SetActive(paused);
        pausedText.gameObject.SetActive(paused);
    }

    private void OnGUI() {

        if (Event.current.Equals(Event.KeyboardEvent("ESCAPE"))) {
            if (!player.GetComponent<PlayerControl>().isAlive) return;
            paused = !paused;
            darken.gameObject.SetActive(paused);
            pausedText.gameObject.SetActive(paused);
            if (paused) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }
}
