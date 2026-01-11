using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public AudioClip scoreSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameManager gameManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (gameManager == null)
        {
            gameManager = GameManager.Instance;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            gameManager.UpdateScore(1);
            audioSource.PlayOneShot(scoreSound);
        }
    }
}
