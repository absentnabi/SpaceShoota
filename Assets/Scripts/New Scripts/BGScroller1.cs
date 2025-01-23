using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BGScroller1 : MonoBehaviour
{
    public float scrollerSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float updatedPosition = Mathf.Repeat(Time.time * scrollerSpeed, tileSizeZ);
        transform.position = startPosition - updatedPosition * Vector3.forward;
    }
}
