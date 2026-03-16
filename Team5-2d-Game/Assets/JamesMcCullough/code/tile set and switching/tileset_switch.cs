using UnityEngine;
using UnityEngine.Tilemaps;

public class tileset_switch : MonoBehaviour
{
        #region variables
    private bool current_state;
    [SerializeField] private bool is_red;
    private GameObject current_object;
    private TilemapCollider2D tile_collider;
    #endregion
    void Start()
    {
        current_object = this.gameObject;
        tile_collider = GetComponent<TilemapCollider2D>();
        
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        current_state = game_manager.instance.state;
        if(is_red == current_state)
        {
           current_object.GetComponent<Renderer>().enabled = true;
           if(tile_collider != null)
           {
                tile_collider.enabled = true;
           }
        }
        else 
        {
            current_object.GetComponent<Renderer>().enabled = false;
             if(tile_collider != null)
           {
                tile_collider.enabled = false;
           }
        }
        
    }
    
}
