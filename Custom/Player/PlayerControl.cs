using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animator anim;

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

        float translation = Input.GetAxis("Vertical");

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
