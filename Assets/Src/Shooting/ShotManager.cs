using UnityEngine;

public static class ShotManager
{
    public static void Initialize()
    {
        GlobalEvents.Subscribe(GlobalEvent.OnShotFired, DrawShot);
    }

    static void DrawShot(object[] args)
    {
        Vector3 origin = (Vector3)args[0];
        Vector3 direction = (Vector3)args[1];

        Debug.DrawRay(origin, direction * 50f, Color.red, 5f);
    }
}
