using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolingManager : MonoBehaviour {

    public GameObject bee;
    public GameObject chicken;
    public GameObject snake;
    public GameObject scorpion;
    public GameObject ghost;
    public int amount;

    private static List<GameObject> bees = new List<GameObject>();
    private static List<GameObject> chickens = new List<GameObject>();
    private static List<GameObject> snakes = new List<GameObject>();
    private static List<GameObject> scorpions = new List<GameObject>();
    private static List<GameObject> ghosts = new List<GameObject>();



    private void Start() {
        InstantiateEnemy(bees, bee, amount);
        InstantiateEnemy(chickens, chicken, amount);
        InstantiateEnemy(snakes, snake, amount);
        InstantiateEnemy(scorpions, scorpion, amount);
        InstantiateEnemy(ghosts, ghost, amount);
    }


    private void InstantiateEnemy(List<GameObject> list, GameObject enemy, int amount) {
        for (int i = 0; i < amount; i++) {
            var tempEnemy = Instantiate(enemy, transform);
            tempEnemy.SetActive(false);
            tempEnemy.GetComponent<SpriteRenderer>().sortingLayerName = "Collectables";
            list.Add(tempEnemy);
        }
    }


    public static GameObject GetBee() {
        foreach (var bee in bees) {
            if (!bee.activeInHierarchy) 
                return bee;
        }
        return null;
    }


    public static GameObject GetChiken() {
        foreach (var chiken in chickens) {
            if (!chiken.activeInHierarchy)
                return chiken;
        }
        return null;
    }


    public static GameObject GetSnake() {
        foreach (var snake in snakes) {
            if (!snake.activeInHierarchy)
                return snake;
        }
        return null;
    }


    public static GameObject GetScorpion() {
        foreach (var scopion in scorpions) {
            if (!scopion.activeInHierarchy)
                return scopion;
        }
        return null;
    }


    public static GameObject GetGhost() {
        foreach (var ghost in ghosts) {
            if (!ghost.activeInHierarchy)
                return ghost;
        }
        return null;
    }
}
