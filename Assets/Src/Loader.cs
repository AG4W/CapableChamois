using UnityEngine;

public class Loader : MonoBehaviour
{
    void Awake()
    {
        GlobalEvents.Initialize();
        ShotManager.Initialize();
    }
}
