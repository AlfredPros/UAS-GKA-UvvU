using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_balls : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float y_ball = this.transform.position.y;

        if (y_ball <= -2)
        {
            Destroy(this.gameObject);
        }
    }
}
