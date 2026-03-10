using UnityEngine;

public class door_switch : MonoBehaviour
{
   #region variables
    private bool current_state;
    [SerializeField] private bool can_switch = true;
    [SerializeField] private bool is_red;
    
    [SerializeField] private Sprite shown_sprite;
    [SerializeField] private Sprite alt_sprite;
    [SerializeField] door_interact_trigger door_trigger;




    private BoxCollider2D room_collider;
    private SpriteRenderer sprite_renderer;
    #endregion
    void Start()
    {
        room_collider = GetComponent<BoxCollider2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        current_state = game_manager.instance.state;
        if(door_trigger.is_open == true)
        {
           room_collider.enabled = false;
           sprite_renderer.sprite = null;
        }
        else
        {
        
            if(can_switch == true)
            {
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
            else if(can_switch == false)
            {
                room_collider.isTrigger = false;
                sprite_renderer.sprite = shown_sprite; 
            }
        }
        
    }

}
