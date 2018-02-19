using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform ballTransform;

	public float distance = 50f;
	public float xSpeed = 250f;
	public float ySpeed = 120f;
	public float yMinLimit = 0f;
	public float yMaxLimit = 80f;

	private Quaternion rotation;
	private Vector3 position;

	private float xAngle = 0f, yAngle = 0f;
	private float angleMultiplier = 0.02f;

	private bool snapCameraPosition;

	void Awake () {
		ballTransform = GameObject.Find ("Ball").transform;
	}

	void Start () {
		Vector3 rot = transform.eulerAngles;

		xAngle = rot.y;
		yAngle = rot.x;

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			snapCameraPosition = true;
		}
	}

	void LateUpdate () {
		if (ballTransform) {
			xAngle += Input.GetAxis ("Mouse X") * xSpeed * angleMultiplier;
			yAngle += Input.GetAxis ("Mouse Y") * ySpeed * angleMultiplier;

			yAngle = ClampAngle (yAngle, yMinLimit, yMaxLimit);

			if (snapCameraPosition) {
				if ((transform.eulerAngles.y <= 225f) && (transform.eulerAngles.y > 135f)) {
					xAngle = 180f;
				} else if ((transform.eulerAngles.y <= 135f) && (transform.eulerAngles.y > 45f)) {
					xAngle = 90f;
				} else if ((transform.eulerAngles.y <= 315f) && (transform.eulerAngles.y > 225f)) {
					xAngle = 270f;
				} else {
					xAngle = 0f;
				}

				snapCameraPosition = false;
			}

			rotation = Quaternion.Euler (yAngle, xAngle, 0);
			position = rotation * new Vector3 (0, 0, -distance) + ballTransform.position;

			transform.rotation = rotation;
			transform.position = position;
		}
	}

	float ClampAngle (float angle, float min, float max) {
		if (angle < -360f) {
			angle += 360f;
		}

		if (angle > 360f) {
			angle -= 360f;
		}

		return Mathf.Clamp (angle, min, max);
	}

} // CameraFollow