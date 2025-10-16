using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float projectileDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, 2f);
        // Destruo o projétil após 2 segundos de seu lançamento independente de colisão ou não (a vírgula entre this.gameObject e 2f é semelhante a um "timer")
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EntityStats>().hp -= projectileDamage;
            Destroy(this.gameObject);
            // Utilizo o comando "collision.gameObject" para acessar o objeto que colidiu com o projétil e ao acessar o EntityStats do inimigo, seu hp é reduzido pelo dano do projétil
            // Após a colisão, o projétil é destruído com o comando "Destroy(this.gameObject)"
        }
    }
}
