using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animator anim;
    public static GameObject controlledBy;

    // Camera Stuff
    public new Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /// Run: Input.GetAxis("Fire3")
        /// Jump: Input.GetAxis("Submit")

        if (controlledBy != null) {  // For sitting down trigger
            return;
        }
        float translation = Input.GetAxis("Vertical");
        this.transform.eulerAngles = new Vector3(0, camera.transform.localRotation.eulerAngles.y, 0);

        // Jump Check
        if (Input.GetAxis("Submit") != 0) {
            anim.SetBool("isJump", true);
        }
        else {
            anim.SetBool("isJump", false);
        }

        // Run Check
        if (Input.GetAxis("Fire3") != 0) {
            anim.SetBool("isRun", true);
        }
        else {
            anim.SetBool("isRun", false);
        }

        // Walk Check
        if (translation != 0)
        {
        	anim.SetBool("isWalk", true);
        	anim.SetFloat("speed", translation);
        }
        else
        {
        	anim.SetBool("isWalk", false);
        	anim.SetFloat("speed", 0);
        }
    }
}
