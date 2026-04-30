using UnityEngine;
using System.Collections;
using TMPro;

public class door_interact_trigger : MonoBehaviour
{
    #region "Variables"
    private BoxCollider2D trigger;
    private bool can_interact = false;
    [SerializeField] private BoxCollider2D parent; 
    [SerializeField] private string needed_item;
    [SerializeField] private GameObject interact_key_bind;
    [SerializeField] private TextMeshProUGUI screen_text;
      [SerializeField] private TextMeshProUGUI current_objective_text;
    public bool is_open = false;

    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
        interact_key_bind.SetActive(false);
        is_open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(is_open == false)
        {
            if(parent.isTrigger == true)
            {
                trigger.enabled = false;
            }
            else
            {
                trigger.enabled = true;
            }
        }
        else
        {
            trigger.enabled = false;
        }

        if(can_interact == true && Input.GetKeyDown(KeyCode.E) == true)
        {
            if(game_manager.instance.current_player_object == needed_item)
            {
                is_open = true;
                game_manager.instance.current_player_object = null;
                current_objective_text.text = null;
                
            }
            else
            {
                current_objective_text.text = ("objective - find a " + needed_item);
                screen_text.text = ("you need a " + needed_item);
                StartCoroutine(remove_text());
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

    private IEnumerator remove_text()
    {
        yield return new WaitForSeconds(1.5f);
         screen_text.text = null;
    }
}
