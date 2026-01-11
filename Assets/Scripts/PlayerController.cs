using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 10f;
    public GameObject spawnManager;
    public TextMeshProUGUI startText;
    public GameObject effectManager;

    private Collider playerCollider;
    private Rigidbody playerRb;
    private Vector3 targetPos;
    private float speed = 5;
    private bool isWalking;
    private bool isWaitingForStart;
    private bool hasCollided;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startText.enabled = false;
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        Physics.gravity = new Vector3(0, -30f, 0);

        targetPos = new Vector3(-0.0076602f, transform.position.y, transform.position.z);
        StartCoroutine(WalkToPosition());
    }

    IEnumerator WalkToPosition()
    {
        isWalking = true;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        isWalking = false;
        isWaitingForStart = true;

        startText.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            return;
        }

        if (isWaitingForStart && Input.GetKeyDown(KeyCode.Space))
        {
            isWaitingForStart = false;
            spawnManager.SendMessage("StartSpawning");
            startText.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.isGameActive)
        {
            playerRb.linearVelocity = Vector3.up * jumpPower;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasCollided) return;
        if (other.gameObject.CompareTag("Obstacle"))
        {
            hasCollided = true;
            effectManager.transform.position = transform.position;
            effectManager.SendMessage("PlayEffects");   
            GameManager.Instance.GameOver();
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
