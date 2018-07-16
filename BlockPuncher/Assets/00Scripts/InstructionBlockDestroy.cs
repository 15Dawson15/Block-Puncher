using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBlockDestroy : MonoBehaviour {

    private static bool startGame = false;
    public GameObject textBoxes;
    public GameObject[] textThings;
    private InstructionBlockCounter count;
    public GameObject controlCount;

	// Use this for initialization
	void Start () {
        count = controlCount.GetComponent<InstructionBlockCounter>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Counter: " + counter);
		if(count.GetCounter() == 4)
        {
            //Debug.Log("Hello");
            startGame = true;
            Destroy(textThings[1]);
            textBoxes.SetActive(false);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Entered Collision method");
        Material blockMat = collision.gameObject.GetComponent<Renderer>().sharedMaterial;
        if (blockMat != null && blockMat == this.GetComponent<Renderer>().sharedMaterial)
        {
            Debug.Log("Now destroying object...");
            Destroy(collision.gameObject);
            count.SetCounter(count.GetCounter() - 1);
        }
        //Debug.Log("Counter Outside: " + counter);
    }

    public bool GetStartGame()
    {
        return startGame;
    }
}
