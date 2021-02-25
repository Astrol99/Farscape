using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private SpriteRenderer renderer;
    public bool StartPortal = false;
    public float timeToFade = 1.0f;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StartPortal)
        {
            renderer.material.color = Color.Lerp(renderer.material.color, Color.clear, timeToFade * Time.deltaTime);
        }
    }
}
