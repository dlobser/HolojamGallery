using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XyloDuplicate : MonoBehaviour {

	public int amount = 12;
	public float rotate = 10;
	public GameObject note;
	public GameObject noteParent;
	// Use this for initialization
	void Start () {
		if (noteParent == null)
			noteParent = this.gameObject;
		for (int i = 0; i < amount; i++) {
			GameObject n = Instantiate (note);
			n.transform.localPosition = noteParent.transform.localPosition;
			n.transform.localScale = noteParent.transform.localScale;
			n.transform.localEulerAngles = noteParent.transform.localEulerAngles;
			n.transform.parent = noteParent.transform;

			n.transform.Rotate (new Vector3 (0, (rotate)*(1+i), 0));
			n.transform.GetChild (0).transform.GetChild(0).GetComponent< AssemblyCSharp.Xylokey > ().note = i;
		}
	}

}
