using UnityEngine;

public class Player_controller_basic : MonoBehaviour
{

    #region "Variables"
    [SerializeField] private float acceleration = 10.00f;
    [SerializeField] private float decceleration = .9f;
    private Rigidbody2D rb;

    private Vector2 movement;
    private float horizontal;
    private float vertical;
    private bool current_state;
    private Animator test_anim;

    #endregion

   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        test_anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {


        
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX += acceleration;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX -= acceleration;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocityY += acceleration;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocityY -= acceleration;
        }


        rb.linearVelocityX *= decceleration;
        rb.linearVelocityY *= decceleration;

        current_state = state_switch_player.instance.state;

        if (current_state == true)
        {
            test_anim.SetBool("state",true);
        }
        if (current_state == false)
        {
            test_anim.SetBool("state",false);
        }


        
    }
}
