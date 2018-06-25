using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager1 : MonoBehaviour
{
    //[SerializeField] Text networkText;

    public GameObject headPrefab;
    public GameObject leftHandPrefab;
    public GameObject rightHandPrefab;

    public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;
    public byte MaxPlayersPerRoom = 2;

    string _gameVersion = "5";
    bool isConnecting;


    // Use this for initialization
    void Start()
    {
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());

    }

    //callbacks von Photon

    public virtual void OnConnectedToMaster()
    {
        Debug.Log("Network Manager: OnConnectedToMaster() was called by PUN");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby()
    {
		PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("Network Manager:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.");
        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
    }

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom()
    {
        Debug.Log("Network Manager: OnJoinedRoom() called by PUN. Now this client is in a room.");
        PhotonNetwork.Instantiate(headPrefab.name, ViveManager.Instance.head.transform.position, ViveManager.Instance.head.transform.rotation, 0);
        PhotonNetwork.Instantiate(leftHandPrefab.name, ViveManager.Instance.leftHand.transform.position, ViveManager.Instance.leftHand.transform.rotation, 0);
        PhotonNetwork.Instantiate(rightHandPrefab.name, ViveManager.Instance.rightHand.transform.position, ViveManager.Instance.rightHand.transform.rotation, 0);

        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("isMasterClient");
            //GameObject.Find("LeftControllerScriptAlias(Clone)").SetActive(false);
            //GameObject.Find("RightControllerScriptAlias(Clone)").SetActive(false);

            //leftHandPrefab.SetActive(false);
            //rightHandPrefab.SetActive(false);
        }
        //PhotonNetwork.Instantiate(firstWeapon.name, firstWeapon.transform.position, firstWeapon.transform.rotation, 0);

    }
}
