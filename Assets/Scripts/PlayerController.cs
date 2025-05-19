using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRG;
    Animator animator;
    AudioSource audioSource;

    public float jumpForce = 10f;
    public float gravityModifier = 2f;
    public float extraFallForce = 20f;

    public bool isOnGround = true;

    public ParticleSystem explosionPT;
    public ParticleSystem dirtPT;

    public AudioClip JumpSound;
    public AudioClip explosionPTSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        playerRG = GetComponent<Rigidbody>();

        // Aumenta a gravidade global, se quiser (ou deixe padr�o)
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (!GameController.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                audioSource.PlayOneShot(JumpSound);
                isOnGround = false;
                animator.SetTrigger("Jump_trig");
                dirtPT.Stop();
                playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            // Aumenta for�a de queda apenas quando estiver caindo
            if (playerRG.linearVelocity.y < 0)
            {
                playerRG.AddForce(Vector3.down * extraFallForce, ForceMode.Acceleration);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtPT.Play();
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(explosionPTSound);
            animator.SetBool("Death_b", true);
            explosionPT.Play();
            dirtPT.Stop();
            GameController.gameOver = true;
            Invoke(nameof(GoGameOver), 5f);
        }
    }

    void GoGameOver()
    {
        SceneManager.LoadScene(2);
    }
}
