using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHealthBar : MonoBehaviour
{
    public GameObject conspect2HealthBar;
    public HealthBarHearts;
    List<HealthBarHearts> hearts = new List<HealthBarHearts>();

    public void DrawHearts()
    {
        ClearHearts();

        // determine how many hearts to make total
        // based off the max health

        float maxHealthRemainder = PlayersHealthSystem.maxHealth % 2;
        int heartsToMake = (int)((PlayersHealthSystem.maxHealth / 2 + maxHealthRemainder);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }
    }
    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(conspect2HealthBar);
        newHeart.transform.SetParent(transform);

        HealthBarHearts heartComponent = newHeart.GetComponent<HealthBarHearts>();
        heartComponent.SetHealthBarImage(PlayersHealthBarStatus.Frame_2);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthBarHearts>();
    }
}
