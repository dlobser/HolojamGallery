using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTD_DestroyOnCollision : MonoBehaviour {

	public GameObject Explosion;

	void OnCollisionEnter(Collision other)
	{
		GameObject ex = Instantiate (Explosion);
		ex.transform.position = this.transform.position;
		Destroy (this.gameObject);

	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("trigger");
		GameObject ex = Instantiate (Explosion);
		ex.transform.position = this.transform.position;
		Destroy (this.gameObject);

	}

}
