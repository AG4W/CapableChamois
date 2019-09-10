using UnityEngine;

public class PlayerLocomotionManager : LocomotionManager
{
    [SerializeField]Transform _jig;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        _jig.transform.localEulerAngles += new Vector3(-base.input.rotation.x * base.input.rotationSpeed * Time.fixedDeltaTime, 0f, 0f);
    }
}
