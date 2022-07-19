using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderDistanceAuto : MonoBehaviour
{

    public Transform player;

    public float distanceThreshold = 40f;

    public float distance;
    private MeshRenderer thisMeshRenderer;


    private void Awake()
    {
        thisMeshRenderer = this.GetComponent<MeshRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if(distance > distanceThreshold)
        {
            thisMeshRenderer.enabled = false;
        }
        else
        {
            thisMeshRenderer.enabled = true;
        }
    }
}
