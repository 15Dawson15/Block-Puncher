using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.WSA.Input;

public class BlockColorChanger : MonoBehaviour {

    //private class ControllerState
    //{
    //    public InteractionSourceHandedness Handedness;
    //    public bool TouchpadPressed;
    //    public bool TouchpadTouched;
    //    public Vector2 TouchpadPosition;
    //}

    //private Dictionary<uint, ControllerState> controllers;

    //private PrefabManager changer;

    private void Awake()
    {
        //changer = new PrefabManager();
        //controllers = new Dictionary<uint, ControllerState>();

        //InteractionManager.InteractionSourceDetected += InteractionManager_InteractionSourceDetected;

        //InteractionManager.InteractionSourceLost += InteractionManager_InteractionSourceLost;
        //InteractionManager.InteractionSourceUpdated += InteractionManager_InteractionSourceUpdated;
    }

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
                    if(interactionSourceState.touchpadPosition.y < 0)
                    {
                        SetMaterial(0, 0);
                        //changer.SetMaterial(0, 0);
                        Debug.Log("Changing right controller to green...");
                    }
                    else
                    {
                        SetMaterial(0, 1);
                        //changer.SetMaterial(0, 1);
                        Debug.Log("Changing right controller to blue...");
                    }
                }
                //Debug.Log("This is the right hand: " + interactionSourceState.touchpadPosition);
            }
            if (interactionSourceState.touchpadTouched && interactionSourceState.source.handedness == InteractionSourceHandedness.Left)
            {
                if (interactionSourceState.touchpadPressed)
                {
                    if (interactionSourceState.touchpadPosition.y < 0)
                    {
                        SetMaterial(1, 2);
                        //changer.SetMaterial(1, 2);
                        Debug.Log("Changing left controller to red...");
                    }
                    else
                    {
                        SetMaterial(1, 3);
                        //changer.SetMaterial(1, 3);
                        Debug.Log("Changing left controller to orange...");
                    }
                }
                //Debug.Log("This is the left hand: " + interactionSourceState.touchpadPosition);
            }
        }
    }


    //private void InteractionManager_InteractionSourceDetected(InteractionSourceDetectedEventArgs obj)
    //{
    //    Debug.LogFormat("{0} {1} Detected", obj.state.source.handedness, obj.state.source.kind);

    //    if (obj.state.source.kind == InteractionSourceKind.Controller && !controllers.ContainsKey(obj.state.source.id))
    //    {
    //        controllers.Add(obj.state.source.id, new ControllerState { Handedness = obj.state.source.handedness });

    //    }
    //}

    //private void InteractionManager_InteractionSourceLost(InteractionSourceLostEventArgs obj)
    //{
    //    Debug.LogFormat("{0} {1} Lost", obj.state.source.handedness, obj.state.source.kind);

    //    controllers.Remove(obj.state.source.id);
    //}

    //private void InteractionManager_InteractionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
    //{
    //    ControllerState controllerState;

    //    if (controllers.TryGetValue(obj.state.source.id, out controllerState))
    //    {
    //        controllerState.TouchpadPressed = obj.state.touchpadPressed;
    //        controllerState.TouchpadTouched = obj.state.touchpadTouched;
    //        controllerState.TouchpadPosition = obj.state.touchpadPosition;
    //        Debug.Log("controllerState.TouchPadPressed: " + controllerState.TouchpadPressed);
    //        Debug.Log("controllerState.TouchpadTouched: " + controllerState.TouchpadTouched);
    //        Debug.Log("controllerState.TouchpadPosition: " + controllerState.TouchpadPosition);
    //    }
    //}

    //private string GetControllerInfo()
    //{
    //    string toReturn = string.Empty;
    //    foreach (ControllerState controllerState in controllers.Values)
    //    {
    //        if (controllerState.Handedness.Equals(InteractionSourceHandedness.Left))
    //        {
    //            //Debug.Log("This is the left hand touchPad");
    //            toReturn = controllerState.TouchpadPosition.ToString(); ;
    //        }
    //    }
    //    return toReturn;
    //}
}
