using UnityEngine;

public class tileset_switch : MonoBehaviour
{
        #region variables
    private bool current_state;
    [SerializeField] private bool is_red;
    private GameObject current_object;
    private 
    #endregion
    void Start()
    {
        current_object = this.gameObject;
        
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        current_state = game_manager.instance.state;
        if(is_red == current_state)
        {
           current_object.GetComponent<Renderer>().enabled = true;
        }
        else 
        {
            current_object.GetComponent<Renderer>().enabled = false;
        }
        
    }
    
}
