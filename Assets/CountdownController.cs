﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownController : Photon.PunBehaviour, IPunObservable {


    [SerializeField]
    private Text countdown;
    [SerializeField]
    private Text finishText;

    [SerializeField]
    private float timeLeft;

    [SerializeField]
    private float timeOutChangeScene;

	[SerializeField]
	private ScoreValues scoreValues;


	void Start () {
       
    }

    void Update () {
        timeLeft -= Time.deltaTime;
        countdown.text = "Time left: " + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            timeLeft = 0;
			finishText.text = "GAME OVER :( \n" + "Your Score: " + scoreValues.score;
            //gun.GetComponent<GunControllerScript>().enabled = false;
            //stopGamePlay();
            //Application.LoadLevel("startScene");
            startTimeOut();
        }
    }

    void startTimeOut()
    {
        timeOutChangeScene -= Time.deltaTime;
        if(timeOutChangeScene < 0)
        {
            //StartCoroutine(LoadStartScene());
            timeOutChangeScene = 0;
			if (PhotonNetwork.isMasterClient) {
				PhotonNetwork.LoadLevel ("Lobby");
			}
        }
    }

    IEnumerator LoadStartScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StartScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

	void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext (timeLeft);
			stream.SendNext (timeOutChangeScene);
		} else {
			timeLeft = (float)stream.ReceiveNext ();
			timeOutChangeScene = (float)stream.ReceiveNext ();
		}
	}

}
