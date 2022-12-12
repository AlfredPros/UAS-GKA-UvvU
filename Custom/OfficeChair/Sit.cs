using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sit : MonoBehaviour
{
    public GameObject character;
    public GameObject anchor;
    bool isWalkingTowards = false;
    bool sittingOn = false;
    Animator anim;

    float animSpeed = 0.25f;
    float posMarginError = 0.0625f;


    // Start is called before the first frame update
    void Start()
    {
        anim = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalkingTowards) {
            AutoWalkingTowards();
        }
    }

    void OnMouseDown() {
        if (!sittingOn) {
            anim.SetBool("isWalk", true);
            anim.SetFloat("speed", 1.0f);
            isWalkingTowards = true;
            PlayerControl.controlledBy = this.gameObject;
        }
        else {
            anim.SetBool("isSit", false);
            sittingOn = false;
            isWalkingTowards = false;
            PlayerControl.controlledBy = null;
        }
    }

    void AutoWalkingTowards() {
        if (isWalkingTowards) {
            Vector3 targetDir;
            targetDir = new Vector3(
                anchor.transform.position.x - character.transform.position.x,
                0f,
                anchor.transform.position.z - character.transform.position.z
            );
            Quaternion rot = Quaternion.LookRotation(targetDir);
            character.transform.rotation = Quaternion.Slerp(
                character.transform.rotation,
                rot,
                0.5f
            );
        }

        if (Vector3.Distance(character.transform.position, anchor.transform.position) < 0.375) {
            anim.SetBool("isSit", true);
            anim.SetBool("isWalk", false);
            character.transform.rotation = anchor.transform.rotation;
            isWalkingTowards = false;
            sittingOn = true;
        }
    }

    void FixedUpdate() {
        AnimLerp();
    }

    void AnimLerp() {
        if (!sittingOn) return;
        if (Vector3.Distance(character.transform.position, anchor.transform.position) > posMarginError) {
            character.transform.rotation = Quaternion.Lerp(character.transform.rotation,
                anchor.transform.rotation,
                Time.deltaTime * animSpeed);
            character.transform.position = Vector3.Lerp(character.transform.position,
                anchor.transform.position,
                Time.deltaTime * animSpeed);
        }
        else {
            character.transform.position = anchor.transform.position;
            character.transform.rotation = anchor.transform.rotation;
        }
    }
}
