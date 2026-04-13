using UnityEngine;
using TMPro;
using System.Diagnostics;


public class text1 : MonoBehaviour
{
    public TextMeshProUGUI InstructionToSwitchStatesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InstructionToSwitchStatesText.text = " To switch states press the space bar";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //This toggles the entire GameObject on/off

            InstructionToSwitchStatesText.gameObject.SetActive(false);
        }
    }

}

  