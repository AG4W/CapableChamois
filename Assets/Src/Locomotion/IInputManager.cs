using UnityEngine;

public interface IInputManager
{
    Vector3 direction { get; }
    Vector3 rotation { get; }

    float movementSpeed { get; }
    float rotationSpeed { get; }
}