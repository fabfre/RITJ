﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeppelinBackToFront : MonoBehaviour {
	
	//spawnObject origin range
	public int originXmin = -200;
	public int originXmax = 250;
	public int originYmin = 200;
	public int originYmax = -200;
	public int originZmin = 300;
	public int originZmax = 200;

	public GameObject objectPrefab;

	//time interval between every spawn, every 1 s
	static float spanInterval = 6f;
	private float spanTime = spanInterval;

	private float sizeOfObjectLength;
	private float sizeOfObjectWidth;
	private float sizeOfObjectHeight;

	List<Vector3> SpotTaken = new List<Vector3>();

	private void Start()
	{

	}

	private void Update()
	{

		spawnObjects();
	}

	void spawnObjects()
	{	
		// set random position
		Vector3 pos = new Vector3(Random.Range(originXmin, originXmax), Random.Range(originYmin, originYmax), Random.Range(originZmin, originZmax));

		// spwan objects at interval
		spanTime -= Time.deltaTime;

		if (spanTime <= 0)
		{
			GameObject objectClone = Instantiate(objectPrefab, pos, objectPrefab.transform.rotation) as GameObject;

			spanTime = spanInterval;

			sizeOfObjectLength = objectClone.transform.localScale.x;
			sizeOfObjectWidth = objectClone.transform.localScale.y;
			sizeOfObjectHeight = objectClone.transform.localScale.z;

			// Stopping Instantiated GameObjects overlapping

			foreach (Vector3 SpotTaken in SpotTaken) {
				if (pos.x >= SpotTaken.x - sizeOfObjectLength && pos.x <= SpotTaken.x + sizeOfObjectLength) {
					if (pos.y >= SpotTaken.y - sizeOfObjectWidth && pos.z <= SpotTaken.y + sizeOfObjectWidth) {  
						if (pos.z >= SpotTaken.z - sizeOfObjectHeight && pos.z <= SpotTaken.z + sizeOfObjectHeight) {  

							//If the width or length is near another one of these objects, then it tries again
							spawnObjects(); 
							return;
						}
					}
				}
			}

			objectClone.transform.LookAt(GameObject.Find("target").transform);
			objectClone.transform.Rotate (new Vector3(0, 90, 90),Space.Self);

		}
	}
}
