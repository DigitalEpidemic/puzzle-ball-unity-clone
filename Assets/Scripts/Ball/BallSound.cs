using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour {

	private Rigidbody myBody;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioSource ballRollAudio;

	[SerializeField]
	private AudioClip pickUp;

	private BallMovement ballMovement;

	void Awake () {
		myBody = GetComponent<Rigidbody> ();
		ballMovement = GetComponent<BallMovement> ();
	}

	void Update () {
		BallRollSoundController ();
	}

	void BallRollSoundController () {
		if (ballMovement.onFloorTracker > 0 && myBody.velocity.sqrMagnitude > 0) {
			ballRollAudio.volume = myBody.velocity.sqrMagnitude * 0.0002f;
			ballRollAudio.pitch = 0.4f + ballRollAudio.volume;
			ballRollAudio.mute = false;
		} else {
			ballRollAudio.mute = true;
		}
	}

	public void PlayPickUpSound () {
		audioSource.volume = 0.7f;
		audioSource.PlayOneShot (pickUp);
	}

} // BallSound