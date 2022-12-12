using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParentNans : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position[0], player.position[1]+0.75f, player.position[2]);
    }
}
