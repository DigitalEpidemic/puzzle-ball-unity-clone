using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBallTrigger : MonoBehaviour {

	private Rigidbody myBody;

	[SerializeField]
	private AudioSource ballRollAudio, audioSource, stunnedAudio;

	[SerializeField]
	private AudioClip wallHit, stunnedClip;

	private Vector3 velocityLastFrame;
	private Vector3 collisionNormal;
	private float xAxisAngle, xFactor;
	private float yAxisAngle, yFactor;
	private float zAxisAngle, zFactor;

	private EnemyBall enemyBall;
	private MeshRenderer myRenderer;

	void Awake () {
		myBody = GetComponent<Rigidbody> ();
		enemyBall = GetComponent<EnemyBall> ();
		myRenderer = GetComponent<MeshRenderer> ();
	}

	void Update () {
		BallRollSoundController ();
	}

	void LateUpdate () {
		velocityLastFrame = myBody.velocity;
	}

	void BallRollSoundController () {
		if (myBody.velocity.sqrMagnitude > 0) {
			ballRollAudio.volume = myBody.velocity.sqrMagnitude * 0.0002f;
			ballRollAudio.pitch = 0.4f + ballRollAudio.volume;
			ballRollAudio.mute = false;
		} else {
			ballRollAudio.mute = true;
		}
	}

	void SetSoundVolumeOnCollision (Collision collision) {
		// Contacts is an array of contact points
		// Collision normal is a vector that is used to calculate impulses after the collision
		collisionNormal = collision.contacts [0].normal;

		// Vector3.Angle returns angle in degrees between from and to
		xAxisAngle = Vector3.Angle (Vector3.right, collisionNormal);
		xFactor = (1.0f / 8100f) * xAxisAngle * xAxisAngle + (-1 / 45f) + 1f;

		yAxisAngle = Vector3.Angle (Vector3.up, collisionNormal);
		yFactor = (1.0f / 8100f) * yAxisAngle * yAxisAngle + (-1 / 45f) + 1f;

		zAxisAngle = Vector3.Angle (Vector3.forward, collisionNormal);
		zFactor = (1.0f / 8100f) * zAxisAngle * zAxisAngle + (-1 / 45f) + 1f;

		audioSource.volume = (Mathf.Abs (velocityLastFrame.x) * xFactor * 0.001f) +
			(Mathf.Abs (velocityLastFrame.y) * yFactor * 0.001f) +
			(Mathf.Abs (velocityLastFrame.z) * zFactor * 0.001f);
	}

	IEnumerator BallStunned () {
		yield return new WaitForSeconds (2f);
		myRenderer.material.color = new Color (255f, 0f, 227f);
		enemyBall.stunned = false;
	}

	void OnCollisionEnter (Collision target) {
		if (target.gameObject.tag == "Wall") {
			SetSoundVolumeOnCollision (target);

			if (!enemyBall.stunned && (Mathf.Abs (velocityLastFrame.x) * xFactor +
				Mathf.Abs (velocityLastFrame.y) * yFactor +
				Mathf.Abs (velocityLastFrame.z) * zFactor) > 15f) {

				enemyBall.stunned = true;
				myRenderer.material.color = Color.yellow;
				stunnedAudio.PlayOneShot (stunnedClip);
				StartCoroutine (BallStunned ());
			}
		}

		if (target.gameObject.tag == "Ball") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	void OnTriggerEnter (Collider target) {
		if (target.tag == "Ball") {
			gameObject.SendMessage ("GetBallTarget", target.transform);
			gameObject.SendMessage ("CanAttackToggle", true);
		}
	}

	void OnTriggerExit (Collider target) {
		if (target.tag == "Ball") {
			gameObject.SendMessage ("CanAttackToggle", false);
		}
	}

} // EnemyBallTrigger