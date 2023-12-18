using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public int posX = 0;
    public int posY = 5;
    public int posZ = -7;
    public int extraZoom = -5; // Extra zoom offset
    public GameObject player;
    private Vector3 offset;
    public bool zoomEnabled = false;
    public float smoothSpeed = 2f; // Aanpassen naar wens

    void Start()
    {
        offset = new Vector3(posX, posY, posZ);
    }

    void LateUpdate()
    {
        // Check if the player object is null or destroyed
        if (player != null)
        {
            if (zoomEnabled)
            {
                Vector3 targetOffset = new Vector3(posX, posY, posZ + extraZoom);
                offset = Vector3.Lerp(offset, targetOffset, smoothSpeed * Time.deltaTime);
            }

            // Only update the camera's position if the player object is not null
            transform.position = player.transform.position + offset;
        }
    }
}
