using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTD_AttachTargetToBat : MonoBehaviour {

	public GameObject avatarParent;
	DOTD_BatTarget[] targets;
	public GameObject BatFlock;
	// Use this for initialization
	void Start () {
		for (int j = 0; j < avatarParent.transform.childCount; j++) {
			targets = avatarParent.transform.GetChild(j).GetComponentsInChildren<DOTD_BatTarget> ();
			for (int i = 0; i < targets.Length; i++) {
				GameObject BF = Instantiate (BatFlock);
				Flock.FlockManipulator_CentroidLerped flockManip = BF.GetComponentInChildren<Flock.FlockManipulator_CentroidLerped> ();
				flockManip.attractor = targets [i].gameObject;
				flockManip.GetComponent<TransformUniversal> ().translateNoiseOffset = new Vector3 (Random.value * 10, Random.value * 10, Random.value * 10);
			}
		}

	}

}
