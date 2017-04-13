using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FireTrigger : MonoBehaviour {


	//particle system to be triggered
	public ParticleSystem fire;

	//speed of character
	public int velocity = 0;

	
	void Start() {

	}

	void Update ()
	{
		bool down = Input.GetKeyDown(KeyCode.Space);

		if (down) {
			fire.Play ();
		}



		if (velocity > 10) {
			fire.Play ();
		}

	}
	



}
