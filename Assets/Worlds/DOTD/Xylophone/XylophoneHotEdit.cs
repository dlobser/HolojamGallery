using UnityEngine;
using System.Collections;


namespace AssemblyCSharp
{
    [ExecuteInEditMode]
    public class XylophoneHotEdit : MonoBehaviour {

    public Xylokey[] keys;
    public XyloHead[] heads;

    public XyloBoneHead[] bodies;

    public float xyloheadDecay;
    public float xylokeydisabletime = 0.1f;

		public float keyFreq = 10f;
		public float keyAmp = 30f;
	// Use this for initialization
	void Start () {

        bodies = this.GetComponentsInChildren<XyloBoneHead>();
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].transform.eulerAngles = new Vector3(0f, 277.5f + 15f * i, 0f);
        }

        keys = this.GetComponentsInChildren<Xylokey>();

        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].note = i;
            //keys[i].transform.localEulerAngles = Vector3.zero;
        }

        heads = this.GetComponentsInChildren<XyloHead>();


	}
	
	// Update is called once per frame
	void Update () {

        keys = this.GetComponentsInChildren<Xylokey>();

        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].note = i;
            keys[i].colliderDisableTime = xylokeydisabletime;
				keys[i].hitFrequency = keyFreq;
				keys[i].hitAmplitude = keyAmp;
            //keys[i].transform.eulerAngles = new Vector3(0f, 277.5f + 15f * i, 0f);
        }

        heads = this.GetComponentsInChildren<XyloHead>();
        for (int i = 0; i < heads.Length; i++)
        {
            heads[i].decay = xyloheadDecay;
        }
	}
}

}
