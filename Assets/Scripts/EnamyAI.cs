using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public float destroyTime = 5f; 
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

      
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        if (player != null)
        {
          
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            Destroy(gameObject); 
        }
    }
}