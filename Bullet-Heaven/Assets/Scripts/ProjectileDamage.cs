using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float projectileDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, 2f);
        // Destruo o proj�til ap�s 2 segundos de seu lan�amento independente de colis�o ou n�o (a v�rgula entre this.gameObject e 2f � semelhante a um "timer")
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
            // Utilizo o comando "collision.gameObject" para acessar o objeto que colidiu com o proj�til e ao acessar o EntityStats do inimigo, seu hp � reduzido pelo dano do proj�til
            // Ap�s a colis�o, o proj�til � destru�do com o comando "Destroy(this.gameObject)"
        }
    }
}
