using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBall : MonoBehaviour {

	private Vector3 smallBall_Scale = new Vector3 (1.5f, 1.5f, 1.5f);
	private Vector3 mediumBall_Scale = new Vector3 (3f, 3f, 3f);
	private Vector3 largeBall_Scale = new Vector3 (7f, 7f, 7f);

	private float smallBall_Mass = 0.7f;
	private float mediumBall_Mass = 1f;
	private float largeBall_Mass = 2f;

	private bool removeResizer;
	private bool resizerRemoveCollided;
	private bool ballResized;

	private string smallBall = "SmallBall";
	private string mediumBall = "MediumBall";
	private string largeBall = "LargeBall";

	void Awake () {
		if (gameObject.name == smallBall || gameObject.name == mediumBall || gameObject.name == largeBall) {
			removeResizer = false;
		} else {
			removeResizer = true;
		}
	}
	
	void OnTriggerEnter (Collider target) {
		if (target.gameObject.tag == "Ball") {
			
			if (gameObject.tag == smallBall) {
				if (target.gameObject.transform.localScale != smallBall_Scale) {
					target.gameObject.transform.localScale = smallBall_Scale;
					target.gameObject.GetComponent<Rigidbody> ().mass = smallBall_Mass;
					ballResized = true;
				}
			}

			if (gameObject.tag == mediumBall) {
				if (target.gameObject.transform.localScale != mediumBall_Scale) {
					target.gameObject.transform.localScale = mediumBall_Scale;
					target.gameObject.GetComponent<Rigidbody> ().mass = mediumBall_Mass;
					ballResized = true;
				}
			}

			if (gameObject.tag == largeBall) {
				if (target.gameObject.transform.localScale != largeBall_Scale) {
					target.gameObject.transform.localScale = largeBall_Scale;
					target.gameObject.GetComponent<Rigidbody> ().mass = largeBall_Mass;
					ballResized = true;
				}
			}

			if (ballResized) {
				resizerRemoveCollided = true;
				ballResized = false;
				// Play the pick up audio
			}

			if (resizerRemoveCollided) {
				gameObject.SetActive (false);
			}

		}
	}

} // ResizeBall