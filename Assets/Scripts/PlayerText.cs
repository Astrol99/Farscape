using UnityEngine;

public class PlayerText : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = "Foreground";
    }
}
