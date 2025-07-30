using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObject;
    public Rigidbody rb;

    public float rotationSpeed;

    public GameObject thirdPersonCam;

    public CameraStyle currentStyle;
    public enum CameraStyle
    {
        Basic
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1)) SwitchCameraStyle(CameraStyle.Basic);
        // roatete orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        if (currentStyle == CameraStyle.Basic)
        {
            //rotate player object
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inpurDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inpurDir != Vector3.zero)
            {
                playerObject.forward = Vector3.Slerp(playerObject.forward, inpurDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }
    }

    private void SwitchCameraStyle(CameraStyle newStyle)
    {
        thirdPersonCam.SetActive(false);

        if(newStyle == CameraStyle.Basic) thirdPersonCam.SetActive(true);

        currentStyle = newStyle;
    }
}
