using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textureSwap : MonoBehaviour
{
    public Texture[] textures;
    public int texture_start;
    float time = 0f;
    public float timedelay = 3f;

    
    void Update()
    {
        time = time + 1f * Time.deltaTime;
        if(textures.Length != 0)
        {
        if(time >= timedelay)
        {
            
                time = 0f;
                texture_start++;
                texture_start %= textures.Length;
                GetComponent<Renderer>().material.mainTexture = textures[texture_start];
            
        
            
        }
        }
    
    }
}
