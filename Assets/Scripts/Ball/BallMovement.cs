using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	private string direction = "";
	private string directionLastFrame = "";

	[HideInInspector]
	public int onFloorTracker = 0;

	private bool fullSpeed = false;

	// Speed variables
	private int floorSpeed = 100;
	private int airSpeed = 20;
	private float airSpeed_Diagonal = 5.858f;
	private float airDrag = 0.1f;
	private float floorDrag = 2.29f;
	private float delta = 50f;

	// Camera Variables
	private Vector3 cameraRelative_Right;
	private Vector3 cameraRelative_Up;
	private Vector3 cameraRelative_Down;
	private Vector3 cameraRelative_Up_Right;
	private Vector3 cameraRelative_Up_Left;

	// Velocity and magnitude variables
	private Vector3 xVelocity;
	private Vector3 zVelocity;
	private float xSpeed;
	private float zSpeed;

	// Movement Axis
	private string Axis_Y = "Vertical";
	private string Axis_X = "Horizontal";

	private Rigidbody myBody;

	private Camera mainCamera;

	void Start () {
		
	}

	void Update () {
		GetDirection ();
	}

	void FixedUpdate () {
		MoveTheBall ();
	}

	void GetDirection () {
		direction = "";

		if (Input.GetAxis (Axis_Y) > 0) {
			direction += "up";
		} else if (Input.GetAxis (Axis_Y) < 0) {
			direction += "down";
		}

		if (Input.GetAxis (Axis_X) > 0) {
			direction += "right";
		} else if (Input.GetAxis (Axis_X) > 0) {
			direction += "left";
		}
	}

	void MoveTheBall () {
		switch (direction) {
		case "upright":
			break;
		case "upleft":
			break;
		case "downleft":
			break;
		case "downright":
			break; 
		case "up":
			break;
		case "down":
			break; 
		case "right":
			break; 
		case "left":
			break; 
		}
	}

} // BallMovement