using UnityEngine;
using System.Collections;

public class adjustUV : MonoBehaviour {

	// Use this for initialization
	public Vector2 scale;
//	Vector2 off = Vector2.zero;
	public float speed;
	public float adjuster=.01f;
	float counter;
//	bool trig = false;
	// Use this for initialization
	void Start () {
//		offUV (-.666f);
//		scaleUV (new Vector2 (3, 2));
		scaleUV (scale);
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime * speed;

		if (counter > 1) {
			counter = 0;
			offUV(.5f+adjuster);
		}


	}

	void scaleUV(Vector2 offs){
		Vector2[] uvs = GetComponent<MeshFilter> ().mesh.uv;
		for (int i = 0; i < uvs.Length; i++) {
			uvs[i]=Vector3.Scale(uvs[i],offs);
		}
		GetComponent<MeshFilter> ().mesh.uv = uvs;
	}

	void offUV(float o){
		Vector2[] uvs = GetComponent<MeshFilter> ().mesh.uv;
		for (int i = 0; i < uvs.Length; i++) {
			uvs[i].x+=o;
		}
		GetComponent<MeshFilter> ().mesh.uv = uvs;
	}

}
