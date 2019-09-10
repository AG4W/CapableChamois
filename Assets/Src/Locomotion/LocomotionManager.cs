using UnityEngine;

public class LocomotionManager : MonoBehaviour
{
    protected IInputManager input { get; private set; }

    void Start()
    {
        this.input = this.GetComponent<IInputManager>();
    }

    protected virtual void FixedUpdate()
    {
        this.transform.position += ((this.transform.forward * this.input.direction.z) + (this.transform.right * this.input.direction.x)) * this.input.movementSpeed * Time.fixedDeltaTime;
        this.transform.eulerAngles += new Vector3(0f, this.input.rotation.y * this.input.rotationSpeed * Time.fixedDeltaTime, 0f);
    }
}
