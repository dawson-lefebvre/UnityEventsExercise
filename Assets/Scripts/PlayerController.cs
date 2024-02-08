using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction walkAction;

    private void OnEnable()
    {
        walkAction.Enable();
    }

    private void OnDisable()
    {
        walkAction.Disable();
    }

    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    Vector2 moveValue;
    // Update is called once per frame
    void Update()
    {
        moveValue = walkAction.ReadValue<Vector2>();
        animator.SetInteger("xSpeed", (int)moveValue.x);
        animator.SetInteger("ySpeed", (int)moveValue.y);

        if(moveValue.x > 0)
        {
            if(!spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;   
            }
        }
        else if(moveValue.x < 0)
        {
            if(spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    public float moveSpeed = 1;
    private void FixedUpdate()
    {
        transform.Translate(moveValue * moveSpeed * Time.fixedDeltaTime);
    }
}
