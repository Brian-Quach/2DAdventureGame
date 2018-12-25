using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float closeDelay = .5f;

    private Animator animator;
    private BoxCollider2D collider2d;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        collider2d = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void EnableCollider2D() {
        collider2d.enabled = true;
    }

    void DisableCollider2D() {
        collider2d.enabled = false;
    }

    public void Open() {
        animator.SetInteger("AnimState", 1);
    }

    public void Close() {
        StartCoroutine(CloseNow());
    }

    IEnumerator CloseNow() {
        yield return new WaitForSeconds(closeDelay);
        animator.SetInteger("AnimState", 2);
    }
}
