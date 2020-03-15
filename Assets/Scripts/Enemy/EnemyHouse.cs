using UnityEngine;
using System.Collections;

public class EnemyHouse : EnemyBase {
    
    private bool spawning;

    protected override void OnDamage() {
        if (spawning) return;

        spawning = true;
        GetComponent<SpawnManager>().enabled = true;

    }

    protected override void OnDeath() {
        // Sempre que um ninho é destruído, atualizamos o placar.
        FindObjectOfType<ScoreManager>().IncreaseDestroyedNests();
        Destroy(gameObject);
    }

    protected override void OnStart() {

    }

    protected override void OnUpdate() {

    }

    protected override void OnWater() {

    }
}
