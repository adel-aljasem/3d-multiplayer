using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Vector2 input;
    public float playerTurnSpeedWithCamera = 15f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("inputX", input.x);
        animator.SetFloat("inputY", input.y);
    }

    private void FixedUpdate()
    {
        float currentCameraRotation = Camera.main.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, currentCameraRotation, 0), playerTurnSpeedWithCamera * Time.fixedDeltaTime);
    }


    public void Hit()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        ICollectable item = other.GetComponent<ICollectable>();

        if(item != null)
        {

            InventoryManager.Instance.AddItem(InventoryLocation.Player, item, other.gameObject);
        }
    }

}
