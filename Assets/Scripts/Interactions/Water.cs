using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

    public EnemyBase[] enemyBases;

    private void Start() {
        enemyBases = FindObjectsOfType<EnemyBase>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
            PoolingManager.InWater(true);
    }


    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
            PoolingManager.InWater(false);
    }
}
