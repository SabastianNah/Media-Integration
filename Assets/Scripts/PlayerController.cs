using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public int score;
    private int goal;
    public GameObject pickUp;
    public AudioSource SFX;
    public VideoPlayer cinematic;
    public GameObject BGM;

    public LayerMask groundLayer;
    public Rigidbody rb;
    public SpriteRenderer rbSprite;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    // Start is called before the first frame update
    void Start()
    {
        rb.gameObject.GetComponent<Rigidbody>();
        score = 0;
        goal = 5;
        setScoreText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 castPosition = transform.position;
        if (Physics.Raycast(castPosition, -transform.up, out hit, Mathf.Infinity, groundLayer))
        {
            // hit ground, set player above point hit
            if (hit.collider != null)
            {
                Vector3 movementPosition = transform.position;
                movementPosition.y = hit.point.y + groundDist;
                transform.position = movementPosition;
            }
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 MovementDirection = new Vector3(x, 0, y);
        rb.velocity = MovementDirection * speed;

        // flip depending on direction of momement
        if (x != 0 && x < 0)
        {
            rbSprite.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            rbSprite.flipX = false;
        }
    }
    void setScoreText()
    {
        scoreText.text = "Apples: " + score.ToString();

        if (score >= goal)
        {
            BGM.SetActive(false);
            Time.timeScale = 0f;
            winTextObject.SetActive(true);
            cinematic.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SFX.Play();
            pickUp = other.gameObject;
            pickUp.gameObject.SetActive(false);
            score++;
            setScoreText();
        }    
    }
    public void savePlayer()
    {
        SaveLoadResetController.savePlayerData(this);
    }
    public void loadPlayer()
    {
        Vector3 playerPosition;
        playerPosition.x = 0;
        playerPosition.y = 0;
        playerPosition.z = 0;
        transform.position = playerPosition;

    }
   
    public void ExitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();

    }
}
    
