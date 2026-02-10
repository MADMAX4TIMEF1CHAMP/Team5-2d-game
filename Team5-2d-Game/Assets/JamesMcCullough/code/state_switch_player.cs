using UnityEngine;

public class state_switch_player : MonoBehaviour
{
   #region "Variables"
   public bool state = true;
   //true = red false = blue
   public static state_switch_player instance;


   #endregion

   private void Start()
   {
        if(instance == null)
        {
            instance = this;
        }
   }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = !state;
        }
        
    }
    

    
}
