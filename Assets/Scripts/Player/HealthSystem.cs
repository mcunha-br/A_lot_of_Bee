using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int lifes;
    [SerializeField] private List<Image> hearts;

    private bool _isDead = false;
    
    public void DecreaseHealth()
    {
        if (!_isDead)
        {
            lifes--;
            hearts[lifes].enabled = false;
            if (lifes == 0)
            {
                // TODO: Game over.
                _isDead = true;
            }
        }
    }

    public bool IsAlive()
    {
        return !_isDead;
    }
}
