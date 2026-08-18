using UnityEngine;

public class MoveArrows : MonoBehaviour
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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction.y += speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction.y += -speed;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x += -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x += speed;
        }

        direction = direction.normalized;
        transform.position += direction * speed;
    }
}
