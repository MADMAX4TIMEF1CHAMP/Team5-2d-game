using UnityEngine;
using System.Collections;

public class Player_controller_basic : MonoBehaviour
{

    #region "Variables"
    [SerializeField] private float acceleration = 10.00f;
    private float base_acceleration = 2f;
    private float sprint_speed;
    [SerializeField] private float decceleration = .7f;
    private Rigidbody2D rb;
    private ParticleSystem particle_system;
    private bool current_state;
    private Animator test_anim;
    private bool blocked;
    [SerializeField] float paranoia_delay = 5f;
    private bool can_increase = true;


    #endregion

   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        test_anim = GetComponent<Animator>();
        particle_system = GetComponent<ParticleSystem>();


    }
    void FixedUpdate()
    {
        

        
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX += (acceleration + sprint_speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX -= (acceleration + sprint_speed);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocityY += (acceleration + sprint_speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocityY -= (acceleration + sprint_speed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint_speed = acceleration * 0.5f;
        }
        else
        {
             sprint_speed = 0;
        }

        if(game_manager.instance.paranoia_level > 50)
        {
            acceleration = (base_acceleration - (game_manager.instance.paranoia_level / 50)) + 0.1f ;
        }
        else if (game_manager.instance.paranoia_level < -50)
        {
            acceleration = (base_acceleration - ((game_manager.instance.paranoia_level / 50) * -1)) + 0.1f;
        }
        else
        {
            acceleration = base_acceleration;
        }

        


        rb.linearVelocityX *= decceleration;
        rb.linearVelocityY *= decceleration;

        current_state = game_manager.instance.state;

        if (current_state == true)
        {
            test_anim.SetBool("state",true);
            
        }
        if (current_state == false)
        {
            test_anim.SetBool("state",false);
            
        }

    }


    void Update()
    {
        if (game_manager.instance.blocked == false && Input.GetKeyDown(KeyCode.Space))
        {
            particle_system.Play();
        }
        if (can_increase)
        {
            StartCoroutine(paranoia_increase());
        }

        Debug.Log(game_manager.instance.paranoia_level);
    }
    

    private IEnumerator paranoia_increase()
    {
        can_increase= false;
        yield return new WaitForSeconds(paranoia_delay);
        if(game_manager.instance.state == true && game_manager.instance.paranoia_level < 100)
        {
            game_manager.instance.paranoia_level += 1;
        }
        else if (game_manager.instance.state == false && game_manager.instance.paranoia_level > -100)
        {
            game_manager.instance.paranoia_level -= 1;
        }
        can_increase = true;

    }
}
