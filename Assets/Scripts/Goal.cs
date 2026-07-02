using UnityEngine;
using UnityEngine.Audio;

public class Goal : MonoBehaviour
{
    AudioSource audioSource;
    bool success = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(!success)
            {
                success = true;
                audioSource.Play();
            }
        }
    }

    private void Update()
    {
        if (success && !audioSource.isPlaying)
        {
            GameManager.Instance.LoadNextLevel();
        }
    }
}
