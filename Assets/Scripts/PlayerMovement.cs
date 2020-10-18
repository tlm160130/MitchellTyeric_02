using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public static bool _gameIsPaused = false;
    public GameObject _pauseMenuUI;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public float speed = 6f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public float sprint = 60f;

    Vector3 velocity;
    bool isGrounded;

    [SerializeField]
    AudioSource hitSound;

    public GameObject _loseScreenUI;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        //checks if we've hit the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y< 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //Moves based on x and z movement and where the player is facing
        //don't want to use new Vector3() because those are GLOBAL Coordinates

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * sprint * Time.deltaTime);
        } 

        if (currentHealth <= 0)
        {
            Lose();
        }

        //we use Velocity to handle Gravity
        velocity.y += gravity * Time.deltaTime;

        //physics of a free fall
        controller.Move(velocity * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            other.gameObject.SetActive(false);
            TakeDamage(25);
        }

        if (other.gameObject.CompareTag("Heal"))
        {
            other.gameObject.SetActive(false);
            GiveHealth(20);
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            hitSound.Play();
            TakeDamage(15);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void GiveHealth(int heal)
    {
        currentHealth += heal;

        healthBar.SetHealth(currentHealth);
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void Lose()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _loseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void Kill()
    {
        this.gameObject.SetActive(false);
    }
}
