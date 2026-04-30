using UnityEngine;

public class interactible_floor_trigger : MonoBehaviour
{
    #region "Variables"
    private BoxCollider2D trigger;
    private SpriteRenderer sprite;
    private ParticleSystem particles;
    private bool current_state;
    private bool collected = false;
    private bool can_interact = false;
    [SerializeField] private bool is_red; 
    [SerializeField] private string stored_item;
    [SerializeField] private GameObject interact_key_bind;

    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        particles = GetComponent<ParticleSystem>();
        interact_key_bind.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        current_state = game_manager.instance.state;
        if(collected == false)
        {
            if(is_red == current_state)
            {
                trigger.enabled = true;
                sprite.enabled = true;
            }
            else
            {
                trigger.enabled = false;
                sprite.enabled = false;
            }
        }
        else
        {
            trigger.enabled = false;
            sprite.enabled = false;
        }

        if(can_interact == true && Input.GetKeyDown(KeyCode.E) == true)
        {
            if(stored_item != null)
            {
                game_manager.instance.current_player_object = stored_item;
                stored_item = null;
                collected = true;
                particles.Play();
            }
            else
            {
                Debug.Log("nuh uh");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("the trigger works, hoorah");
        if(other.CompareTag("Player"))
        {
            interact_key_bind.SetActive(true);
            can_interact = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            interact_key_bind.SetActive(false);
            can_interact = false;
        }
    }
}
