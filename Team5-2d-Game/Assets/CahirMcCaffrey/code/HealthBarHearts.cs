using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HealthBarHearts : MonoBehaviour
{
    public Sprite Frame_0, Frame_1, Frame_2;
    Image HealthBarImage;
    private PlayersHealthBarStatus playersHealthBarStatus;

    private void Awake()
        {
        HealthBarImage = GetComponent<Image>();
    }

    public void SetHealthBarImage(PlayersHealthBarStatus status)
    {
        switch (playersHealthBarStatus)
        {
            case PlayersHealthBarStatus.Frame_2:
                HealthBarImage.sprite = Frame_2;
                break;
            case PlayersHealthBarStatus.Frame_1:
                HealthBarImage.sprite = Frame_1;
                break;
            case PlayersHealthBarStatus.Frame_0:
                HealthBarImage.sprite = Frame_0;
                break;
            default:
                break;
        }
    }
}

public enum PlayersHealthBarStatus
{
    Frame_2 = 2,
    Frame_1 = 1,
    Frame_0 = 0,
}