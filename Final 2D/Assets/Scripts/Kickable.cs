using UnityEngine;
using UnityEngine.SceneManagement;

// Add an enum to represent an item's rarity.
public enum Rarity
{
    Common,
    Uncommon,
    Rare,
}

public class Kickable : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _explosionVfxPrefab;
    // Add a member variable to represent this item's rarity.
    [SerializeField] private Rarity rarity;
    private bool _wasKicked;
    private GameController _gameController;

    // ------------------------------------------------------------------------
    // You don't need to code in this method :)
    private void Start ()
    {
        _gameController = FindAnyObjectByType<GameController>();
    }

    // ------------------------------------------------------------------------
    public void Kick(Vector3 force)
    {
        // Set the 'was kicked' flag.
        _wasKicked = true;
        // Add the input force to the rigidbody to make the item fly.
        _rigidbody.AddForce(force);
        // Let the GameController know this object was kicked.
        _gameController.Kicked(gameObject, rarity);
    }

    // ------------------------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("kickable collided");
        // If this object was kicked, explode.
        if (_wasKicked)
        {
            Explode();
        }
    }

    // ------------------------------------------------------------------------
    private void Explode()
    {
        // Create the explosion VFX.
        var explosion = Instantiate(_explosionVfxPrefab);
        explosion.transform.position = transform.position;

        // Destroy this item.
        Destroy(this);
    }
}
