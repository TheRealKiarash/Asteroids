using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float ObjectHeight => GetComponent<SpriteRenderer>().bounds.extents.x;
    private float ObjectWidth => GetComponent<SpriteRenderer>().bounds.extents.y;

    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        screenBounds = new Vector2(screenBounds.x + ObjectWidth, screenBounds.y + ObjectHeight);
    }

    void LateUpdate()
    {
            WrapScreen();
    }

    private void WrapScreen()
    {
        Vector3 newPosition = transform.position;

        if (transform.position.x > screenBounds.x)
        {
            newPosition.x = -screenBounds.x;
        }

        if (transform.position.x < -screenBounds.x)
        {
            newPosition.x = screenBounds.x;
        }

        if (transform.position.y > screenBounds.y)
        {
            newPosition.y = -screenBounds.y;
        }

        if (transform.position.y < -screenBounds.y)
        {
            newPosition.y = screenBounds.y;
        }

        transform.position = newPosition;
    }
}