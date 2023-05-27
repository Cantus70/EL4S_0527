using UnityEngine;

public class MoveNumber : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float speedRandomRange = 0.3f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        speed += Random.Range(-speedRandomRange, speedRandomRange);

        rigidbody.velocity = RandomVec2() * speed;

    }

    void Update()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;

        if (rigidbody.velocity.x < 0.01f && rigidbody.velocity.x > -0.01f)
        {
            rigidbody.velocity = new(Random.Range(-1.0f, 1.0f), rigidbody.velocity.y);
        }
        if (rigidbody.velocity.y < 0.01f && rigidbody.velocity.y > -0.01f)
        {
            rigidbody.velocity = new(rigidbody.velocity.x,Random.Range(-1.0f, 1.0f));
        }
    }

    Vector2 RandomVec2()
    {
        return new(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }
}
