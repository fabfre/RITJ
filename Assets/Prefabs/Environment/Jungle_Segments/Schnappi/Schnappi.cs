using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schnappi : MonoBehaviour
{
    private enum State
    {
        Swimming,
        Climbing,
        Idle,
        Attacking,
        Fleeing
    }

    [SerializeField]
    private float _swimSpeed;

    [SerializeField]
    private Vector3 _climbOffset;

    private State state;

    private float _idleTimer = 5.0f;

    private void Start()
    {
        // Move the crocodile a bit down for swimming, because the raft is at y = 0, so the water is a bit lower.
        transform.Translate(Vector3.up * -0.35f);

        transform.LookAt(Vector3.zero + Vector3.up * transform.position.y);

        state = State.Swimming;
    }

    private void Update()
	{
        switch (state)
        {
            case State.Swimming:
                UpdateSwimming();
                break;
            case State.Climbing:
                UpdateClimbing();
                break;
            case State.Idle:
                UpdateIdle();
                break;
            case State.Attacking:
                UpdateAttacking();
                break;
            case State.Fleeing:
                UpdateFleeing();
                break;
            default:
                throw new System.Exception("Undefined state!");
        }
	}

    private void UpdateSwimming()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _swimSpeed);

        if (Mathf.Abs(transform.position.x) <= Mathf.Abs(_climbOffset.x)
            && Mathf.Abs(transform.position.z) <= Mathf.Abs(_climbOffset.z))
        {
            state = State.Climbing;
            GetComponent<Animator>().SetTrigger("climb");
        }
    }

    private void UpdateClimbing()
    {
        if (transform.position.y < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 0.3f);
        }
    }

    private void UpdateIdle()
    {
        _idleTimer -= Time.deltaTime;

        if (_idleTimer <= 0)
        {
            Flee();
        }
    }

    private void UpdateAttacking()
    {

    }

    private void UpdateFleeing()
    {

    }

    private void ClimbedCallback()
    {
        state = State.Idle;
        GetComponent<Animator>().SetTrigger("idle");
    }

    private void PlayGrowlSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void Flee()
    {
        if (state != State.Fleeing)
        {
            state = State.Fleeing;
            GetComponent<Animator>().SetTrigger("flee");
        }
    }

    private void RemoveCrocodile()
    {
        Destroy(gameObject);
    }

    public void Attack()
    {
        if (state == State.Idle)
        {
            state = State.Attacking;
            GetComponent<Animator>().SetTrigger("attack");
        }
    }

    private void ResetIdle()
    {
        state = State.Idle;
        GetComponent<Animator>().SetTrigger("idle");
    }
}
