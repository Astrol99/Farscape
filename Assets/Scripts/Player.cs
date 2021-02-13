using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator; 

    public float defaultSpeed = 100f;
    public float sprintSpeed = 120f;
    private float speed;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        speed = defaultSpeed;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
            jump = true;

        if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;
        
        if (Input.GetButtonDown("Sprint"))
            speed = sprintSpeed;
        else if (Input.GetButtonUp("Sprint"))
            speed = defaultSpeed;
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }
}
