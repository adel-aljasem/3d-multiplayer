using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    Animator Animator;
    void Start()
    {
        Animator = FindObjectOfType<PlayerController>().GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Animator.SetTrigger("farming");
        }
    }


}
