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

    #endregion

   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //vertical = Input.GetAxisRaw("Vertical");
        //horizontal = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        //movement = new Vector2(horizontal,vertical).normalized;
        //rb.linearVelocity = new Vector2(movement.x*acceleration,movement.y*acceleration);

        
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


        
    }
}
