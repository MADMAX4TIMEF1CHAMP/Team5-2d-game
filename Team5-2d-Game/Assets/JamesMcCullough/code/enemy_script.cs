using UnityEngine;

public class enemy_script : MonoBehaviour
{
    private Vector3 player_position;
    private float distance_from_player;
    [SerializeField] bool debug = false;
    Vector3 forward;
    Vector3 rotation_direction;
    LayerMask layer_mask;
    private Player_controller_basic player_controller;
    [SerializeField] private int health = 3;
    [SerializeField] private float agrro_range = 5f;

    enum enemy_state{ chase, attack, idle}
    enemy_state state;
    Animator animator;
    bool state_complete = true;
    bool is_attacking = false;
    bool can_attack = true;
    int acceleration = 2;
    float deceleration = 0.7f;
    Rigidbody2D rb;
    GameObject player;
    float distance;
    

    

    void Start()
    {
        GameObject player = GameObject.Find("player");
        player_controller = player.GetComponent<Player_controller_basic>();
        layer_mask = LayerMask.GetMask("player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation_direction = (player_controller.transform.position - this.transform.position).normalized;
        rotation_direction.z = 0;
        distance_from_player = Vector3.Distance(transform.position, player_controller.transform.position);
        RaycastHit2D hit_info = Physics2D.Raycast(transform.position, new Vector2(rotation_direction.x, rotation_direction.y), agrro_range);

        //on death
       if (health <= 0)
       {
        acceleration = 0;
        this.gameObject.SetActive(false);
       }

       if (!is_attacking)
       {

       }


        // on agrro
        if(hit_info.collider == null)
        {
            Debug.Log("it works?");
        }
        else if(hit_info.collider.gameObject.CompareTag("Player"))
        {

            
            rb.linearVelocity = rotation_direction * acceleration;

        }

        


        Debug.Log(hit_info.collider);

        rb.linearVelocity *= deceleration;
    
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, new Vector2(rotation_direction.x, rotation_direction.y)* agrro_range);
    }
    
}
