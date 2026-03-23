using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusicScript : MonoBehaviour
{
    public static backgroundMusicScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
