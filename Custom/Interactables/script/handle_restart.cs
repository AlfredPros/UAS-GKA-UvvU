using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class handle_restart : MonoBehaviour
{
   void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
