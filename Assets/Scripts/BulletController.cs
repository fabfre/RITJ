using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletController : Photon.MonoBehaviour {

	public ScoreValues scoreValues;
	public Text scoreText;
    public int zeppelinAimScore;
	public int luftballonAimScore;

	public int KrokodilAimScore;
	public TextMesh text3D;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LuftballonAim"))
        {
            PhotonView photonView = this.photonView;
            SetCounterText(other.gameObject.GetPhotonView().viewID);
            PhotonNetwork.RaiseEvent(1, other.gameObject.GetPhotonView().viewID, true, null);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("ZeppelinAim"))
        {
            SetCounterText(other.gameObject.GetPhotonView().viewID);
            PhotonNetwork.RaiseEvent(1, other.gameObject.GetPhotonView().viewID, true, null);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

		if (other.gameObject.CompareTag("Krokodil"))
		{
			SetCounterText(other.gameObject.GetPhotonView().viewID);
			PhotonNetwork.RaiseEvent(1, other.gameObject.GetPhotonView().viewID, true, null);
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
    }

    public void SetCounterText(int other)
    {
        if (PhotonView.Find(other).gameObject.CompareTag("ZeppelinAim"))
        {
            scoreValues.score = scoreValues.score + zeppelinAimScore;
        }
        if (PhotonView.Find(other).gameObject.CompareTag("LuftballonAim"))
        {
            scoreValues.score = scoreValues.score + luftballonAimScore;
        }
		if (PhotonView.Find(other).gameObject.CompareTag("Krokodil"))
		{
			scoreValues.score = scoreValues.score + KrokodilAimScore;
		}

		text3D.text = "Score: " + scoreValues.score.ToString();
		PhotonNetwork.RaiseEvent(0, text3D.text, true, null);
    }

    private void OnEnable()
    {
        PhotonNetwork.OnEventCall += this.OnEvent;
    }

    private void OnDisable()
    {
        PhotonNetwork.OnEventCall -= this.OnEvent;
    }

    void OnEvent(byte eventcode, object content, int senderid)
    {
        Debug.Log("OnEvent CONTENT: " + content);

        if (eventcode == 0)
        {
            scoreText.text = content.ToString();
        }

        if (eventcode == 1)
        {
            Debug.Log("OnEvent CODE = 1: " + content);
            PhotonNetwork.Destroy(PhotonView.Find((int)content));
        }
    }
}