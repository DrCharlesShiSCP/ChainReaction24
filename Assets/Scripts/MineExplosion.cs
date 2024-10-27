using System.Collections;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    public GameObject explosionEffect; 
    public float destructionDelay = 2f; 
    public AudioClip explosionSound; 
    private AudioSource audioSource;
    private bool hasExploded = false; 

    void Start()
    {
        // Initialize AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = explosionSound;
        audioSource.playOnAwake = false; // Prevent sound from playing immediately
    }

    public void TriggerExplosion()
    {
        if (hasExploded) return; // Avoid multiple explosions on the same mine
        hasExploded = true;

        // Play the explosion effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Play explosion sound
        if (explosionSound != null)
        {
            audioSource.Play();
        }

        Invoke("testDestroy", destructionDelay); 
    }

    public void testDestroy()
    {
        MineDetection detection = GetComponent<MineDetection>();
        if (detection != null)
        {
            detection.TriggerDetection();
        }
        Invoke("DestoryMine", 1f);
    }

    public void DestoryMine()
    {
        Destroy(gameObject);
    }
}
