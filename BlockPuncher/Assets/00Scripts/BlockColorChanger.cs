using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.WSA.Input;

public class BlockColorChanger : MonoBehaviour {

    private class ControllerState
    {
        public InteractionSourceHandedness Handedness;
        public bool TouchpadPressed;
        public bool TouchpadTouched;
        public Vector2 TouchpadPosition;
    }

    private Dictionary<uint, ControllerState> controllers;

    private void Awake()
    {
        controllers = new Dictionary<uint, ControllerState>();

        InteractionManager.InteractionSourceDetected += InteractionManager_InteractionSourceDetected;

        InteractionManager.InteractionSourceLost += InteractionManager_InteractionSourceLost;
        InteractionManager.InteractionSourceUpdated += InteractionManager_InteractionSourceUpdated;
    }

   

    

    private void InteractionManager_InteractionSourceDetected(InteractionSourceDetectedEventArgs obj)
    {
        Debug.LogFormat("{0} {1} Detected", obj.state.source.handedness, obj.state.source.kind);

        if (obj.state.source.kind == InteractionSourceKind.Controller && !controllers.ContainsKey(obj.state.source.id))
        {
            controllers.Add(obj.state.source.id, new ControllerState { Handedness = obj.state.source.handedness });
        }
    }

    private void InteractionManager_InteractionSourceLost(InteractionSourceLostEventArgs obj)
    {
        Debug.LogFormat("{0} {1} Lost", obj.state.source.handedness, obj.state.source.kind);

        controllers.Remove(obj.state.source.id);
    }

    private void InteractionManager_InteractionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
    {
        ControllerState controllerState;

        if (controllers.TryGetValue(obj.state.source.id, out controllerState))
        {
            controllerState.TouchpadPressed = obj.state.touchpadPressed;
            controllerState.TouchpadTouched = obj.state.touchpadTouched;
            controllerState.TouchpadPosition = obj.state.touchpadPosition;
            Debug.Log("controllerState.TouchPadPressed: " + controllerState.TouchpadPressed);
            Debug.Log("controllerState.TouchpadTouched: " + controllerState.TouchpadTouched);
            Debug.Log("controllerState.TouchpadPosition: " + controllerState.TouchpadPosition);
        }
    }

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
