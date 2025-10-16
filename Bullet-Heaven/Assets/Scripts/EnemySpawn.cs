using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo

    public float spawnInterval;// Tempo entre spawns
    public float spawnRadius;// Raio da área de spawn

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
        // Chama a função SpawnEnemy repetidamente, começando imediatamente (0f) e repetindo a cada "spawnInterval" segundos
    }

    void SpawnEnemy()
    {
        // Define a variável "spawnPos" como a posição de spawn do objeto, a partir da posição do objeto que contém esse script(transform.position)
        // mais um vetor aleatório(Random.insideUnitCircle) dentro de um círculo com a variável "spawnRadius" como raio
        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        // Instancia o a prefab do objeto inimigo na posição "spawnPos" com rotação padrão (Quaternion.identity)
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}

