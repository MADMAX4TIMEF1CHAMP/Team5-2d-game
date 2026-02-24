using UnityEngine;

public class game_manager : MonoBehaviour
{
   #region "Variables"
   public bool state = true;
   public bool blocked = false;
   //true = red false = blue
   public static game_manager instance;
   public float paranoia_level;


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
        if (blocked == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
             state = !state;
            }
        }
        
        
    }


    

    
}
