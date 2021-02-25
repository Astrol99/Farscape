using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interactive : MonoBehaviour
{
    public SpriteRenderer sprite;
    public TextMesh playerText;
    public string description = "A very good description"; 
    public float delay = 0.001f;
    public float exitDelay = 2f;

    private IEnumerator writeTextCoroutine;

    private bool collided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collided = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sprite.color = Color.white;
            collided = false;
        }   
    }

    private void Update()
    {
        if (collided)
        {
            sprite.color = Color.Lerp(Color.white, new Color(255, 255, 0, 0.5f), Mathf.PingPong(Time.time, 1));
            
            if (Input.GetButtonDown("Interact") && playerText.text == "")
            {
                writeTextCoroutine = writeText(description, 0.1f, 1f);
                StartCoroutine(writeTextCoroutine);
            }
        }
    }
    private IEnumerator writeText(string text, float delay, float exitDelay)
    {
        foreach (char c in text)
        {
            playerText.text += c;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(exitDelay);

        for (int i = text.Length; i >= 0; i--)
        {
            playerText.text = playerText.text.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

}