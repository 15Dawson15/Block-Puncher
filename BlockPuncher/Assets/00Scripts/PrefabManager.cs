using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

    public GameObject[] Prefabs;
    public Material[] Materials;

    public void SetMaterial(int prefabIndex, int materialIndex)
    {
        Prefabs[prefabIndex].GetComponent<Renderer>().material = Materials[materialIndex];
    }

	//// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
