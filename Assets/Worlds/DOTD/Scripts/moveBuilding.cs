using UnityEngine;
using System.Collections;

public class moveBuilding : MonoBehaviour {

    public float endPos = 100f;
    public float startPos = -100f;
    public float speed;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float sc = (Mathf.Cos(Mathf.PI * 2 * ((startPos + transform.localPosition.x) / (endPos - startPos))) * -.5f) + .5f;
        transform.localScale = new Vector3(sc, sc, sc);
        transform.Translate(speed * Time.deltaTime, 0, 0);
        bool chop = false;
        if (Mathf.Sign(speed) >= 0 && transform.localPosition.x > endPos)
            chop = true;
        if (chop)
        {
            float diff = transform.localPosition.x - endPos;
            transform.localPosition = new Vector3(startPos + diff, transform.localPosition.y, transform.localPosition.z);
            
        }
	}
}
