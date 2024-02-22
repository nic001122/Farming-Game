using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    

    float steerAmount;
    float moveAmount;
    public Rigidbody2D rb;
    private Vector2 movement;

    public float moveSpeed;

    bool westLook = false;
    bool eastLook = false;
    bool northLook = false;
    bool southLook = false;

    [SerializeField] SpriteRenderer sr;

    [SerializeField] Sprite sWest;
    [SerializeField] Sprite sEast;
    [SerializeField] Sprite sNorth;
    [SerializeField] Sprite sSouth;

    public KeyCode sprintKey;
    public bool sprint;
    public float baseMoveSpeed;
    public float sprintMoveSpeed;

    // Update is called once per frame
    void Update()
    {
        // Sprint
        if(Input.GetKeyDown(sprintKey) && sprint)
        {
            sprint = false;
        }

        else if(Input.GetKeyDown(sprintKey) && !sprint)
        {
            sprint = true;
        }

        if(sprint)
        {
            moveSpeed = sprintMoveSpeed;
        }

        else if(!sprint)
        {
            moveSpeed = baseMoveSpeed;
        }

        
        // Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //transform.position += direction * moveSpeed * Time.deltaTime;
        //var moveVector = new Vector3(horizontal, vertical, 0);

        if(steerAmount > 0)
        {
            westLook = false;
            northLook = false;
            southLook = false;

            eastLook = true;

            sr.sprite = sEast;
        }

        if(steerAmount < 0)
        {
            eastLook = false;
            northLook = false;
            southLook = false;

            westLook = true;

            sr.sprite = sWest;
        }

        if(moveAmount > 0)
        {
            westLook = false;
            eastLook = false;
            southLook = false;

            northLook = true;

            sr.sprite = sNorth;
        }

        if(moveAmount < 0)
        {
            westLook = false;
            eastLook = false;
            northLook = false;

            southLook = true;

            sr.sprite = sSouth;
        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //this.transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
