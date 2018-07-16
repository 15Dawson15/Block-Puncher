using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBlockDestroy : MonoBehaviour {

    private int counter = 4;
    private bool startGame = false;
    public GameObject textBoxes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(counter == 0)
        {
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
        }
    }

    public bool GetStartGame()
    {
        return startGame;
    }
}
