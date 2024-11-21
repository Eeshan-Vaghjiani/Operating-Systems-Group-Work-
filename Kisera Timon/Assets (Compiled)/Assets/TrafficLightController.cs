using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public GameObject trafficLight; // The traffic light object this script controls
    public bool starterLight = false; // Boolean to indicate if this is the starter light

    private float timer = 0f; // Timer to manage state transitions
    private Color amberColor = new Color(1.0f, 0.75f, 0.0f); // Amber color (RGB)

    void Start()
    {
        // Set all traffic lights to red initially
        SetLightColor(Color.red);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (starterLight)
        {
            // Starter light sequence: Green -> Amber -> Red
            if (timer < 6f)
            {
                SetLightColor(Color.green); // Green for 6 seconds
            }
            else if (timer < 7f)
            {
                SetLightColor(amberColor); // Amber for 1 second
            }
            else if (timer < 14f)
            {
                SetLightColor(Color.red); // Red for 7 seconds
            }
            else
            {
                timer = 0f; // Reset timer for the next cycle
            }
        }
        else
        {
            // Non-starter light sequence: Red -> Amber -> Green
            if (timer < 6f)
            {
                SetLightColor(Color.red); // Red for 6 seconds
            }
            else if (timer < 7f)
            {
                SetLightColor(amberColor); // Amber for 1 second
            }
            else if (timer < 14f)
            {
                SetLightColor(Color.green); // Green for 7 seconds
            }
            else
            {
                timer = 0f; // Reset timer for the next cycle
            }
        }
    }

    // Helper function to set the color of the traffic light
    private void SetLightColor(Color color)
    {
        trafficLight.GetComponent<SpriteRenderer>().color = color;
    }
}
