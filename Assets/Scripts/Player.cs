using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 20f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
            jump = true;
        else if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;
        else if (Input.GetButtonDown("Sprint"))
            runSpeed = 40f;
        else if (Input.GetButtonUp("Sprint"))
            runSpeed = 20f;
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }
}
