using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveManager : MonoBehaviour {

	public GameObject head;
	public GameObject leftHand;
	public GameObject rightHand;

	//Singleton
	public static ViveManager Instance;

	// Use this for initialization
	void Awake() {
		if (Instance == null) {
			Instance = this;
		}
	}

	void OnDestroy() {
		if (Instance == this) {
			Instance = null;
		}
	}

	void Start() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
