using UnityEngine;
using System.Collections;

public class WaterTextureScroll : MonoBehaviour
{
    public float speed;

    private float offset = 0;

    private Renderer rend;

    void Start()
    {
        this.rend = GetComponent<Renderer>();
    }

	void Update()
    {
        offset += Time.deltaTime * speed;
        rend.materials[0].SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
