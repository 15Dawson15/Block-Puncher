using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEmitter : MonoBehaviour {

    public GameObject player;
    public GameObject block;
    public float timer;
    public float elapsedTime = 0.0f;

    //public Transform blockEmitTransform;

    // Use this for initialization
    void Start () {
        Instantiate(block, this.transform.position, new Quaternion(0,0,0,0));
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
		if(elapsedTime > timer)
        {
            elapsedTime = 0;
            Instantiate(block, RandomPosition(), new Quaternion(0, 0, 0, 0));
        }
	}

    private Vector3 RandomPosition()
    {
        int x = Random.Range(0, 2);
        float xPosition;
        if(x == 0)
        {
            xPosition = -.3f;
            //return new Vector3(-.3f, .5f, this.transform.position.z);
        }
        else
        {
            xPosition = .3f;
            //return new Vector3(.3f, .5f, this.transform.position.z);
        }

        int y = Random.Range(0, 3);
        float yPosition;
        switch (y)
        {
            case 0:
                yPosition = .5f;
                break;
            case 1:
                yPosition = 1f;
                break;
            default:
                yPosition = 1.5f;
                break;
        }

        return new Vector3(xPosition, yPosition, this.transform.position.z);
    }
}
