using UnityEngine;

// Simple magnet image that disappears after the specified time
public class Magnet : MonoBehaviour
{
    [SerializeField] float destroyTime = 3f;

    // Destroy the gameobject in destroytime seconds
    void Start()
    {
        Destroy(gameObject, destroyTime);   
    }
}
