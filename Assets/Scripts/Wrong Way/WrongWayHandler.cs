using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongWayHandler : MonoBehaviour {

	void Awake () {
		GetComponent<MeshRenderer> ().enabled = false;
	}

	void OnTriggerEnter (Collider target) {
		if (target.tag == "Ball") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

} // WrongWayHandler