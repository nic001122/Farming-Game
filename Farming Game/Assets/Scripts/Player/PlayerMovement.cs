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

    public Vector2 currentPos;
    public Vector2 lastPos;

    // Update is called once per frame
    void Update()
    {
        currentPos = gameObject.transform.position;
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

        if(currentPos.x > lastPos.x)
        {
            westLook = false;
            northLook = false;
            southLook = false;

            eastLook = true;

            sr.sprite = sEast;
        }

        if(currentPos.x < lastPos.x)
        {
            eastLook = false;
            northLook = false;
            southLook = false;

            westLook = true;

            sr.sprite = sWest;
        }

        if(currentPos.y > lastPos.y)
        {
            westLook = false;
            eastLook = false;
            southLook = false;

            northLook = true;

            sr.sprite = sNorth;
        }

        if(currentPos.y < lastPos.y)
        {
            westLook = false;
            eastLook = false;
            northLook = false;

            southLook = true;

            sr.sprite = sSouth;
        }

        lastPos = currentPos;
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //this.transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
