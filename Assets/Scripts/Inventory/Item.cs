using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
    [SerializeField]
    private int IdCode;
    public int IdItem { get { return IdCode; } }


    // public int ItemCode { get { return IdItem; } set { IdItem = value; } }

}

