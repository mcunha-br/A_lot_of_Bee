using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    [Header("Settigns Enemy")]
    public float speed;
    public float strong;
    public float health;

    [Header("Settigns Audio")]
    public AudioClip sfxWalk;
    public AudioClip sfxAttack;
    public AudioClip sfxDeath;


    private Rigidbody2D body;
    private Animator anim;
    private AudioSource source;


    private void Start() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void Update() {

    }
}
