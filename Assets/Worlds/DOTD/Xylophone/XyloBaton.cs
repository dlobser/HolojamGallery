using UnityEngine;
using System.Collections;

public class XyloBaton : MonoBehaviour {

    public Vector3 direction = Vector3.zero;
    Vector3 lastFrameLocation = Vector3.zero;
	
	// Update is called once per frame
	void Update () {
        Vector3 v = this.transform.position;
        direction = v - lastFrameLocation;
        lastFrameLocation = v;
	}
}
