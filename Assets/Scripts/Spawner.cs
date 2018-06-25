using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : Photon.PunBehaviour {

    public int type;
    public Vector3 pos;
	public Camera cameraPos;

    //spawnType range
    public int left = 0;
    public int front = 1;
    public int right = 2;

    //spawnBirds origin range
    /*
    public int birdOriginXmin = -200;
    public int birdOriginXmax = 200;
    public int birdOriginYmin = 0;
    public int birdOriginYmax = 100;
    public int birdOriginZmin = 0;
    public int birdOriginZmax = 100;
    */
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
    public float spanTime;

    private void Start()
    {
        //InvokeRepeating("spawnBirds", 0f, spanTime);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
            spawnBirds();
    }

    void spawnBirds() {

        type = Random.Range(0, 3);
        if (type == left)
        {
            pos = new Vector3(birdOriginXmin, Random.Range(birdOriginYmin, birdOriginYmax), Random.Range(birdOriginZmin, birdOriginZmax));
        }
        else if(type == front)
        {
            pos = new Vector3(Random.Range(birdOriginXmin, birdOriginXmax), Random.Range(birdOriginYmin, birdOriginYmax), birdOriginZmax);

        }
        else if(type == right)
        {
            pos = new Vector3(birdOriginXmax, Random.Range(birdOriginYmin, birdOriginYmax), Random.Range(birdOriginZmin, birdOriginZmax));
        }
        else
        {
            Debug.Log("Unknown Bird type");
        }
        //Vector3 pos = new Vector3(Random.Range(birdOriginXmin, birdOriginXmax), Random.Range(birdOriginYmin, birdOriginYmax), birdOriginZmax);
		birdsClone = PhotonNetwork.Instantiate(birdsPrefab.name, pos, Quaternion.Euler(0,0,0), 0);
//		birdsClone = Instantiate(birdsPrefab, pos, Quaternion.Euler(0,0,0)) as GameObject;
		birdsClone.transform.LookAt(cameraPos.transform.position);

        //working:
        //birdsClone.transform.LookAt(GameObject.Find("Spawner").transform);

        //trying to lookAt a random range
        //birdsClone.transform.LookAt(new Vector3 (worldTarget.transform.position.x + Random.Range(-3, 3), worldTarget.transform.position.y + Random.Range(-3, 3), worldTarget.transform.position.z + Random.Range(-3, 3)));
    }
    

}
