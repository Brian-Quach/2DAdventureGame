using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienB : MonoBehaviour {

    private Animator animator;
    private bool readyToAttack;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    private void OnTriggerStay2D(Collider2D target) {
        if(target.gameObject.tag == "Player") {

            if (readyToAttack) {
                var explode = target.GetComponent < Explode > ();
                explode.OnExplode();
            } else {
                animator.SetInteger("AnimState", 1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D target) {
        readyToAttack = false;
        animator.SetInteger("AnimState", 0);
    }

    private void Attack() {
        readyToAttack = true;
    }
}
