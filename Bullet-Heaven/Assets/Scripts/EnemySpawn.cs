using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo

    public float spawnInterval;// Tempo entre spawns
    public float spawnRadius;// Raio da �rea de spawn

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
        // Chama a fun��o SpawnEnemy repetidamente, come�ando imediatamente (0f) e repetindo a cada "spawnInterval" segundos
    }

    void SpawnEnemy()
    {
        // Define a vari�vel "spawnPos" como a posi��o de spawn do objeto, a partir da posi��o do objeto que cont�m esse script(transform.position)
        // mais um vetor aleat�rio(Random.insideUnitCircle) dentro de um c�rculo com a vari�vel "spawnRadius" como raio
        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        // Instancia o a prefab do objeto inimigo na posi��o "spawnPos" com rota��o padr�o (Quaternion.identity)
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}

