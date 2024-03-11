using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int numberOfMonsters = 10;
    public Collider2D spawnAreaCollider;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        if (spawnAreaCollider == null)
        {
            Debug.LogError("Spawn area collider is not assigned!");
            return;
        }

        Bounds spawnBounds = spawnAreaCollider.bounds;

        for (int i = 0; i < numberOfMonsters; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(spawnBounds.min.x, spawnBounds.max.x),
                                                 Random.Range(spawnBounds.min.y, spawnBounds.max.y));
            Instantiate(monsterPrefab, randomPosition, Quaternion.identity);
        }
    }
}
