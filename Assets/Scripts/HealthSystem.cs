using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int lifes;
    [SerializeField] private List<Image> hearts;
    
    public void DecreaseHealth()
    {
        lifes--;
        hearts[hearts.Count - 1].enabled = false;
        if (lifes == 0)
        {
            // TODO: Game over.
        }
    }
}
