using UnityEngine;
using System.Collections;

public class copyTransformsName : MonoBehaviour {

    public string target;
    public GameObject theTarget {get;set;}
    public float timeBetweenSearches = 1;
    float counter = 0;

    private void Start() {
        theTarget = GameObject.Find(target);
    }

    void Update() {
        counter += Time.deltaTime;
        if (counter > timeBetweenSearches) {
            counter = 0;
            if (theTarget == null)
                theTarget = GameObject.Find(target);
        }
        if (theTarget != null) { 
            DLUtility.copyPositionRotation(theTarget, transform.gameObject);
        }
	}
}
