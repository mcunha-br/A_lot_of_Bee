using UnityEngine;
using System.Collections;

public class EnemyGhost : EnemyBase {

    protected override void OnStart() {

    }

    protected override void OnUpdate() {
        Fly();
    }

    protected override void OnDamage() {

    }

    protected override void OnDeath() {

    }

    protected override void OnWater() {
        Fly();
    }
}
