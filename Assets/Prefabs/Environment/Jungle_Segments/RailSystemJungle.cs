using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSystemJungle : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _segmentLength;

    private void Update()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var segment = transform.GetChild(i);

            if (segment.position.z <= (-2 * _segmentLength))
            {
                segment.position = new Vector3(
                    segment.position.x,
                    segment.position.y,
                    // -2 because the first segment starts at 0, i. e. the origin,
                    // and we remove a segment once it passes -2 * segment length.
                    (transform.childCount - 2) * _segmentLength);
            }

            segment.Translate(_speed * Vector3.back * Time.deltaTime, Space.World);
        }
    }
}
