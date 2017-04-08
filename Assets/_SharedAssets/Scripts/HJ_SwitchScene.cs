using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HJ_SwitchScene : MonoBehaviour {

	public int SwitchToScene;

	void OnTriggerEnter (Collider other){
		if(other.GetComponent<HJ_Baton>()!=null)
				ShowHide ();
	}

	
	void ShowHide(){
		SceneManager.LoadScene (SwitchToScene);
	}
}
