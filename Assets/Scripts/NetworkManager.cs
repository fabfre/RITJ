using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    public int type;
    public Vector3 pos;
    public Camera cameraPos;

    //[SerializeField] Text networkText;

    public GameObject headPrefab;
    public GameObject leftHandPrefab;
    public GameObject rightHandPrefab;

	private bool initiated;


    // Use this for initialization
    void Start()
    {
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;
        //PhotonNetwork.ConnectUsingSettings(_gameVersion);
		this.initiated = false;	
    }

    // Update is called once per frame
    void Update()
    {
		if (!this.initiated && ViveManager.Instance != null && ViveManager.Instance.head != null) {
			
			Debug.Log (PhotonNetwork.connectionState.ToString ());
			Debug.Log (headPrefab.name);
			Debug.Log (ViveManager.Instance.head.transform.position);
			Debug.Log (ViveManager.Instance.head.transform.rotation);


			PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.head.transform.position, ViveManager.Instance.head.transform.rotation, 0);
			PhotonNetwork.Instantiate(leftHandPrefab.name, ViveManager.Instance.leftHand.transform.position, ViveManager.Instance.leftHand.transform.rotation, 0);
			PhotonNetwork.Instantiate(rightHandPrefab.name, ViveManager.Instance.rightHand.transform.position, ViveManager.Instance.rightHand.transform.rotation, 0);
			this.initiated = true;
		}
        //networkText.text = PhotonNetwork.connectionStateDetailed.ToString();

    }
}
