using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    EntityStats entityStats; // Reference to the EntityStats component of the enemy
    public float moveSpeed;
    GameObject player; // Reference to the player object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entityStats = GetComponent<EntityStats>();
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
            collision.gameObject.GetComponent<EntityStats>().hp -= entityStats.attackDamage;
            //Ao BoxCollider do inimigo colidir com o elemento com a tag "Player", o inimigo recebe acesso ao componente EntityStats do elemento com a tag "Player"
            //e reduz o hp do elemento com a tag "Player" em 5
            Destroy(gameObject);
        }
    }
}
