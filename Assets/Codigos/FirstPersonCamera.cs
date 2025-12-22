using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    public Transform characterHead;
    public Transform characterBody;

    float rotationX = 0;
    float rotationY = 0;

    float sensitivityY = 0.5f;
    float sensitivityX = 0.5f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;


    }

    void Update()
    {

        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        rotationX += horizontalDelta;
        rotationY -= verticalDelta;

        rotationY = Mathf.Clamp(rotationY, -90, 90);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);

    }
}