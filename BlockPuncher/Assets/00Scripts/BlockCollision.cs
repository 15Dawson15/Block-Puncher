using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour {

    public GameObject scoreTower;
    private Scoring score;

    private void Start()
    {
        score = scoreTower.GetComponent<Scoring>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Entered Collision method");
        Material blockMat = collision.gameObject.GetComponent<Renderer>().sharedMaterial;
        BlockMovement blockMove = collision.gameObject.GetComponent<BlockMovement>();
        if(blockMat != null && blockMove != null && blockMat == this.GetComponent<Renderer>().sharedMaterial)
        {

            //Score Increase in here
            score.IncreaseScore(1);
            Debug.Log("Now destroying object...");
            Destroy(collision.gameObject);
        }
    }
}
