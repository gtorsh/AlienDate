using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enu
{
    public static int CHAR(string Character)
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
            case "LUCATROTH":
                Val = 2;
                break;
            case "COACH":
                Val = 3;
                break;
            case "JELLY ROOM":
                Val = 4;
                break;
            default:
                break;
        }
        return Val;
    } 
}
