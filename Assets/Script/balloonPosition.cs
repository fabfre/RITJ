using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += transform.forward * 1 * Time.deltaTime * 2f;

	}
}
