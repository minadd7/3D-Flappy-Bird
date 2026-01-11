using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public AudioClip hurtSound;
    public ParticleSystem collisionEffect;

    private AudioSource audioScoure;

    void Start()
    {
        audioScoure = GetComponent<AudioSource>();
    }

    public void PlayEffects()
    {
        audioScoure.PlayOneShot(hurtSound);
        collisionEffect.Play();
    }
}
