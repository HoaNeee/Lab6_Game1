using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panelEndGame;
    public GameObject panelWinGame;

    Rigidbody2D rigidbody2D;

    public int cherry ;
    public TextMeshProUGUI cherryText;

    public AudioClip jump;
    public AudioClip collectItem;
    private AudioSource audioSource;

    public GameObject effectPartical;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
        Instantiate(effectPartical, gameObject.transform);
    }

    public void Jump ()
    {
        Debug.Log("Vao ham Jump");
        audioSource.PlayOneShot(jump);
        rigidbody2D.AddForce(Vector2.up * 6, ForceMode2D.Impulse);

        
    }

    public void RestartGame ()
    {
        panelEndGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void WinGame()
    {
        panelWinGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "obstacles")
        {
            panelEndGame.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("item"))
        {
            audioSource.PlayOneShot(collectItem);
            cherry++;
            cherryText.SetText(cherry.ToString());
            Destroy(collision.gameObject);
            
            if(cherry >= 6)
            {
                panelWinGame.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void MoveLeft()
    {
        
        rigidbody2D.AddForce(Vector2.left* 5, ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        rigidbody2D.AddForce(Vector2.right * 5, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
