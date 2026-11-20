using System;
using UnityEngine;

public class KickAttack : MonoBehaviour
{
    // [SerializeField] public float _lifetime = 0.1f;
    [SerializeField] private Vector3 _kickAmount = Vector3.up;

    // ------------------------------------------------------------------------
    private void OnEnable()
    {
        // Setup timer
    }
    

    // ------------------------------------------------------------------------
    // Use a built-in Unity collision detection method...
    // Check if the colliding object has a Kickable component-
    //      if so, Kick it!
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Kickable>(out var kickable))
        {
            kickable.Kick(_kickAmount);
        }
    }
}