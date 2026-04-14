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
    bool state_complete = true;
    bool is_attacking = false;
    int acceleration = 2;
    float deceleration = 0.7f;

    void Start()
    {
        GameObject player = GameObject.Find("player");
        player_controller = player.GetComponent<Player_controller_basic>();
        layer_mask = LayerMask.GetMask("ray_collision");
    }

    // Update is called once per frame
    void Update()
    {
        rotation_direction = (this.transform.position - player_controller.transform.position).normalized;
        rotation_direction.z = 0;
        distance_from_player = Vector3.Distance(transform.position, player_controller.transform.position);
 

        //on death
       if (health <= 0)
       {
        acceleration = 0;
        this.gameObject.SetActive(false);
       }

        if(Physics.Raycast(this.transform.position, rotation_direction ,agrro_range, layer_mask ) == true)
        {
            Debug.Log("there Is something I see");
        }

        Debug.DrawRay(this.transform.position, rotation_direction * agrro_range ,Color.red);

    }
    
}
