using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    //input variables (variables used to process and handle input)
    private Vector3 inputRotation;
    private Vector3 inputMovement;

    // calculation variables (variables used for calculation)
    private Vector3 tempVector;
    private Vector3 tempVector2;

    // Player movement
    private float moveSpeed = 100f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        FindPlayerInput();
        ProcessMovement();
    }

    void FindPlayerInput() {
        // find vector to the mouse
        inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // the position of the middle of the screen
        tempVector2 = new Vector3(Screen.width * 0.5f, 0, Screen.height * 0.5f);
        /* find the position of the mouse on screen */
        tempVector = Input.mousePosition;
        /* input mouse position gives us 2D coordinates, I am moving the Y coordinate to the Z coorindate in temp Vector and setting the Y 
        coordinate to 0, so that the Vector will read the input along the X (left and right of screen) and Z (up and down screen) axis, and not the X and Y (in and out of screen) axis*/
        tempVector.z = tempVector.y;
        tempVector.y = 0;
        Debug.Log(tempVector);
        // the direction we want face/aim/shoot is from the middle of the screen to where the mouse is pointing
        inputRotation = tempVector - tempVector2; 
    }

    void ProcessMovement() {
        rigidbody.AddForce(inputMovement.normalized * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(inputRotation);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}