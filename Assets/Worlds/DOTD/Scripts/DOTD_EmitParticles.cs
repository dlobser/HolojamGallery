using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTD_EmitParticles : MonoBehaviour {

	public int amount;
	public ParticleSystem parti;
	// Use this for initialization
	void Start () {
		parti.Emit (amount);
	}

}
