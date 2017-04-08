using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTD_AudioRandomPitch : MonoBehaviour {

	public AudioSource audi;
	public Vector2 minMax;
	// Use this for initialization
	void Start () {
		audi.pitch = Random.Range (minMax.x, minMax.y);
	}

}
