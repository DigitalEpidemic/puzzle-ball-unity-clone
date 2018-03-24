using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour {

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip pickUp;

	void Start () {
		
	}

	void Update () {
		
	}

	public void PlayPickUpSound () {
		audioSource.volume = 0.7f;
		audioSource.PlayOneShot (pickUp);
	}

} // BallSound