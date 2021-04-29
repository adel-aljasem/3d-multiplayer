using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instnace;

    public static T Instance
    {
        get { return instnace; }
        
    }

    protected virtual void Awake()
    {
        if(instnace == null)
        {
            instnace = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
