using UnityEngine;

public class state_switch_red : MonoBehaviour
{
    #region variables
    private bool current_state;
    [SerializeField] private bool is_red;
    [SerializeField] private Sprite shown_sprite;
    [SerializeField] private Sprite alt_sprite;
    private bool player_inside = false;



    private BoxCollider2D room_collider;
    private SpriteRenderer sprite_renderer;
    private ParticleSystem particle_system;
    #endregion
    void Start()
    {
        room_collider = GetComponent<BoxCollider2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        particle_system = GetComponent<ParticleSystem>();
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        current_state = game_manager.instance.state;
        if(is_red == current_state)
        {
            room_collider.isTrigger = false;
            sprite_renderer.sprite = shown_sprite;
        }
        else 
        {
            room_collider.isTrigger = true;
            sprite_renderer.sprite = alt_sprite;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            game_manager.instance.blocked = true;
            player_inside = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            game_manager.instance.blocked = false;
            player_inside = false;
        }
    }

    void Update()
    {
        if (player_inside == true && Input.GetKeyDown(KeyCode.Space))
        {
            particle_system.Play();
        }
    }
    
}
