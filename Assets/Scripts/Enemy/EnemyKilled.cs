using UnityEngine;
using System.Collections;

public class EnemyKilled : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy"))
            collision.GetComponent<EnemyBase>().ApplyDamage(10);
    }
}
