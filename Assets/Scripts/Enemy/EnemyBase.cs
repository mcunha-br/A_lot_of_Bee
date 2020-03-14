using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    [Header("Settigns Enemy")]
    public float speed;
    public float strong;
    public float health;
    public bool startFollowPlayer = true;
 

    [Header("Settigns Audio")]
    public AudioClip sfxWalk;
    public AudioClip sfxAttack;
    public AudioClip sfxDeath;


    private Rigidbody2D body;
    private Animator anim;
    private SpriteRenderer rend;
    private AudioSource source;
    private Transform target;


    private void Start() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        target = GameObject.FindWithTag("Player").transform;
    }


    private void Update() {
        if (!startFollowPlayer) return;

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        rend.flipX = (transform.position.x < target.position.x);
    }


    public void ApplyDamage(float damage) {
        health -= damage;

        if (health <= 0) {
            gameObject.SetActive(false);

        } else
            BlinkEnemy();        
    }

    private IEnumerator BlinkEnemy() {
        rend.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rend.color = Color.white;
    }
}
