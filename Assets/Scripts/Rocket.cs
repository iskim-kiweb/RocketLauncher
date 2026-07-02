using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI.Table;

public class Rocket : MonoBehaviour
{
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;
    [SerializeField] AudioClip rocketSound;
    [SerializeField] ParticleSystem thrustParticle;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] float thrustForce = 3000f;
    [SerializeField] GameObject wordBalloon;

    Rigidbody rigid;
    AudioSource audioSource;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        wordBalloon.SetActive(false);   
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void OnDisable()
    {
        thrust.Disable();
        rotation.Disable();
    }

    public void PressedThrustButton()
    {
        rigid.AddRelativeForce(Vector3.up * thrustForce * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rocketSound);
        }

        thrustParticle.Play();
    }

    public void ReleaseThrustButton()
    {
        audioSource.Stop();
    }

    public void PressedLeftRotationButton()
    {
        rigid.freezeRotation = true;
        transform.Rotate(Vector3.forward);
        rigid.freezeRotation = false;
    }

    public void PressedRightRotationButton()
    {
        rigid.freezeRotation = true;
        transform.Rotate(-Vector3.forward);
        rigid.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        if(thrust.IsPressed())
        {
            PressedThrustButton();
        }
        else
        {
            ReleaseThrustButton();
        }

        if (rotation.IsPressed())
        {
            float rot = rotation.ReadValue<float>();
            if (rot > 0)
            {
                PressedRightRotationButton();
                leftThrustParticle.Play();
            }
            else if (rot < 0)
            {
                PressedLeftRotationButton();
                rightThrustParticle.Play();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            wordBalloon.SetActive(true);
            explosionParticle.Play();
        }
    }
}
