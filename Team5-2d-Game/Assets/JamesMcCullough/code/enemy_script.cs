using UnityEngine;

public class enemy_script : MonoBehaviour
{
    Vector2 rotation_direction;
    Vector2 patrol_direction;
    LayerMask layer_mask;
    private Player_controller_basic player_controller;
    [SerializeField] private int health = 3;
    [SerializeField] private float agrro_range = 5f;
    [SerializeField] GameObject patrol_point_a;
    [SerializeField] GameObject patrol_point_b;
    GameObject patrol_target;
    [SerializeField] float fov;

    float viewing_angle;

    enum enemy_state{ chase, attack, idle}
    enemy_state state;
    Animator animator;
    bool state_complete = true;
    bool is_attacking = false;
    bool can_attack = true;
    [SerializeField] int acceleration = 2;
    [SerializeField] float deceleration = 0.7f;
    public Rigidbody2D rb;
    GameObject player;
    float distance_from_patrol;
    public RaycastHit2D hit_info;


    void Start()
    {
        GameObject player = GameObject.Find("player");
        player_controller = player.GetComponent<Player_controller_basic>();
        layer_mask = LayerMask.GetMask("player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        patrol_target = patrol_point_a;
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation_direction = (player_controller.transform.position - this.transform.position).normalized;
        patrol_direction = (patrol_target.transform.position - this.transform.position).normalized;
        distance_from_patrol = Vector3.Distance(transform.position, patrol_target.transform.position);

        viewing_angle = Vector2.Angle(patrol_direction, rotation_direction);
       

        //on death
       if (health <= 0)
       {
        acceleration = 0;
        this.gameObject.SetActive(false);
       }

       if(Input.GetKeyDown(KeyCode.Q) || distance_from_patrol < 0.1)
       {
            if(patrol_target == patrol_point_a)
            {
                patrol_target = patrol_point_b;
            }
            else
            {
                patrol_target = patrol_point_a;
            }
       }

        // 

        if(!is_attacking)
        {
            if(state_complete)
            {
                select_state();
            }
            update_state();
        }
        
        rb.linearVelocity *= deceleration;

        //Debug.Log(viewing_angle);
        //Debug.Log(state);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, new Vector2(rb.linearVelocity.x, rb.linearVelocity.y) * agrro_range);
        Gizmos.DrawRay(this.transform.position, patrol_direction * agrro_range);
    }

    void select_state()
    {
        RaycastHit2D hit_info = Physics2D.Raycast(transform.position, new Vector2(rotation_direction.x, rotation_direction.y), agrro_range);
        state_complete = false;

        if(hit_info.collider == null)
        {
            state = enemy_state.idle;       
        }
        else if(hit_info.collider.gameObject.CompareTag("Player") && viewing_angle < fov)
        {
            state = enemy_state.chase;
        }
        else
        {
            state = enemy_state.idle;
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
            rb.linearVelocity += rotation_direction * acceleration;
            //may have to change if using nav mesh
        }
        else
        {
            state_complete = true;
        }

        

    }

    void idle_patrol_state()
    {
        RaycastHit2D hit_info = Physics2D.Raycast(transform.position, new Vector2(rb.linearVelocity.x, rb.linearVelocity.y), agrro_range);

        if(hit_info.collider == null)
        {
            idle_patrol();      
        }
        else if(hit_info.collider.gameObject.CompareTag("Player") && viewing_angle < fov)
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

        rb.linearVelocity += patrol_direction * (acceleration / 2);
    }

    void attack()
    {
        //temp code
        state_complete = true;
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
}
