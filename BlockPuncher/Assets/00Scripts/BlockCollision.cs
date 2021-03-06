﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour {

    //public GameObject scoreTower;
    //private Scoring score;

    //private void Start()
    //{
    //    score = scoreTower.GetComponent<Scoring>();
    //}

    public static int scoreCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BotMaterial>() == null)
        {
            return;
        }
        //Debug.Log("Entered Collision method");
        Material blockMat = collision.gameObject.GetComponent<BotMaterial>().GetMaterial();
        BlockMovement blockMove = collision.gameObject.GetComponent<BlockMovement>();
        if(blockMat != null && blockMove != null && blockMat == this.GetComponent<Renderer>().sharedMaterial)
        {
            scoreCount += 1;
           // Debug.Log("Now destroying object...");
            Destroy(collision.gameObject);
        }
    }

    public int GetScoreCount()
    {
        return scoreCount;
    }
}
