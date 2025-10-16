using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    EntityStats entityStats;
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entityStats = gameObject.GetComponent<EntityStats>(); // Acessa o componente EntityStats anexado ao objeto do jogador
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, verticalInput * moveSpeed * Time.deltaTime));

        if((horizontalInput > 0 || horizontalInput < 0) && (verticalInput > 0 || verticalInput < 0))
        {
            moveSpeed = entityStats.baseSpeed * 0.66f;
        }
        else
        {
            moveSpeed = entityStats.baseSpeed;
        }
    }
}
