using System.Collections;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour {

    [Header("Settigns Enemy")]
    public float speed = 1;
    public float strong = 1;
    public float health = 3;
    public bool startFollowPlayer = true;
    public bool inWater { get; set; }
 

    [Header("Settigns Audio")]
    public AudioClip sfxHit;
    public AudioClip sfxAttack;
    public AudioClip sfxDeath;


    protected Rigidbody2D body;
    protected Animator anim;
    protected SpriteRenderer rend;
    protected AudioSource source;
    protected Transform target;


    protected void Start() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        target = GameObject.FindWithTag("Player").transform;

        OnStart();
    }


    protected void Update() {
        if (!startFollowPlayer) return;        

        rend.flipX = (transform.position.x < target.position.x);

        if (inWater)
            OnWater();

        else
            OnUpdate();
    }


    public void ApplyDamage(float damage) {
        health -= damage;

        if (health <= 0) {
            //source.PlayOneShot(sfxDeath);
            gameObject.SetActive(false);
            OnDeath();

        } else
            BlinkEnemy();        
    }

    protected IEnumerator BlinkEnemy() {
        //source.PlayOneShot(sfxHit);
        OnDamage();

        rend.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rend.color = Color.white;
    }

    protected void Fly() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    protected void Walk() {
        var newTarget = new Vector2(target.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newTarget, speed * Time.deltaTime);
    }

    protected abstract void OnStart();
    protected abstract void OnUpdate();
    protected abstract void OnDeath();
    protected abstract void OnDamage();
    protected abstract void OnWater();
}
