using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        BlockMovement blockScript = collision.gameObject.GetComponent<BlockMovement>();
        if(blockScript != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
