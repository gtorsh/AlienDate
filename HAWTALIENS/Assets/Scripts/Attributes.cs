using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour {

    public string Name;

    void Start()
    {
        Name = gameObject.name;
    }
}
