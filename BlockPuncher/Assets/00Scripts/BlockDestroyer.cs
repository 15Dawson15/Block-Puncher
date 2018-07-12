using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        BlockMovement blockScript = collision.gameObject.GetComponent<BlockMovement>();
        if(blockScript != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
