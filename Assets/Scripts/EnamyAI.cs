using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public float destroyTime = 5f; // තත්පර 5කින් විනාශ වෙනවා
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // ප්ලේයර්ව පහු කරලා ගියොත් හරි හැපුණොත් හරි ගේම් එක හිර වෙන්නේ නැති වෙන්න 
        // තත්පර 5කින් හතුරාව නිකන්ම Destroy කරනවා.
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        if (player != null)
        {
            // ප්ලේයර් ඉන්න පැත්තට එනවා
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            Destroy(gameObject); // හැපුණු ගමන් හතුරා නැති වෙනවා
        }
    }
}