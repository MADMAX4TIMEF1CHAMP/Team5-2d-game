using UnityEngine;
using System.Collections;
using System;


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

    Vector2 facing_direction;
    [SerializeField] int knock_back_mult;
    [SerializeField] public int player_health = 5;
    public static event Action on_player_damage;
    [SerializeField] float invincible_time = 0.1f;
    bool can_be_damaged;



    #endregion

   

    void Start()
    {
        can_be_damaged = true;
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
            acceleration = (base_acceleration - (game_manager.instance.paranoia_level / 75)) + 0.1f ;
        }
        else if (game_manager.instance.paranoia_level < -50)
        {
            acceleration = (base_acceleration - ((game_manager.instance.paranoia_level / 75) * -1)) + 0.1f;
        }
        else
        {
            acceleration = base_acceleration;
        }

        if(player_health <= 0)
        {
            Debug.Log("you are ded lol");
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

        //Debug.Log(game_manager.instance.paranoia_level);
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

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "enemy" && can_be_damaged)
        {
            can_be_damaged = false;
            rb.AddForce((other.transform.position - this.transform.position).normalized * (knock_back_mult * -1), ForceMode2D.Impulse);
            player_health -= 1;
            on_player_damage?.Invoke();
            StartCoroutine(damage_frames());
        }


    }

    private IEnumerator damage_frames()
    {
       yield return new WaitForSeconds(invincible_time); 
       can_be_damaged = true;
    }

}
