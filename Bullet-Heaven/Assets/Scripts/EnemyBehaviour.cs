using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float moveSpeed;
    GameObject player; // Reference to the player object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // Encontrando o jogador a partir da tag "Player"  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        // A posição do inimigo é atualizada para se mover em direção à posição do jogador
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            // Destrói o inimigo ao colidir com o objeto com a tag "Player"
        }
    }
}
