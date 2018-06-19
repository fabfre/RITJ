using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    [SerializeField]
    private GameObject _coconutPrefab;

    [SerializeField]
    private float _throwingForce = 1;

    private bool _closeToPlayer;

    private GameObject _currentCoconut;

    public void GrabCoconut()
    {
        /*
        var hand = transform.Find("rig/MCH-hand_ik_socket.R");
        if (hand == null) Debug.Log("asdf");
        _currentCoconut = Instantiate(_coconutPrefab, hand.transform.position, Quaternion.identity);
        _currentCoconut.GetComponent<Rigidbody>().isKinematic = true;
        _currentCoconut.transform.SetParent(hand);
        */
    }

    public void ThrowCoconut()
    {
        var hand = transform.Find("rig/MCH-hand_ik_socket.R");
        if (hand == null) Debug.Log("asdf");
        _currentCoconut = Instantiate(_coconutPrefab, hand.transform.position, Quaternion.identity);
        //_currentCoconut.transform.SetParent(null);
        var rigidBody = _currentCoconut.GetComponent<Rigidbody>();
        //rigidBody.isKinematic = false;
        Vector3 dir = Vector3.zero - transform.position;
        rigidBody.velocity = (new Vector3(dir.x, 0, dir.z)).normalized * _throwingForce;
    }

	private void Start()
	{
        _closeToPlayer = IsInRange();

        if (_closeToPlayer)
        {
            GetComponent<Animator>().SetTrigger("attack");
        }
	}
	
	private void Update()
	{
		if (!_closeToPlayer && IsInRange())
        {
            _closeToPlayer = true;
            GetComponent<Animator>().SetTrigger("attack");
        }

        if (_closeToPlayer && !IsInRange())
        {
            _closeToPlayer = false;
            GetComponent<Animator>().SetTrigger("idle");
        }
    }

    private bool IsInRange()
    {
        return transform.position.z > -10 && transform.position.z < 10;
    }
}
