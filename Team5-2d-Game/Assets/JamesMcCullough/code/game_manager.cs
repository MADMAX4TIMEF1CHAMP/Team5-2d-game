using UnityEngine;
using TMPro;

public class game_manager : MonoBehaviour
{
   #region "Variables"
   public bool state = true;
   public bool blocked = false;
   //true = red false = blue
   public static game_manager instance;
   public float paranoia_level;
   public string current_player_object;
   [SerializeField] private TextMeshProUGUI paranoia_text;
   [SerializeField] private TextMeshProUGUI current_item_text;
   [SerializeField] private TextMeshProUGUI current_health_text;
   private Player_controller_basic player_controller;
   [SerializeField] GameObject player;




   #endregion

   private void Start()
   {
    player_controller = player.GetComponent<Player_controller_basic>();

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
        
        paranoia_text.text = paranoia_level.ToString();
        current_item_text.text = current_player_object;
        current_health_text.text = ("player health = " + player_controller.player_health);

        
    }


    

    
}
