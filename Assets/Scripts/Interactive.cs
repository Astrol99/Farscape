using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    public SpriteRenderer sprite;
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

    private GameObject createText(string text, float delay)
    {
        GameObject textObj = new GameObject("interactText");
        textObj.transform.SetParent(this.transform);

        Text textComponent = textObj.AddComponent<Text>();
        textComponent.text = text;

        return textObj;
    }

    private void Update()
    {
        if (collided)
        {
            sprite.color = Color.Lerp(Color.white, new Color(255, 255, 0, 0.5f), Mathf.PingPong(Time.time, 1));
            
            if (Input.GetButtonDown("Interact"))
            {
                createText("I AM A TURTLE", 10f);
            }
        }
    }
}