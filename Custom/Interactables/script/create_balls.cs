using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class create_balls : MonoBehaviour
{
    public Transform prefab;
    public Text info;
    public Text mission;
    private bool triggerOnce;
    private bool isCollide;

    private void Awake()
    {
        triggerOnce = false;
        isCollide = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        isCollide = true;
    }

    private void Update()
    {
       if(isCollide)
        {
            info.text = "Press E to create yellow spheres";
        }
        if (Input.GetKeyDown(KeyCode.E) && !triggerOnce && isCollide)
        {
            mission.text = "Deploy the hatch";
            Instantiate(prefab, new Vector3(-4.43f, 2.52f, 23.0606f), Quaternion.identity);
            triggerOnce = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isCollide)
        {
            Instantiate(prefab, new Vector3(-4.43f, 2.52f, 23.0606f), Quaternion.identity);
            triggerOnce = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        info.text = "Press E to create yellow spheres";
        if (Input.GetKeyDown(KeyCode.E) && !triggerOnce)
        {
            mission.text = "Mission:\nDeploy the hatch";
            Instantiate(prefab, new Vector3(-4.43f, 2.52f, 23.0606f), Quaternion.identity);
            triggerOnce = true;
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(prefab, new Vector3(-4.43f, 2.52f, 23.0606f), Quaternion.identity);
            triggerOnce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isCollide = false;
        info.text = "";
    }
}
