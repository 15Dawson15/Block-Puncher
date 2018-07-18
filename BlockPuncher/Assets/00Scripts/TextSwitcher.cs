using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSwitcher : MonoBehaviour {

    public GameObject blockEmitter;
    public GameObject turnAround;
    private BlockEmitter blockEmit;

	// Use this for initialization
	void Start () {
        blockEmit = blockEmitter.GetComponent<BlockEmitter>();
    }

    // Update is called once per frame
    void Update () {
        if (GameObject.Find("InstructionCanvas") != null && blockEmit.GetSwitchText() == true)
        {
            GameObject.Find("InstructionCanvas").SetActive(false);
        }

        if(blockEmit.GetWaveNum() == 4)
        {
            Debug.Log("Inside if statement for turnaround text update");
            TurnAroundText(true);
        }
        if(blockEmit.GetWaveNum() == 5)
        {
            turnAround.transform.position = new Vector3(.02f, 1.16f, -3f);
            turnAround.transform.rotation = new Quaternion(0f, 180f, 0, 0);
            //TurnAroundText(false);
        }
    }

    private void TurnAroundText(bool onOff)
    {
        if (turnAround != null)
        {
            Debug.Log("Inside if statement");
            turnAround.SetActive(onOff);
        }
    }
}
