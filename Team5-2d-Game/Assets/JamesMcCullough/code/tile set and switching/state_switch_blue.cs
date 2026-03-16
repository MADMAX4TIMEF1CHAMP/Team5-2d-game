using UnityEngine;

public class state_switch_blue : MonoBehaviour
{
    [SerializeField] private bool current_state;
    private BoxCollider2D room_collider;

    void Start()
    {
        room_collider = GetComponent<BoxCollider2D>();
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        current_state = game_manager.instance.state;
        room_collider.isTrigger = !current_state;
    }

    
}
