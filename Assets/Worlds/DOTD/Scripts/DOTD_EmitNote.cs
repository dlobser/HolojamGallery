using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTD_EmitNote : MonoBehaviour {

	public GameObject note;
	public float speed;
	float counter;
	
	void Update () {
		counter += Time.deltaTime*speed;
		if (counter > 1) {
			GameObject g = Instantiate (note, this.transform.position, this.transform.rotation);
			counter = 0;
		}
	}
}
