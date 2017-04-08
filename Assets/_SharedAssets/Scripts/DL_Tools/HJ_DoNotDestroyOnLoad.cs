using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HJ_DoNotDestroyOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	

}
