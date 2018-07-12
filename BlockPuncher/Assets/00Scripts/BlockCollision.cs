using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        BlockColorChanger controllerScript = collision.gameObject.GetComponent<BlockColorChanger>();
        if(controllerScript != null)
        {
            Destroy(this);
        }
    }
}
