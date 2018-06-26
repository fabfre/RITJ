using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocSpawner : Photon.MonoBehaviour
{
    public float radius;
    public GameObject crocPrefab;
    public float minDelay;
    public float maxDelay;

    private float _delay;
    private float _timer;

    private void Start()
    {
        _delay = Random.Range(minDelay, maxDelay);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _delay)
        {
            _timer = 0;
            _delay = Random.Range(minDelay, maxDelay);
            SpawnSchnappi();
        }
    }

    void SpawnSchnappi()
    {
        float rand = Random.Range(0, 2 * Mathf.PI);
        var pos = new Vector3(Mathf.Cos(rand) * radius, 0, Mathf.Sin(rand) * radius);
        PhotonNetwork.Instantiate(crocPrefab.name, pos, Quaternion.Euler(0, 0, 0), 0);
    }
}
