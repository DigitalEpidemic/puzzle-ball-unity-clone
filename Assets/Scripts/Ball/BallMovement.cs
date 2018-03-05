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

	void Awake () {
		myBody = GetComponent<Rigidbody> ();
		mainCamera = Camera.main;
	}

	void Start () {
		
	}

	void Update () {
		UpdateCameraRelativePosition ();
		GetDirection ();
		FullSpeedController ();
		DragAdjustmentAndAirSpeed ();
	}

	void FixedUpdate () {
		MoveTheBall ();
	}

	void LateUpdate () {
		directionLastFrame = direction;
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
			if (onFloorTracker > 0) {
				// On the floor
				if (fullSpeed) {
					myBody.AddForce (floorSpeed * cameraRelative_Up_Right * Time.fixedDeltaTime * delta);
				} else {
					myBody.AddForce ((floorSpeed - 75f) * cameraRelative_Up_Right * Time.fixedDeltaTime * delta);
				}

			} else if (onFloorTracker == 0) {
				// In the air
			}
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

	void UpdateCameraRelativePosition () {
		cameraRelative_Right = mainCamera.transform.TransformDirection (Vector3.right);

		cameraRelative_Up = mainCamera.transform.TransformDirection (Vector3.forward);
		cameraRelative_Up.y = 0f;
		cameraRelative_Up = cameraRelative_Up.normalized; // Keeps direction, but shortens to 1 unit

		cameraRelative_Up_Right = (cameraRelative_Up + cameraRelative_Right);
		cameraRelative_Up_Right = cameraRelative_Up_Right.normalized;

		cameraRelative_Up_Left = (cameraRelative_Up - cameraRelative_Right);
		cameraRelative_Up_Left = cameraRelative_Up_Left.normalized;
	}

	void FullSpeedController () {
		if (direction != directionLastFrame) {
			
			if (direction == "") {
				StopCoroutine ("FullSpeedTimer");
				fullSpeed = false;

			} else if (directionLastFrame == "") {
				StartCoroutine ("FullSpeedTimer");
			}
		}
	}

	IEnumerator FullSpeedTimer () {
		yield return new WaitForSeconds (0.07f);
		fullSpeed = true;
	}

	void DragAdjustmentAndAirSpeed () {
		if (onFloorTracker > 0) {
			// On the floor
			myBody.drag = floorDrag;
		} else {
			// In the air
			xVelocity = Vector3.Project (myBody.velocity, cameraRelative_Right);
			zVelocity = Vector3.Project (myBody.velocity, cameraRelative_Up);

			xSpeed = xVelocity.magnitude;
			zSpeed = zVelocity.magnitude;

			myBody.drag = airDrag;
		}
	}

	void OnCollisionEnter (Collision target) {
		if (target.gameObject.tag == "Floor") {
			onFloorTracker++;
		}
	}

	void OnCollisionExit (Collision target) {
		if (target.gameObject.tag == "Floor") {
			onFloorTracker--;
		}
	}

} // BallMovement