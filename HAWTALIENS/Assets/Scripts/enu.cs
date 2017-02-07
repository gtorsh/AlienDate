using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enu : MonoBehaviour
{
    public int CHAR(string Character)
    {
        var Val = -1;
        switch (Character)
        {
            case "DEBORAH":
                Val = 0;
                break;
            case "ORBOS":
                Val = 1;
                break;
            default:
                break;
        }
        return Val;
    } 
}
