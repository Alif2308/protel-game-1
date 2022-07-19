using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialSwap : MonoBehaviour
{
    public Material[] mat;
    public int element_start;
    Renderer rend;
    float time = 0f;
    public float timedelay = 3f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    void Update()
    {
        time = time + 1f * Time.deltaTime;

        if(time >= timedelay)
        {
            time = 0f;
            element_start++;
            element_start %= mat.Length;
            rend.sharedMaterial = mat[element_start];
        }
    
    }
}
