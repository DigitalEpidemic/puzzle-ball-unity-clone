using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {

	void OnTriggerEnter (Collider target) {
		if (target.tag == "Ball") {
			//StartCoroutine (LoadMainMenu ());
			SceneManager.LoadScene ("MainMenu");
		}
	}

	IEnumerator LoadMainMenu () {
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene ("MainMenu");
	}

} // ExitLevel