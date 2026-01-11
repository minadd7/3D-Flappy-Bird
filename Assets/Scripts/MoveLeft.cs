using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.isGameActive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        
            if (transform.position.x < 3.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
