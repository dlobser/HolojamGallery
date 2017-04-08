using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
    public class Xylokey : MonoBehaviour
    {

        public XyloHead head;
        public AudioSource audi;
//        private BoxCollider _collider;
        public float note = 0f;
        public float transpose = 0f;

        public float colliderDisableTime = 0.5f;
        private float _timer;

        public float batonFactor = 10f;
        private bool hittable = true;
        public listeningParticles particles;
        private GameObject _lastHitObject;

        public float hitFrequency = 1f;
        public float hitAmplitude = 2f;
        public float hitAmplitudeDecay = 2f;

        private float amp = 0f;

        private float dir = 1f;
        private float hitTime = 0f;



        // Use this for initialization
        void Start()
        {
//            _collider = this.GetComponent<BoxCollider>();
        }

        // Update is called once per frame
//        void Update()
//        {
//
//
//            if (_timer > 0 && Time.time > _timer + colliderDisableTime)
//            {
//                _timer = 0f;
//                hittable = true;
//            }
//
//            if (Mathf.Abs(amp) < 0.5)
//            {
//                amp = 0f;
//                hitTime = 0f;
//            }
//            else if (amp > 0)
//            {
//                amp -= hitAmplitudeDecay * Time.deltaTime;
//                hitTime += Time.deltaTime;
//            }
//
//            else if (amp < 0)
//            {
//                amp += hitAmplitudeDecay * Time.deltaTime;
//                hitTime += Time.deltaTime;
//            }
//            
//            this.transform.localEulerAngles = new Vector3(amp * Mathf.Sin(hitTime * hitFrequency), 0f, 0f);
//        }

        void OnCollisionEnter(Collision other)
        {
            Debug.Log("Collision");
//            BatonController baton = other.gameObject.GetComponent<BatonController>();
//            bool o = (_lastHitObject == null ? (true) : (_lastHitObject == other.gameObject ? false : true));
//            if (baton && hittable)
//            {
                Debug.Log("hit");
                _timer = Time.time;
                hittable = false;

//                Vector3 v = this.transform.position + _collider.center;

//                if (baton.direction.y < 0)
//                {
//                    dir = -1;
//                    Debug.Log("above");
//                }
//                else
//                {
//                    dir = 1;
//                    Debug.Log("below");
//                }

//                amp += hitAmplitude * baton.direction.magnitude * dir * batonFactor;
//                Debug.Log(amp);
                //AUDIO
			float force = other.collider.attachedRigidbody.velocity.magnitude;
//			Debug.Log (force*1e7f);
			audi.volume = force*1e7f;//1f;//force;// * baton.direction.magnitude * batonFactor;
                audi.pitch = Mathf.Pow(2, (note + transpose) / 12.0f);
				
			if(audi.pitch>.001f)
                audi.Play();

                //PARTICLES
                if (particles)
                {
                    particles.StartParticles();
                }
//			if(!audi.isPlaying){
                //HEAD COROUTINE
			head.StartCoroutine("InflateHead", force*1e5f);// baton.direction.magnitude);
//            }
//			}
        }
    }
}

