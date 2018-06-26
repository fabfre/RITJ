using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

	private TextMesh ammoText3D;
	private ScoreValues ammoV;

	public Leaveblower leaveBlower;

	void Start(){

		GameObject d = GameObject.Find ("Texts/AmmoText3D");
		ammoText3D = d.GetComponent<TextMesh>();
	}

	public void loadAmmo(){
		Vector3 lbpos = GameObject.Find ("Leaveblower").transform.position;
		float dis = Vector3.Magnitude (lbpos - transform.position);

		if (dis < 2){
			leaveBlower.Load ();
			Destroy (this.gameObject);
		}
	}

}
