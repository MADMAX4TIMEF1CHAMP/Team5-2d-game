using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHealthBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public float health, maxHealth;
    List<HealthBarHearts> hearts = new List<HealthBarHearts>();
    [SerializeField] private PlayersHealthSystem healthSystem;

    private void OnEable()
    {
       PlayersHealthSystem.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        PlayersHealthSystem.OnPlayerDamaged -= DrawHearts;
    }

    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHearts();

        // determine how many hearts to make total
        // based off the max health

        float maxHealthRemainder = healthSystem.maxHealth % 2;
        int heartsToMake = (int)((healthSystem.maxHealth / 2) + maxHealthRemainder);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for(int i = 0; i < hearts.Count; i++)
        {
            int PlayersHealthBarStatusRemainder = (int)Mathf.Clamp(healthSystem.health - (i * 2), 0, 2);
                hearts[i].SetHealthBarImage((PlayersHealthBarStatus)PlayersHealthBarStatusRemainder);
        }
    }
    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
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
