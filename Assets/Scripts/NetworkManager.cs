using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    public int type;
    public Vector3 pos;
    public Camera cameraPos;

    //spawnType range
    public int left = 0;
    public int front = 1;
    public int right = 2;
    //Test values
    public int birdOriginXmin = -100;
    public int birdOriginXmax = 100;
    public int birdOriginYmin = 0;
    public int birdOriginYmax = 50;
    public int birdOriginZmin = 0;
    public int birdOriginZmax = 50;

    public GameObject birdsPrefab;
    public GameObject birdsClone;
    //never spawn Prefabs, always spawn Clones of Prefabs (says some American tutorial maker)

    //time interval between every spawn
    public float spawnTime;

    //[SerializeField] Text networkText;

    public GameObject headPrefab;
    public GameObject leftHandPrefab;
    public GameObject rightHandPrefab;

	private bool initiated;

    public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;
    public byte MaxPlayersPerRoom = 2;

    string _gameVersion = "2";
    bool isConnecting;


    // Use this for initialization
    void Start()
    {
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;
        //PhotonNetwork.ConnectUsingSettings(_gameVersion);
		this.initiated = false;
        InvokeRepeating("spawnBirds", 0f, spawnTime);
	
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

    void spawnBirds()
    {

        type = Random.Range(0, 3);
        if (type == left)
        {
            pos = new Vector3(birdOriginXmin, Random.Range(birdOriginYmin, birdOriginYmax), Random.Range(birdOriginZmin, birdOriginZmax));
        }
        else if (type == front)
        {
            pos = new Vector3(Random.Range(birdOriginXmin, birdOriginXmax), Random.Range(birdOriginYmin, birdOriginYmax), birdOriginZmax);

        }
        else if (type == right)
        {
            pos = new Vector3(birdOriginXmax, Random.Range(birdOriginYmin, birdOriginYmax), Random.Range(birdOriginZmin, birdOriginZmax));
        }
        else
        {
            Debug.Log("Unknown Bird type");
        }
        //Vector3 pos = new Vector3(Random.Range(birdOriginXmin, birdOriginXmax), Random.Range(birdOriginYmin, birdOriginYmax), birdOriginZmax);
        birdsClone = PhotonNetwork.Instantiate(birdsPrefab.name, pos, Quaternion.Euler(0, 0, 0), 0);
        birdsClone.transform.LookAt(cameraPos.transform.position);

        //working:
        //birdsClone.transform.LookAt(GameObject.Find("Spawner").transform);

        //trying to lookAt a random range
        //birdsClone.transform.LookAt(new Vector3 (worldTarget.transform.position.x + Random.Range(-3, 3), worldTarget.transform.position.y + Random.Range(-3, 3), worldTarget.transform.position.z + Random.Range(-3, 3)));
    }

}
