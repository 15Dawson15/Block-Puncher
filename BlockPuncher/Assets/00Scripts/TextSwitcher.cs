using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSwitcher : MonoBehaviour {

    public GameObject blockEmitter;
    private BlockEmitter blockEmit;

	// Use this for initialization
	void Start () {
        //GameObject.Find("Canvas").SetActive(true);
        blockEmit = blockEmitter.GetComponent<BlockEmitter>();
    }

    // Update is called once per frame
    void Update () {
        if (GameObject.Find("Canvas") != null && blockEmit.GetSwitchText() == true)
        {
            GameObject.Find("Canvas").SetActive(false);
        }

    }

    //public void RemoveText()
    //{
    //    GameObject.Find("Canvas").SetActive(false);
    //}
}
