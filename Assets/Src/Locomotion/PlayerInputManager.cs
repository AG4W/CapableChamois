using UnityEngine;

public class PlayerInputManager : MonoBehaviour, IInputManager
{
    float _x;
    float _y;
    float _z;

    float _rX;
    float _rY;

    public float movementSpeed => 6f;
    public float rotationSpeed => 50f;

    public Vector3 direction { get; private set; }
    public Vector3 rotation { get; private set; }

    void Start()
    {
        this.direction = Vector3.zero;
        this.rotation = Vector3.zero;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        _y = Input.GetKey(KeyCode.Space) ? 1f : 0f;
        _z = Input.GetAxisRaw("Vertical");

        _rY = Input.GetAxisRaw("Mouse X");
        _rX = Input.GetAxisRaw("Mouse Y");

        this.direction = new Vector3(_x, _y, _z);
        this.rotation = new Vector3(_rX, _rY, 0f);

        if (Input.GetKeyDown(KeyCode.T))
            GlobalEvents.Raise(GlobalEvent.ToggleSlowMotion);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            GlobalEvents.Raise(GlobalEvent.OnShotFired, this.transform.position + (Vector3.up * 1.8f), Camera.main.transform.forward);
    }
}
