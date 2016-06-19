using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Ball;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class NetworkControlledBall : NetworkBehaviour {

    private Ball ball; // Reference to the ball controller.

    private Vector3 move;
    // the world-relative desired move direction, calculated from the camForward and user input.

    private Vector3 camForward; // The current forward direction of the camera
    private bool jump; // whether the jump button is currently pressed


    private void Awake()
    {
        // Set up the reference.
        ball = GetComponent<Ball>();
        
    }


    private void Update()
    {
        // Get the axis and jump input.
        if(isLocalPlayer)
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            jump = CrossPlatformInputManager.GetButton("Jump");

            // calculate move direction
            move = (v * Vector3.forward + h * Vector3.right).normalized;
        }
        
    }


    private void FixedUpdate()
    {
        // Call the Move function of the ball controller
        ball.Move(move, jump);
        jump = false;
    }
}
