using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	[SerializeField]
	private Vector3 teleportPos;

	[SerializeField]
	private bool getArrows;

	private GameObject[] pathArrows;
	private GameObject[] wrongWayArrows;

	void Awake () {
		if (getArrows) {
			pathArrows = GameObject.FindGameObjectsWithTag ("PathArrow");
			wrongWayArrows = GameObject.FindGameObjectsWithTag ("WrongPathArrow");

			foreach (GameObject obj in wrongWayArrows) {
				obj.SetActive (false);
			}
		}
	}

	void OnTriggerEnter (Collider target) {
		if (target.tag == "Ball") {
			target.transform.position = teleportPos;

			if (getArrows) {
				foreach (GameObject obj in pathArrows) {
					obj.SetActive (false);
				}
				foreach (GameObject obj in wrongWayArrows) {
					obj.SetActive (true);
				}
			}
		}
	}

} // Teleport