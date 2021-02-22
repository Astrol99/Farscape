using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour
{
    public Animator animator;
    public float speed = 1f;
    public float delay = 2f;

    private bool move = false;
    private Vector2 direction = Vector2.right;

    private void Start()
    {
        InvokeRepeating("toggleMovement", 0, delay);
        InvokeRepeating("toggleDirection", 0, delay*2);
    }

    void toggleMovement() 
    {
        move = !move;
        animator.SetBool("Moving", move);
    }

    void toggleDirection()
    {
        direction *= -1;
        transform.localScale = new Vector2(direction.x, 1);
    }

    private void Update()
    {
        if (move)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
