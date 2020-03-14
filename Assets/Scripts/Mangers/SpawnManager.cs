using UnityEngine;
using System.Collections;

public enum EnemyType {
    BEE,
    CHICKEN,
    SNAKE,
    SCORPION,
    GHOST
}

public class SpawnManager : MonoBehaviour {

    public EnemyType enemy;

    IEnumerator Start() {
        yield return new WaitForSeconds(0.1f);
        GetEnemySpawn();

        yield return new WaitForSeconds(1);
        StartCoroutine("Start");
    }


    public void GetEnemySpawn() {
        switch(enemy) {
            case EnemyType.BEE:
                SpawnEnemy(PoolingManager.GetBee());
                break;

            case EnemyType.CHICKEN:
                SpawnEnemy(PoolingManager.GetChiken());
                break;

            case EnemyType.SNAKE:
                SpawnEnemy(PoolingManager.GetSnake());
                break;

            case EnemyType.SCORPION:
                SpawnEnemy(PoolingManager.GetScorpion());
                break;

            case EnemyType.GHOST:
                SpawnEnemy(PoolingManager.GetGhost());
                break;
        }
    }


    public void SpawnEnemy(GameObject enemy) {
        enemy.transform.position = transform.position;
        enemy.SetActive(true);
    }


    private void OnEnable() {
        var enemys = FindObjectsOfType<EnemyBase>();

        foreach (var enemy in enemys) {
            var distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance <= 3)
                enemy.startFollowPlayer = true;
        }
    }


    //public void FollowPlayer() {
    //}
}
