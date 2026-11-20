using System;
using UnityEngine;

public class KickAttack : MonoBehaviour
{
    [SerializeField] public float lifetime = 0.1f;
    [SerializeField] private Vector3 _kickAmount = Vector3.up;
    private float timer = 0f;

    // ------------------------------------------------------------------------
    private void OnEnable()
    {
        // Setup timer
        timer = lifetime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }


    // ------------------------------------------------------------------------
    // Use a built-in Unity collision detection method...
    // Check if the colliding object has a Kickable component-
    //      if so, Kick it!
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Kickable>(out var kickable))
        {
            kickable.Kick(_kickAmount);
        }
    }
}