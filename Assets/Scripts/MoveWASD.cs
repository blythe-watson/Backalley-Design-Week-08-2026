using UnityEngine;

public class MoveWASD : MonoBehaviour
{
    Vector3 direction;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction.y += speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y += -speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction.x += -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += speed;
        }

        direction = direction.normalized;
        transform.position += direction * speed;
    }
}
