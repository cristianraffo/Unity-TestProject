using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int runSpeed;
    public float moveSpeed = 5.0f;    
    public float rotateSpeed = 200.0f;

    public Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float jumpForce = 8f;
    public bool canJump;

    public float initSpeed;
    public float crouchSpeed;

    public bool isAttacking;
    public bool moveAtk;
    public float impulseAtk = 10f;

    public CapsuleCollider colStand;
    public CapsuleCollider colCrouch;
    public GameObject headObj;
    public Head head;
    public bool isCrouched;

    public bool hasWeapon;


    void Start()
    {
        canJump = false;
        anim = GetComponent<Animator>();

        initSpeed = moveSpeed;
        crouchSpeed = moveSpeed * 0.5f;
    }

    void FixedUpdate()
    {
        if (!isAttacking)
        {
            transform.Rotate(0, x * Time.deltaTime * rotateSpeed, 0);
            transform.Translate(0, 0, y * Time.deltaTime * moveSpeed);
        }

        if (moveAtk)
        {
            rb.velocity = transform.forward * impulseAtk;
        }
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) && !isCrouched && canJump && !isAttacking)
        {
            moveSpeed = runSpeed;
            if (y > 0)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);

            if (isCrouched)
            {
                moveSpeed = crouchSpeed;
            }
            else if (canJump)
            {
                moveSpeed = initSpeed;
            }
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0) && canJump && !isAttacking)
        {
            if (hasWeapon)
            {
                anim.SetTrigger("attack2");
                isAttacking = true;
            }
            else
            {
                anim.SetTrigger("attack");
                isAttacking = true;
            }
        }

        anim.SetFloat("spdX", x);
        anim.SetFloat("spdY", y);

        if (canJump)
        {
            if (!isAttacking)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("isJumping", true);
                    rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    anim.SetBool("isCrouched", true);

                    colCrouch.enabled = true;
                    colStand.enabled = false;
                    headObj.SetActive(true);
                    isCrouched = true;                
                }
                else
                {
                    if (head.collisionCounter <= 0)
                    {                
                    anim.SetBool("isCrouched", false);

                    headObj.SetActive(false);
                    colCrouch.enabled = false;
                    colStand.enabled = true;
                    isCrouched = false;
                    }
                }
            }

            anim.SetBool("isGrounded", true);
        }
        else
        {
            Falling();
        }

    }

    void Falling()
    {
        anim.SetBool("isGrounded", false);
        anim.SetBool("isJumping", false);
    }

    void stopAttack()
    {
        isAttacking = false;
    }

    void startMoveAtk()
    {
        moveAtk = true;
    }

    void stopMoveAtk()
    {
        moveAtk = false;
    }
}
