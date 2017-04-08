using UnityEngine;
using System.Collections;

public class setRenderOrder : MonoBehaviour {

	public int sort;
	// Use this for initialization
	void Start () {
		transform.GetComponent<Renderer> ().sortingOrder = sort;
	}

}
