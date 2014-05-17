using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private GameObject objPlayer;
    public GameObject objGunNozzle;

    //input variables (variables used to process and handle input)
    private Vector3 inputRotation;
    private Vector3 inputMovement;

    // calculation variables (variables used for calculation)
    private Vector3 tempVector;
    private Vector3 tempVector2;

    private VariableScript ptrScriptVariable;
    public Camera c;

    // Use this for initialization
    void Start() {
        objPlayer = (GameObject)GameObject.FindWithTag("Player");
		ptrScriptVariable = (VariableScript) objPlayer.GetComponent( typeof(VariableScript) );
    }

    // Update is called once per frame
    void Update() {
        FindPlayerInput();
        ProcessMovement();
    }

    void FindPlayerInput() {
        // Find vector to Mouse - (Will be used later on for the bullets)
            //inputMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0); // X - Y - Z
        // The position of the middle of the screen
        tempVector2 = new Vector3(this.transform.position.x, this.transform.position.y, 0 ); // X - Y - Z
        // Go from units to pixels
        tempVector2 = c.WorldToScreenPoint(tempVector2);
        tempVector2.z = 0;
        // Find the position of the mouse on screen
        tempVector = Input.mousePosition;
        // Input.mousePosition gives 2D coordinates ( X - Y )
        Debug.Log("tempVec2 = " + tempVector2);
        Debug.Log("tempVec = " + tempVector);
        // The direction it aims at (is currently from the middle of the screen to where the mouse is pointing)
        inputRotation = tempVector - tempVector2;
        //Debug.Log("inputRot = " + inputRotation);

        // Spawn and fire the bullets
        if (Input.GetMouseButtonDown(0)) {
            HandleBullets();
        }
    }

    void HandleBullets() {
        // Get the inputRotation Vector from the player's position to the mouse by multiplying the inputRotation Vector by the Quaternion.AngleAxis.
        tempVector = Quaternion.AngleAxis(8f, Vector3.up) * inputRotation;
        // Adds offset - (For the Gun Nozzle)
        tempVector = (objGunNozzle.transform.position + (tempVector.normalized * 0.8f));
        // Create a bullet and rotate it based on the vector inputRotation
        Instantiate(ptrScriptVariable.objBullet, tempVector, Quaternion.LookRotation(inputRotation));
    }

    void ProcessMovement() {

        transform.rotation = Quaternion.LookRotation(inputRotation);
        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        transform.position = new Vector3(transform.position.x, 0, 0);
    }

}