using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float minYPosition;
    private float lookAhead;

   
    private Vector3 targetPosition;
    private Vector3 smoothVelocity;

    private void Update()
    {
        // Calculate the target position for the camera
        targetPosition = new Vector3(player.position.x + lookAhead, Mathf.Max(player.position.y, minYPosition), transform.position.z);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, cameraSpeed);

        // Update lookAhead to adjust the horizontal position of the camera
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        print("here");
        currentPosX = _newRoom.position.x;
    }
}