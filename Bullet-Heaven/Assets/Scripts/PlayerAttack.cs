using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile;
    EntityStats entityStats;


    float cooldown;
    bool canAttack = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entityStats = gameObject.GetComponent<EntityStats>(); // Acessa o componente EntityStats anexado ao objeto do jogador
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se o bot�o esquerdo do mouse est� pressionado a partir do comando "Input.GetMouseButton(0)" e se o jogador pode atacar a partir da chamada "canAttack == true"
        if (Input.GetMouseButton(0) && canAttack == true)
        {
                                                       //proj�til  posi��o do projetol  rota��o do proj�til
            GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);
            // Cria��o da vari�vel objeto "projectileInstance" que instancia o prefab "projectile" na posi��o do jogador com rota��o padr�o (Quaternion.identity)

            projectileInstance.GetComponent<ProjectileDamage>().projectileDamage = entityStats.attackDamage;
            // Utilizo a vari�vel "projectileInstance" para acessar o componente "ProjectileDamage" do proj�til instanciado e atribuo o valor do dano do proj�til
            // ao dano de ataque do jogador no componente "EntityStats"

            Vector2 projectileDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            // O comando "Camera.main.ScreenToWorldPoint(Input.mousePosition)" basicamente pega como base a vis�o da c�mera principal (Camera.main)
            // e converte a posi��o do mouse na tela para coordenadas do mundo do jogo (ScreenToWorldPoint(Input.mousePosition))
            // Cria��o da vari�vel vetor 2 "projectileDirection" que calcula a dire��o do proj�til subtraindo a posi��o do jogador da posi��o do mouse convertida para coordenadas do mundo
            projectileDirection.Normalize(); // Normaliza o vetor para ter magnitude 1

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(projectileDirection * 10f, ForceMode2D.Impulse);
            // Adiciona uma for�a ao componente "Rigidbody2D" do proj�til a partir do comando "AddForce", referenciando a dire��o do proj�til multiplicada por 10f (for�a aplicada)
            // e usando o modo de for�a "Impulse" para um impulso instant�neo

            canAttack = false; // Define "canAttack" como falso para impedir ataques consecutivos imediatos
            cooldown = 0; // Reseta o cooldown para iniciar a contagem do tempo de espera entre ataques
        }
        AttackCooldown(); // Chama a fun��o de cooldown do ataque
    }

    void AttackCooldown()
    {
        // Se o tempo de cooldown for maior que o attackSpeed(1) e a vari�vel "canAttack" for falsa, o jogador pode atacar novamente
        if (cooldown > entityStats.attackSpeed && canAttack == false)
        {
            canAttack = true;
        }
        // Sen�o, o tempo de cooldown � incrementado pelo tempo decorrido desde o �ltimo frame (Time.deltaTime)
        else
        {
            cooldown += Time.deltaTime;
        }
    }
}
