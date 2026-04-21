using UnityEngine;
using TMPro;
using System.Diagnostics;


public class KeysToUseWhenMovingIntructionText : MonoBehaviour
{
    public TextMeshProUGUI InstructionOnHowToMoveText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InstructionOnHowToMoveText.text = "use wasd to move";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //This toggles the entire GameObject on/off

            InstructionOnHowToMoveText.gameObject.SetActive(false);
        }
    }

}