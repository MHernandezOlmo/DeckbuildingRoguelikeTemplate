using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 dragOrigin;
    private bool isDragging;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if left mouse button is clicked
        {
            isDragging = true;
            dragOrigin = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) // Check if left mouse button is released
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.ScreenToWorldPoint(dragOrigin);
            transform.position -= new Vector3(0, difference.y, 0); // Adjust camera Y position based on mouse movement
            dragOrigin = Input.mousePosition; // Update drag origin for the next frame
        }
    }
}