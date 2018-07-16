using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBlockCounter : MonoBehaviour {

    private int counter = 4;

    public int GetCounter()
    {
        return counter;
    }

    public void SetCounter(int num)
    {
        counter = num;
    }
}
