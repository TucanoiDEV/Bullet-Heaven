using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityStats : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public float baseSpeed;
    public float attackDamage;
    public float attackSpeed;

    private void Start()
    {
        hp = maxHp; //Incializ o valor do hp como valor m�ximo
    }

    private void Update()
    {
        Death(); //Chama a fun��o Death a cada frame
    }

    void Death()
    {
        if(hp <= 0)
        {
            if (CompareTag("Player")) // garante que s� o player ativa a tela de game over
            {
                SceneManager.LoadScene("GameOverScene"); // nome exato da sua cena Game Over
            }

            Destroy(this.gameObject); //Destroi o objeto quando o hp chega a 0
        }
    }
}
