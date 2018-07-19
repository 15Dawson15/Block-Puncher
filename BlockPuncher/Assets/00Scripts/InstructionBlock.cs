using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBlock : MonoBehaviour {

    private string nameInstruction;

    private void Start()
    {
        nameInstruction = "InstructionBlock";
    }

    public string GetName()
    {
        return nameInstruction;
    }
}
