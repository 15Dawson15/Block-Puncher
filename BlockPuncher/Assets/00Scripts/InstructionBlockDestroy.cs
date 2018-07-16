using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBlockDestroy : MonoBehaviour {

    private int counter = 4;
    private static bool startGame = false;
    public GameObject textBoxes;

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Counter: " + counter);
		if(counter < 1)
        {
            //Debug.Log("Hello");
            startGame = true;
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
            counter -= 1;
            Debug.Log("Counter: " + counter);
        }
        //Debug.Log("Counter Outside: " + counter);
    }

    public bool GetStartGame()
    {
        return startGame;
    }
}
