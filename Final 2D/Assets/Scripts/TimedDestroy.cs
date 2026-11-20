using UnityEngine;

// Write a timer that destroys the gameobject it's attached to when time is up.
// Use this to remove your explosion VFX when they're done playing.
public class TimedDestroy : MonoBehaviour
{
    [SerializeField] private float _maxTime = 0.2f;
    private float _time;

    // ------------------------------------------------------------------------
    private void OnEnable()
    {
        _time = _maxTime;
    }

    // ------------------------------------------------------------------------
    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
