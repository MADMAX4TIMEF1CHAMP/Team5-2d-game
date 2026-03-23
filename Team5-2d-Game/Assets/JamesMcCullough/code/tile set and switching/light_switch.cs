using UnityEngine;
using UnityEngine.Rendering.Universal;

public class light_switch : MonoBehaviour
{
        #region variables
    private bool current_state;
    [SerializeField] private Light2D current_light;
    [SerializeField] private float red_light_intensity;
    [SerializeField] private float blue_light_intensity;
    
    #endregion
    void Start()
    {
    
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        current_state = game_manager.instance.state;
        if(current_state == true)
        {
           current_light.intensity = red_light_intensity;
        }
        else 
        {
            current_light.intensity = blue_light_intensity;
        }
        
    }
}
