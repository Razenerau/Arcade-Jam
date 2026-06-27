using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    // Reference to the 2D Rigidbody component for physics movement
    private Rigidbody2D _rigidbody2D;
    
    // Default movement direction set to face right
    private Vector2 _direction = Vector2.right;
    
    // Time to wait before the bullet starts shrinking
    public float delayBeforeShrink = 2f;
    
    // Time it takes for the bullet to fully shrink to zero
    public float shrinkDuration = 1f;

    // Movement speed of the bullet
    public float speed = 5f;

    public int MaxBounceCount = 2;
    public int CurrentBounceCount = 0;
    public SpriteRenderer SpriteRenderer;

    public Sprite SpriteOne;
    public Sprite SpriteTwo;

    // Start is called before the first frame update
    private void Start()
    {
        // Cache the Rigidbody2D component attached to this GameObject
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        // Start the timed shrinking and destruction sequence
        StartCoroutine(ShrinkRoutine());
    }

    // Handles the timed shrinking effect before destroying the bullet
    private IEnumerator ShrinkRoutine()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeShrink);

        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = Vector3.zero;
        float elapsedTime = 0f;

        // Gradually shrink the object
        while (elapsedTime < shrinkDuration)
        {
            elapsedTime += Time.deltaTime;
            
            // Interpolate the scale over time
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / shrinkDuration);
            
            // Wait until the next frame
            yield return null;
        }

        // Ensure it reaches exactly zero
        transform.localScale = targetScale;

        // Destroy the object
        Destroy(gameObject);
    }

    // Allows external scripts to set a custom movement direction
    public void SetDirection(Vector2 dir) {
        _direction = dir;
    }

    // Update is called once per frame
    private void Update() {
        // Apply constant velocity to the Rigidbody based on direction and speed
        _rigidbody2D.velocity = _direction * speed;

        //Vector2 v = _rigidbody2D.velocity;
        //
        //if (v.sqrMagnitude > 0.001f) // prevents jitter when nearly stopped
        //{
        //    float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        //    SpriteRenderer.gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);
        //}
    }

     //Triggered when the bullet collides with another 2D collider set to trigger
    private void OnTriggerEnter2D(Collider2D collision) {

        
        
            // Destroy the bullet immediately upon impact
            Destroy(gameObject);
            Destroy(collision.gameObject);
        

        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Block"))
    //    {
    //        if (CurrentBounceCount < MaxBounceCount)
    //        {
    //            // Get the first contact point
    //            ContactPoint2D contact = collision.GetContact(0);
    //
    //            // Normal of the surface at the hit point
    //            Vector2 normal = contact.normal;
    //
    //            // Reflect the velocity over the normal
    //            _rigidbody2D.velocity = Vector2.Reflect(_rigidbody2D.velocity, normal);
    //
    //            CurrentBounceCount++;
    //            return; // Don't destroy the bullet yet
    //        }
    //
    //        // If out of bounces, destroy the block and the bullet
    //        Destroy(collision.gameObject);
    //        Destroy(gameObject);
    //    }
    //}
}