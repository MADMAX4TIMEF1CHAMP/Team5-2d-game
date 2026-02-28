using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Sprite Frame_0, Frame_1, Frame_2, Frame_3, Frame_4, Frame_5, Frame_6, Frame_7, Frame_8, Frame_9;
    Image healthBarImage;

    private void Awake()
        {
        HealthBarImage = GetComponent<Image>();
    }

    public void SetHealthBarImage(HealthBarStatus)
    {         switch (HealthBarStatus)
        {
            case HealthBarStatus.Frame_0:
                HealthBarImage.sprite = Frame_0;
                break;
            case HealthBarStatus.Frame_1:
                HealthBarImage.sprite = Frame_1;
                break;
            case HealthBarStatus.Frame_2:
                HealthBarImage.sprite = Frame_2;
                break;
            case HealthBarStatus.Frame_3:
                HealthBarImage.sprite = Frame_3;
                break;
            case HealthBarStatus.Frame_4:
                HealthBarImage.sprite = Frame_4;
                break;
            case HealthBarStatus.Frame_5:
                HealthBarImage.sprite = Frame_5;
                break;
            case HealthBarStatus.Frame_6:
                HealthBarImage.sprite = Frame_6;
                break;
            case HealthBarStatus.Frame_7:
                HealthBarImage.sprite = Frame_7;
                break;
            case HealthBarStatus.Frame_8:
                HealthBarImage.sprite = Frame_8;
                break;
            case HealthBarStatus.Frame_9:
                HealthBarImage.sprite = Frame_9;
                break;
        }
    }
}

public enum HealthBarStatus
{
    Frame_0 = 9, 
    Frame_1 = 8,
    Frame_2 = 7,
    Frame_3 = 6,
    Frame_4 = 5,
    Frame_5 = 4,
    Frame_6,= 3,
    Frame_7,= 2,
    Frame_8 = 1,
    Frame_9 = 0,
}