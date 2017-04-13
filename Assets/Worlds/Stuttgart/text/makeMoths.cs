using UnityEngine;
using System.Collections;

public class makeMoths : MonoBehaviour {

	public GameObject moth;			

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 100; i++) {
			Instantiate(moth,new Vector3(Random.Range(-100f,100f),Random.Range(0f,10f),Random.Range(-100f,100f)),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
