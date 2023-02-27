using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    // Line 13 can be removed
    [SerializeField] private float maxVelocity;

    // Line 14 can be removed. 
    [SerializeField] private float velocityDampener; // should be <=1
    private Camera mainCamera;
    private int sideValue;
    Rigidbody2D rb;
    Vector3 movementDirection;
    public Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;

    public float jumpCounter;
    public GameObject playerGameObject;

    public bool isAlive;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameOverHandler gameOverHandler;
    private Vector2 deathJump = new Vector2(0f, 7.5f);

    [SerializeField] private float pauseTime;
    [SerializeField] private float destroyPlayerTime;
    [SerializeField] private GameObject gameControls;
    [SerializeField] private ParticleSystem dustEffect;
    [SerializeField] private ParticleSystem splashEffect;
    [SerializeField] private ParticleSystem meteorEffect;

    [SerializeField] AudioPlayer audioPlayerScript;

    [SerializeField] PlayerInvulnerability playerInvulnerabilityScript;
    bool currentlyInvulnerable;

    private float currentHeight;
    public float maxHeight;

    private float dirX;

    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    public string artworkAnimator;

    private int selectedOption = 0;

    // Sets up the components used in the methods throughout this script. This also loads the character sprite and animations that the player chooses in the Main Menu.    
    void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);

        
        //myAnimator.SetBool("isIdle", true);  // Delete this line?

        
    }

    void Update()
    {
        //KeepPlayerOnScreen(); // player wraparound function, not currently in use. 
        FlipSprite();  
        JumpAnimation();
        LavaCollision();
        PlayerHeight();
        MeteorCollision();
        PlatformDust();
        GetInvulnerableStatus();

        if(isAlive)
        {
            PlayerControls();
        }
        
    }

    // Loads the Character sprite and animations that the player chose in the Main Menu. I used Resource.Load because it was the only way it would let me assign the 
    // corresponding animation. I couldn't figure out how to select an Animator through other functions (I got a suggestion to use Play() which was bizarre).
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        artworkAnimator = character.characterAnimator;
        myAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(artworkAnimator);
    }

    // Loads the index value of the character sprite and corresponding animations from the Main Menu. 

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    // Method for mouse controls when testing was done before using the mobile gyroscope controls. 
    void FixedUpdate()
    {
        //rb.velocity = new Vector2 (sideValue * movementSpeed * 0.1f, rb.velocity.y); //THIS IS THE WORKING ONE FOR MOUSE CONTROLS!!!
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    // Also used for mouse controls. This would return a value for either the left or right side of the screen that was clicked on. 
    public void Side(int value) // Used when using the computer controls
    {
        sideValue = value;
    }

    // Touch controls for both IOS and Android. I clamped the player's X position so they wouldn't go off screen. 
    private void PlayerControls() 
    {
        dirX = Input.acceleration.x * movementSpeed;
        transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -2f, 2f), transform.position.y);
    }

    private void FlipSprite() // flips the sprite in the direction it's mving
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon; // if this is removed, then the player sprite will return to facing right. This is used to check make sure the player sprite faces the same direction he was moving when he stops
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    private void JumpAnimation() // used to trigger the jump animation
    {
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Platform")))
        {
            bool playerIsJumping = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("isJumping", playerIsJumping);
        }
        else
        {
            myAnimator.SetBool("isJumping", false);
        }
    }

    private void KeepPlayerOnScreen() // this is the player wraparound function, not currently used
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // both transform.Translate() and rb.position work, pick your poision i guesss
        if(viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
            //transform.Translate(newPosition);
            rb.position = newPosition;
        }
        else if(viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
            //transform.Translate(newPosition);
            rb.position = newPosition;
        }
    }

    private void Die()
    {
        isAlive = false;
        rb.velocity = deathJump;
        myBodyCollider.enabled = false;
        myFeetCollider.enabled = false;
        myAnimator.SetBool("isJumping", false);
        myAnimator.SetBool("isIdle", false);
        myAnimator.SetBool("isDying", true);
        scoreSystem.PauseScore();
        audioPlayerScript.PlayDeathSound();
        //gameControls.gameObject.SetActive(false);
        Invoke("InitiateEndGame", pauseTime);
        Invoke("DestroyPlayer", destroyPlayerTime);
    }

    private void GetInvulnerableStatus() // Getter method for checking the player's invulnerable status
    {
        currentlyInvulnerable = playerInvulnerabilityScript.isInvulnerable;
    }

    private void MeteorCollision()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Meteor")) && !currentlyInvulnerable)
        {
            CreateImpact();
            audioPlayerScript.PlayMeteorSound();
            Die();
        } 
    }
    private void LavaCollision()
    {
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Lava")))
        {
            CreateSplash();
            audioPlayerScript.PlayLavaSound();
            Die();
        } 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Spike" && !currentlyInvulnerable)
        {
            CreateImpact();
            audioPlayerScript.PlaySpikeSound();
            Die();
        }
    }

    private void OnBecameInvisible() 
    {
        isAlive = false;
        myBodyCollider.enabled = false;
        myFeetCollider.enabled = false;
        myAnimator.SetBool("isDying", true);
        scoreSystem.PauseScore();
        gameControls.gameObject.SetActive(false);
        Invoke("DestroyPlayer", destroyPlayerTime);
        Invoke("InitiateEndGame", pauseTime);
    }

    private void InitiateEndGame()
    {
        gameOverHandler.EndGame();
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    private void PlayerHeight()
    {
        currentHeight = transform.position.y;
        if (currentHeight > maxHeight)
        {
            maxHeight = currentHeight;
        }
    }

    public void CreateDust()
    {
        dustEffect.Play();
    }

    public void CreateSplash()
    {
        splashEffect.Play();
    }

    public void CreateImpact()
    {
        meteorEffect.Play();
    }

    private void PlatformDust()
    {
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Platform")) && rb.velocity.y < 0.0f)
        {
            CreateDust();
            audioPlayerScript.PlayJumpSound();
        }
    }
}
