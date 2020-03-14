using UnityEngine;

public class Shoot : MonoBehaviour {

    public float strong = 1;

    private void Start() {
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) {
            if (collision.name != "Background") {
                Debug.Log(collision.name);
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<EnemyBase>().ApplyDamage(strong);
            Destroy(gameObject);
        }
    }
}
