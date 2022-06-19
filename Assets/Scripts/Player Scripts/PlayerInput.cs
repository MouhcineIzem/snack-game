using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{


    private PlayerController playerController;

    private int horizental = 0, vertical = 0;


    public enum Axis
    {
        Horizontal,
        Vertical
    }




    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizental = 0;
        vertical = 0;

        GetKeyBoardInput();
        SetMovement();


    }

    void GetKeyBoardInput()
    {
        //horizental = (int)Input.GetAxisRaw("Horizontal");
        //vertical = (int)Input.GetAxisRaw("Vertical");

        horizental = GetAxisRaw(Axis.Horizontal);
        vertical = GetAxisRaw(Axis.Vertical);

        if (horizental != 0)
        {
            vertical = 0;
        }


    }

    void SetMovement()
    {
        if(vertical != 0)
        {
            playerController.SetInputDirection((vertical == 1) ? PlayerDirection.UP : PlayerDirection.DOWN);
        } else if (horizental != 0)
        {
            playerController.SetInputDirection((horizental == 1) ? PlayerDirection.RIGHT : PlayerDirection.LEFT);

        }
    }

    int GetAxisRaw(Axis axis)
    {
        if(axis == Axis.Horizontal)
        {
            bool left = Input.GetKeyDown(KeyCode.LeftArrow);
            bool right = Input.GetKeyDown(KeyCode.RightArrow);

            if(left)
            {
                return - 1;
            }

            if(right)
            {
                return 1;
            }
            return 0;
        } else if (axis == Axis.Vertical)
        {
            bool up = Input.GetKeyDown(KeyCode.UpArrow);
            bool down = Input.GetKeyDown(KeyCode.DownArrow);

            if (up)
            {
                return 1;
            }

            if (down)
            {
                return -1;
            }
            return 0;
        }
        return 0;
    }
}
