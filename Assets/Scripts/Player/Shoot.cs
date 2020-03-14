using UnityEngine;

public class Shoot : MonoBehaviour {

    public float strong = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")) {
            collision.GetComponent<EnemyBase>().ApplyDamage(strong);
            Destroy(gameObject);
        } else if (collision.gameObject.name.Equals("Foreground"))
        {
            Destroy(gameObject);
        }
    }
}
