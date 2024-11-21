using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 2.0f;          // Speed of the car
    public bool moveAt90 = false;      // True if the car starts at 90° (top)
    public bool moveAt180 = false;     // True if the car starts at 180° (left)
    public bool moveAtMinus90 = false; // True if the car starts at -90° (bottom)
    public bool moveAtMinus180 = false; // True if the car starts at -180° (right)
    public bool delay7Seconds = false; // True if the car should delay 7 seconds

    private float startTime;           // Tracks when the car started moving

    void Start()
    {
        startTime = Time.time; // Store the initialization time of the car
    }

    void Update()
    {
        // Handle movement based on the selected direction
        if (moveAt90)
        {
            MoveWithOptionalDelay(Vector3.down);
        }
        else if (moveAt180)
        {
            MoveWithOptionalDelay(Vector3.right);
        }
        else if (moveAtMinus90)
        {
            MoveWithOptionalDelay(Vector3.up);
        }
        else if (moveAtMinus180)
        {
            MoveWithOptionalDelay(Vector3.left);
        }
    }

    // Moves the car in the specified direction with an optional 7-second delay
    private void MoveWithOptionalDelay(Vector3 direction)
    {
        float delay = delay7Seconds ? 7f : 0f; // Apply delay if the boolean is true
        if (Time.time >= startTime + delay)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
