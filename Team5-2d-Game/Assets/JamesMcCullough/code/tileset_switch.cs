using UnityEngine;

public class tileset_switch : MonoBehaviour
{
        #region variables
    private bool current_state;
    [SerializeField] private bool is_red;

    private Tile
    #endregion
    void Start()
    {
        
        tilemap_renderer = GetComponent<SpriteRenderer>();
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        current_state = game_manager.instance.state;
        if(is_red == current_state)
        {
            room_collider.isTrigger = false;
            
        }
        else 
        {
            room_collider.isTrigger = true;
            
        }
        
    }
}
