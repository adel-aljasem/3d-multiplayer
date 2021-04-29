using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tools : MonoBehaviour , ICollectable
{
    [SerializeField]
    private int idTool;
    

    public int IdItem { get { return idTool; } }
}
