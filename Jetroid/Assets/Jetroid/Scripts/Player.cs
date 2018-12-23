using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 150f;
    public Vector2 maxVelocity = new Vector2(60, 100);
    public float jetSpeed = 200f;
    public bool standing;
    public float standingThreshold = 4f;
    public float airSpeedMultiplier = .3f;

    private Rigidbody2D body2d;
    private SpriteRenderer renderer2d;
    private PlayerController controller;
    private Animator animator;

    void Start () {
        body2d = GetComponent<Rigidbody2D>();
        renderer2d = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        var absVelX = Mathf.Abs(body2d.velocity.x);
        var absVelY = Mathf.Abs(body2d.velocity.y);

        if (absVelY <= standingThreshold) {
            standing = true;
        } else {
            standing = false;
        }

        var forceX = 0f;
        var forceY = 0f;

        if (controller.moving.x != 0) {
            if(absVelX < maxVelocity.x) {
                var newSpeed = speed * controller.moving.x;
                forceX = standing ? newSpeed : (newSpeed * airSpeedMultiplier);
                renderer2d.flipX = forceX < 0;
            }

            animator.SetInteger("AnimState", 1);
        } else {
            animator.SetInteger("AnimState", 0);
        }

        if (controller.moving.y > 0) {
            if(absVelY < maxVelocity.y) {
                forceY = jetSpeed * controller.moving.y;
            }
            animator.SetInteger("AnimState", 2);
        } else if (absVelY > 0 && !standing){
            animator.SetInteger("AnimState", 3);
        }

        body2d.AddForce(new Vector2(forceX, forceY));
	}
}
