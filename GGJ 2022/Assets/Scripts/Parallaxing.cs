using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    public Transform[] backgrounds;
    private float[] parallaxScales;                             // The proportion of the camera's movement to move the backgrounds by
    public float smoothing = 1f;                                // How smooth the parallax is going to be. Needs to be above zero.

    private Transform cam;                                      // Reference to the main cameras transform
    private Vector3 previousCamPos;                             // The position of the camera in the previous frame

    // Called before Start(). Good for assigning objects.
    private void Awake()
    {
        // Set up camera reference
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Storing the previous frame.
        previousCamPos = cam.position;

        // Assigning corresponding parallaxScales
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // For each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Fade between current and target position
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}