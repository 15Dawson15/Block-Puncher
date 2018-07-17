using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

    private int maxBlocks;
    private float speed;

	// Use this for initialization
	void Start () {
        maxBlocks = 10;
        speed = -2f;
        this.transform.position = new Vector3(0f, .5f, 15f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WaveOne()
    {
        maxBlocks = 10;
        speed = -2f;
    }

    public void WaveTwo()
    {
        maxBlocks = 15;
        speed = -3f;
    }

    public void WaveThree()
    {
        maxBlocks = 20;
        speed = -4f;
    }

    public void WaveFour()
    {
        maxBlocks = 25;
        speed = 4.5f;
        this.transform.position = new Vector3(0f, .5f, -15f);
    }

    public void WaveFive()
    {
        maxBlocks = 30;
        speed = -3.5f;
        this.transform.position = new Vector3(0f, .5f, 15f);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetMaxBlocks()
    {
        return maxBlocks;
    }

    public void SubMaxBlocks()
    {
        maxBlocks -= 1;
    }
}
