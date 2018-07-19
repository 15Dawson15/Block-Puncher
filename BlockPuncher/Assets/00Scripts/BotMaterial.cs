using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMaterial : MonoBehaviour {

    public GameObject body;

    public Material GetMaterial()
    {
        return body.GetComponent<Renderer>().sharedMaterial;
    }
}
