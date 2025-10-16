using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    EntityStats playerStats;
    public Slider lifeBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        //Atribue a variável "playerStats" ao componente EntityStats do objeto com a tag "Player"
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHPBar();
    }

    public void PlayerHPBar()
    {
        lifeBar.maxValue = playerStats.maxHp; //Atribue o valor máximo da barra de vida ao valor máximo do hp do jogador
        lifeBar.value = playerStats.hp; //Atribue o valor atualizado da barra de vida ao valor atual do hp do jogador
    }
}
