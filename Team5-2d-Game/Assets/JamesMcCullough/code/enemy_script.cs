using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class enemy_script : MonoBehaviour
{
    #region variables
        #region AI
            Vector2 rotation_direction;
            Vector2 patrol_direction;
            LayerMask layer_mask;
            [SerializeField] private float agrro_range = 5f;
            float agrro_distance = 5;
        
            [SerializeField] GameObject patrol_point_a;
            [SerializeField] GameObject patrol_point_b;
            [SerializeField] GameObject patrol_point_c;
            GameObject patrol_target;
            [SerializeField] float fov;
            float viewing_angle;
            enum enemy_state{ chase, attack, idle}
            enemy_state state;
            float distance_from_patrol;
            float distance_from_player;
            public RaycastHit2D hit_info;
            NavMeshAgent agent;
            Transform target;
            bool state_complete = true;
        #endregion
        #region Movement
            [SerializeField] int acceleration = 2;
            #endregion
        #region attack
            [SerializeField] private float attack_distance = 2;
            bool is_attacking = false;
            Vector2 attack_direction;
            [SerializeField] private float attack_time = 1;
            Rigidbody2D rb;
            [SerializeField] float attack_speed = 2;
            [SerializeField] float attack_cooldown = 2;
            bool currently_attack = false;
            int random_number;
            int last_number;
        #endregion
        #region animation
            Animator animator;
        #endregion
        #region misc
            private Player_controller_basic player_controller;
            [SerializeField] private int health = 3;
            [SerializeField] GameObject player;
        #endregion
    #endregion

    void Awake()
    {
        player_controller = player.GetComponent<Player_controller_basic>();
        layer_mask = LayerMask.GetMask("player");
        animator = GetComponent<Animator>();
        patrol_target = patrol_point_a;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation_direction = (player_controller.transform.position - this.transform.position).normalized;
        patrol_direction = (patrol_target.transform.position - this.transform.position).normalized;
        distance_from_patrol = Vector2.Distance(this.transform.position, patrol_target.transform.position);
        distance_from_player = Vector2.Distance(this.transform.position, player.transform.position);

        viewing_angle = Vector2.Angle(patrol_direction, rotation_direction);
       

        //on death
       if (health <= 0)
       {
        acceleration = 0;
        this.gameObject.SetActive(false);
       }

       
       if(target != null)
       {
         agent.SetDestination(target.position);
       }

         

        if(!is_attacking)
        {
            if(state_complete)
            {
                select_state();
            }
            update_state();
            rb.linearVelocity = new Vector2(0,0);
        }
        
        if(currently_attack)
        {
            animator.SetBool("attacking",true);
            rb.linearVelocity = attack_direction.normalized * attack_speed;
        }

    }

    void OnDrawGizmosSelected()
    {
        //player target
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, rotation_direction * agrro_range);
        //attack range
        Gizmos.DrawRay(this.transform.position, rotation_direction * (agrro_range / 4));
        //patrol target
        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, patrol_direction * agrro_range);      
    }

    void select_state()
    {
        RaycastHit2D hit_info = Physics2D.Raycast(transform.position, new Vector2(rotation_direction.x, rotation_direction.y), agrro_range);
        state_complete = false;

        if(hit_info.collider == null)
        {
            state = enemy_state.idle;
            agrro_range = 7f;       
        }
        else if((hit_info.collider.gameObject.CompareTag("Player") && viewing_angle < fov))
        {
            state = enemy_state.chase;
            patrol_point_c.transform.position = player.transform.position;
        }
        else if(distance_from_player < agrro_distance && distance_from_player > attack_distance)
        {
            state = enemy_state.chase;
            patrol_point_c.transform.position = player.transform.position;
        }
        else if(distance_from_player < attack_distance)
        {

            state = enemy_state.attack;
        }
        else
        {
            state = enemy_state.idle;
            
            agrro_range = 7f;
        }
        

        // add in attack state to the if statement (if player distance < attack range)
        

    }
    
    void update_state()
    {
        switch (state)
        {
            case enemy_state.chase:
                chase_player();
                break;
            case enemy_state.idle:
                idle_patrol_state();
                break;
            case enemy_state.attack:
                attack();
                break;

        }
    }

    void chase_player()
    {
        RaycastHit2D hit_info = Physics2D.Raycast(transform.position, new Vector2(rotation_direction.x, rotation_direction.y), agrro_range);

        
        if(hit_info.collider == null)
        {
            state_complete = true;       
        }
        else if(hit_info.collider.gameObject.CompareTag("Player"))
        {
            target = player.transform;
            agent.speed = acceleration;
            //may have to change if using nav mesh
        }
        else
        {
            state_complete = true;
        }


        if(distance_from_player < attack_distance)
        {
            state_complete = true;
        }

        

    }

    void idle_patrol_state()
    {
        RaycastHit2D hit_info = Physics2D.Raycast(this.transform.position, new Vector2(rotation_direction.x, rotation_direction.y) , agrro_range);

        if(hit_info.collider == null)
        {
            idle_patrol();      
        }
        else if(hit_info.collider.gameObject.CompareTag("Player") && viewing_angle < fov)
        {
            state_complete = true;
        }
        else if(distance_from_player < agrro_distance)
        {
            state_complete = true;
        }
        else
        {
            idle_patrol();
        }
        


    }

    void idle_patrol()
    {
        if(Input.GetKeyDown(KeyCode.Q) || distance_from_patrol < 0.1)
       {
            new_random_number();

            agrro_distance = 4f;
            if(patrol_target != patrol_point_c && random_number == 1)
            {
                patrol_target = patrol_point_c;
            }
            else if(patrol_target == patrol_point_c)
            {
                patrol_target = patrol_point_a;
            }
            else if(patrol_target == patrol_point_a)
            {
                patrol_target = patrol_point_b;
            }
            else if(patrol_target == patrol_point_b)
            {
                patrol_target = patrol_point_a;
            }
       }

        target = patrol_target.transform;
        agent.speed = acceleration / 2;
        
    }

    void attack()
    {
        target = null;
        is_attacking = true;
        
        if(currently_attack == false)
        {
        StartCoroutine(stop_attack());  
        } 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == patrol_point_a)
        {
            patrol_target = patrol_point_b;
        }
        else if(other.gameObject == patrol_point_b)
        {
            patrol_target = patrol_point_a;
        }


    }
    private IEnumerator stop_attack()
    {
        yield return new WaitForSeconds(0.1f);

        if(attack_direction == new Vector2(0 ,0))
        {
            attack_direction = rotation_direction;
        }
        currently_attack = true;

        yield return new WaitForSeconds(attack_time);
        currently_attack = false;
        animator.SetBool("attacking",false);
        rb.linearVelocity = new Vector2(0,0);

        yield return new WaitForSeconds(attack_cooldown);
        state_complete = true;
        attack_direction = new Vector2(0,0);
        is_attacking = false;
        
    }
    void new_random_number()
    {
      random_number = Random.Range(1,5);

      if(random_number == last_number)  
      {
        random_number = Random.Range(1,5);
      }
      last_number = random_number;
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        currently_attack = false;
        rb.linearVelocity = new Vector2(0,0);
    }
    
}
