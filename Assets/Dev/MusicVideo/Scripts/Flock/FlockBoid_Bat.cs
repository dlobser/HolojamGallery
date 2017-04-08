using UnityEngine;
using System.Collections;

namespace Flock{
	public class FlockBoid_Bat : FlockBoid {

		Vector3 prevPos;
		float lerpSpeed;

		public Vector2 lerpMinMax;

		// Use this for initialization
		public override void Init () {
			id = Random.value;
			lerpSpeed = Random.Range (lerpMinMax.x, lerpMinMax.y);
			this.transform.position = initialPosition;
		}
		
		// Update is called once per frame
		public override void Animate () {


			this.transform.LookAt (target);
			this.transform.position = Vector3.Lerp(this.transform.position, prevPos,lerpSpeed);
			prevPos = target;
		}
	}
}
