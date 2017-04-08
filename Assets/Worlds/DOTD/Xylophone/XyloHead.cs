using UnityEngine;
using System.Collections;

public class XyloHead : MonoBehaviour {

    public float decay = 2f;
    AudioSource audi;

    void Start()
    {
        audi = GetComponent<AudioSource>();
    }


//    void Update()
//    {
//        if (audi.volume > 0)
//        {
//            audi.volume -= decay * Time.deltaTime;
//        }
//        else
//        {
//            audi.Stop();
//        }
//    }

    IEnumerator InflateHead(float force)
    {
        Vector3 oScale = this.transform.localScale;
        for (int i = 0; i < 10; i++)
        {
            //Debug.Log("growing");
            this.transform.localScale += oScale * force;
            yield return new WaitForSeconds(0.001f);
        }

        for (int i = 0; i < 10; i++)
        {
            //Debug.Log("shrinking");
            this.transform.localScale -= oScale * force;
            yield return new WaitForSeconds(0.001f);
        }
    }

    
}
