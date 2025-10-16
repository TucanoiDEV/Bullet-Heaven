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
        // Verifica se o botão esquerdo do mouse está pressionado a partir do comando "Input.GetMouseButton(0)" e se o jogador pode atacar a partir da chamada "canAttack == true"
        if (Input.GetMouseButton(0) && canAttack == true)
        {
                                                       //projétil  posição do projetol  rotação do projétil
            GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);
            // Criação da variável objeto "projectileInstance" que instancia o prefab "projectile" na posição do jogador com rotação padrão (Quaternion.identity)

            projectileInstance.GetComponent<ProjectileDamage>().projectileDamage = entityStats.attackDamage;
            // Utilizo a variável "projectileInstance" para acessar o componente "ProjectileDamage" do projétil instanciado e atribuo o valor do dano do projétil
            // ao dano de ataque do jogador no componente "EntityStats"

            Vector2 projectileDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            // O comando "Camera.main.ScreenToWorldPoint(Input.mousePosition)" basicamente pega como base a visão da câmera principal (Camera.main)
            // e converte a posição do mouse na tela para coordenadas do mundo do jogo (ScreenToWorldPoint(Input.mousePosition))
            // Criação da variável vetor 2 "projectileDirection" que calcula a direção do projétil subtraindo a posição do jogador da posição do mouse convertida para coordenadas do mundo
            projectileDirection.Normalize(); // Normaliza o vetor para ter magnitude 1

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(projectileDirection * 10f, ForceMode2D.Impulse);
            // Adiciona uma força ao componente "Rigidbody2D" do projétil a partir do comando "AddForce", referenciando a direção do projétil multiplicada por 10f (força aplicada)
            // e usando o modo de força "Impulse" para um impulso instantâneo

            canAttack = false; // Define "canAttack" como falso para impedir ataques consecutivos imediatos
            cooldown = 0; // Reseta o cooldown para iniciar a contagem do tempo de espera entre ataques
        }
        AttackCooldown(); // Chama a função de cooldown do ataque
    }

    void AttackCooldown()
    {
        // Se o tempo de cooldown for maior que o attackSpeed(1) e a variável "canAttack" for falsa, o jogador pode atacar novamente
        if (cooldown > entityStats.attackSpeed && canAttack == false)
        {
            canAttack = true;
        }
        // Senão, o tempo de cooldown é incrementado pelo tempo decorrido desde o último frame (Time.deltaTime)
        else
        {
            cooldown += Time.deltaTime;
        }
    }
}
