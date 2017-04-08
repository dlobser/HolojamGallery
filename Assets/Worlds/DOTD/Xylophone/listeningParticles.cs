using UnityEngine;
using System.Collections;

public class listeningParticles : MonoBehaviour {

    public float lifeTime = 1f;
    public float decay = 1f;
    ParticleSystem particles;
    //public float speed = 10f;

    private float _timer;
	// Use this for initialization
	void Start () {
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
	}
	
	// Update is called once per frame
	void Update () {
        if (_timer > 0 && Time.time > _timer + lifeTime) 
        {
            _timer = 0f;
            particles.Stop();
        }
	}

	// in case of complaint, add 'SendMessageOptions.DontRequireReceiver'
	// as a third parameter to SendMessage();
	public void StartParticles(){
		//Debug.Log ("message StartParticles received with speed: " + speed);
		//particles.startSpeed = speed;
        particles.time = 0f;
		particles.Play ();
        _timer = Time.time;
        
	}
}
