using UnityEngine;

public class enemy_script : MonoBehaviour
{
    private Vector3 player_position;
    private Player_controller_basic player_controller;

    enum enemy_state{ chase, attack, idle}
    enemy_state state;
    bool state_complete = true;
    bool is_attacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.Find("player");
        player_controller = player.GetComponent<Player_controller_basic>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
