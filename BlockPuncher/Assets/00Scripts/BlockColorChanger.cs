using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.WSA.Input;

public class BlockColorChanger : MonoBehaviour {

    public GameObject[] Prefabs;
    public Material[] Materials;

    private void SetMaterial(int prefabIndex, int materialIndex)
    {
        Prefabs[prefabIndex].GetComponent<Renderer>().material = Materials[materialIndex];
    }


    private void Update()
    {
        var interactionSourceStates = InteractionManager.GetCurrentReading();

        foreach(var interactionSourceState in interactionSourceStates)
        {
            if (interactionSourceState.touchpadTouched && interactionSourceState.source.handedness == InteractionSourceHandedness.Right)
            {
                if (interactionSourceState.touchpadPressed)
                {
                    if(interactionSourceState.touchpadPosition.y > 0)
                    {
                        SetMaterial(0, 0);
                        //Debug.Log("Changing right controller to green...");
                    }
                    else
                    {
                        SetMaterial(0, 1);
                        //Debug.Log("Changing right controller to blue...");
                    }
                }
            }
            if (interactionSourceState.touchpadTouched && interactionSourceState.source.handedness == InteractionSourceHandedness.Left)
            {
                if (interactionSourceState.touchpadPressed)
                {
                    if (interactionSourceState.touchpadPosition.y > 0)
                    {
                        SetMaterial(1, 2);
                        //Debug.Log("Changing left controller to red...");
                    }
                    else
                    {
                        SetMaterial(1, 3);
                        //Debug.Log("Changing left controller to orange...");
                    }
                }
            }
        }
    }
}
