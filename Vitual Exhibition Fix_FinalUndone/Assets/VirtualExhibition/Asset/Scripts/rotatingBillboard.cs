using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingBillboard : MonoBehaviour
{
    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed*Time.deltaTime);
    }
}
