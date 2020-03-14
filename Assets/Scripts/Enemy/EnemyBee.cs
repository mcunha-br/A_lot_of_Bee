using UnityEngine;
using System.Collections;

public class EnemyBee : EnemyBase {
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
        Walk();
    }
}
