using UnityEngine;

public class Background : MonoBehaviour
{
    private float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameActive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x < -18.86)
            {
                transform.position = new Vector3(0.66f, transform.position.y, transform.position.z);
            }
        }
    }
}
