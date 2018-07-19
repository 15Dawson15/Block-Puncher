using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBlockDestroy : MonoBehaviour {

    private static bool startGame = false;
    private InstructionBlockCounter count;
    public GameObject controlCount;

	// Use this for initialization
	void Start () {
        count = controlCount.GetComponent<InstructionBlockCounter>();
        count.SetCounter(4);
    }

    // Update is called once per frame
    void Update () {
		if(count.GetCounter() == 0)
        {
            startGame = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("Entered Collision method Instructions");
        if (collision.gameObject.GetComponent<InstructionBlock>() == null)
        {
            return;   
        }
        Material blockMat = collision.gameObject.GetComponent<Renderer>().sharedMaterial;
        string name = collision.gameObject.GetComponent<InstructionBlock>().GetName();
        if (blockMat != null && name != null && blockMat == this.GetComponent<Renderer>().sharedMaterial && name.Equals("InstructionBlock"))
        {
            //Debug.Log("Now destroying object Instructions...");
            Destroy(collision.gameObject);
            count.SetCounter(count.GetCounter() - 1);
        }
        //Debug.Log("Counter Outside: " + count.GetCounter());
    }

    public bool GetStartGame()
    {
        return startGame;
    }
}
