using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	[SerializeField]
	private Vector3 teleportPos;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider target) {
		if (target.tag == "Ball") {
			target.transform.position = teleportPos;
		}
	}

} // Teleport