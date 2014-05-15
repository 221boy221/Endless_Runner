﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static float distanceTraveled;
    public float acceleration;
    public Vector3 jumpVelocity;
    private bool touchingPlatform;

    void Update() {
        if (touchingPlatform && Input.GetButtonDown("Jump")) {
            rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
            touchingPlatform = false;
        }
        distanceTraveled = transform.localPosition.x;
    }   

    void FixedUpdate() {
        if (touchingPlatform) {
            rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
        }
    }


    // Check if Player is in ground
    void OnCollisionEnter() {
        touchingPlatform = true;
    }

    void OnCollisionExit() {
        touchingPlatform = false;
    }
}
