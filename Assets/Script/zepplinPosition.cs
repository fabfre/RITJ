using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zepplinPosition : MonoBehaviour {

	void Start () {
 
	}

	void Update () {
		transform.localPosition += transform.forward * -1 * Time.deltaTime * 2f;
	}
}
