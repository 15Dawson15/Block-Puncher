using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour {

    public float speed;
    private Rigidbody blockBody;

	// Use this for initialization
	void Start () {
        blockBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        blockBody.velocity = new Vector3(0, 0, speed);
	}
}
