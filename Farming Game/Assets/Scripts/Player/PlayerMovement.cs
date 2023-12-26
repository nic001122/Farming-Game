using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float steerAmount;
    float moveAmount;


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
        float steerAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(steerAmount, moveAmount, 0);

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
}
