﻿using UnityEngine;
using System.Collections;

public class EnemySnake : EnemyBase {

    protected override void OnStart() {

    }

    protected override void OnUpdate() {
        Walk();
    }

    protected override void OnDamage() {

    }

    protected override void OnDeath() {

    }

    protected override void OnWater() {
        
    }
}
