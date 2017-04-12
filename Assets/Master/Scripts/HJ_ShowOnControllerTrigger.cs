using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HJ_ShowOnControllerTrigger : MonoBehaviour {

	public string target;
	public GameObject theTarget {get;set;}
	public float timeBetweenSearches = 1;
	float counter = 0;
	public GameObject Show;

	private void Start() {
		theTarget = GameObject.Find(target);
	}

	void Update() {
		counter += Time.deltaTime;
		if (counter > timeBetweenSearches) {
			counter = 0;
			if (theTarget == null)
				theTarget = GameObject.Find(target);
		}
		if (theTarget != null) { 
			if (theTarget.GetComponent<SteamVR_TrackedController> ().triggerPressed) {
				Show.SetActive (true);
			} else if (Show.activeInHierarchy) {
				Show.SetActive (false);
			}
		}
	}
}
