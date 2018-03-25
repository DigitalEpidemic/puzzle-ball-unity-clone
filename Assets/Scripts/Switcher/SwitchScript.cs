using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

	private GameObject switchWall;

	private bool wallTurnedOff;

	private Renderer myRenderer;
	private Color switchColor;

	void Awake () {
		if (gameObject.name == "Red Switch") {
			switchWall = GameObject.Find ("Red Wall");
			switchColor = Color.red;
		}

		if (gameObject.name == "Blue Switch") {
			switchWall = GameObject.Find ("Blue Wall");
			switchColor = Color.blue;
		}

		myRenderer = GetComponent<MeshRenderer> ();
	}
	
	void OnTriggerEnter (Collider target) {
		if (target.tag == "Ball") {
			if (wallTurnedOff) {
				switchWall.SetActive (true);
				myRenderer.material.color = switchColor;
				wallTurnedOff = false;
			} else {
				switchWall.SetActive (false);
				myRenderer.material.color = Color.black;
				wallTurnedOff = true;
			}
		}
	}

} // SwitchScript