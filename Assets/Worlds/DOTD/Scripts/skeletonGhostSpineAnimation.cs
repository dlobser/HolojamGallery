using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class skeletonGhostSpineAnimation : MonoBehaviour {


	public int smooth = 3;
	public int smoothIncrease = 2;

	public float noiseSpeed;
	public float noiseAmount;

	List<Vector3[]> averages;
	List<Vector3[]> averageRotation;

	void Start () {
		averageRotation = new List<Vector3[]>();
		averages = new List<Vector3[]>();
		for (int i = 0; i < this.transform.GetChild(1).childCount; i++) {
			averages.Add(new Vector3[smooth+smoothIncrease*i]);
			averageRotation.Add(new Vector3[smooth+smoothIncrease*i]);
		}
	}
	
	void Update () {
		for (int i = 0; i < averages.Count; i++) {
			Vector3 pos = avg(averages[i],getKid(this.transform.GetChild (2).transform.GetChild(0),i,0).position,false);//.transform.GetChild(i).transform.position);
			pos+=pNoise(pos,noiseSpeed*Time.time,noiseAmount*i);
			this.transform.GetChild(1).transform.GetChild(i).transform.position = pos;

			Vector3 rot = avg(averageRotation[i],getKid(this.transform.GetChild (2).transform.GetChild(0),i,0).eulerAngles,true);//.transform.GetChild(i).transform.position);
			this.transform.GetChild(1).transform.GetChild(i).transform.eulerAngles = rot;
		}
	}

	Transform getKid( Transform t , int i , int index ){
		if (index < i) {
			return getKid (t.GetChild (0), i, ++index);
		} else {
			return t;
		}
	}

	Vector3 avg(Vector3[] vecA, Vector3 vec, bool isRotation){

		for (int i = 0; i < vecA.Length-1; i++) {
			vecA[i] = vecA[i+1];
		}

		int c = vecA.Length - 1;
		Vector3 newVec = vec;

		if (isRotation) {
			newVec.x = Mathf.Abs (vec.x - vecA [c - 1].x) > 180 ? (vec.x - 360) : (vec.x);
			newVec.y = Mathf.Abs (vec.y - vecA [c - 1].y) > 180 ? (vec.y - 360) : (vec.y);
			newVec.z = Mathf.Abs (vec.z - vecA [c - 1].z) > 180 ? (vec.z - 360) : (vec.z);
		}

		vecA [c] = newVec;

		Vector3 t = Vector3.zero;

		for (int i = 0; i < vecA.Length; i++) {
			t += vecA[i];
		}

		t /= vecA.Length;
		return t;
	}

	Vector3 pNoise(Vector3 pos,float time, float scalar){
		return new Vector3 (
			Mathf.PerlinNoise (pos.x + time, pos.y + time)-.5f,
			Mathf.PerlinNoise (pos.y + time, pos.z + time)-.5f,
			Mathf.PerlinNoise (pos.z + time, pos.x + time)-.5f)*scalar;
	}
}
