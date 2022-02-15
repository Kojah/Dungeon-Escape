using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private int value = 1;

    public void Init(int diamondValue)
    {
        value = diamondValue;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.diamonds += value;
                Debug.Log($"Player diamonds: {player.diamonds}");
                Destroy(gameObject);
            }
        }
    }
}
