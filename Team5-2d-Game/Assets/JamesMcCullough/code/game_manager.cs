using UnityEngine;

public class game_manager : MonoBehaviour
{
   #region "Variables"
   public bool state = true;
   //true = red false = blue
   public static game_manager instance;


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
