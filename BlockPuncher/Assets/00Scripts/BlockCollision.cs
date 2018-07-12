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
        //BlockMovement blockScript = collision.gameObject.GetComponent<BlockMovement>();
        //if (blockScript != null)
        //{
        //    Destroy(collision.gameObject);
        //}

        Debug.Log("Entered Collision method");
        Material blockMat = collision.gameObject.GetComponent<Renderer>().material;
        if(blockMat != null && blockMat == this.GetComponent<Renderer>().material)
        {
            Debug.Log("Now destroying object...");
            Destroy(collision.gameObject);
        }
    }
}
