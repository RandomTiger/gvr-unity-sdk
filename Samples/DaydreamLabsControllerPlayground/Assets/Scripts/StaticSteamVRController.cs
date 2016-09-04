using UnityEngine;
using System.Collections;

public class StaticSteamVRController : MonoBehaviour
{
    private static StaticSteamVRController Instance;
    public static SteamVR_TrackedController TrackedController;
    public static SteamVR_TrackedObject TrackedObject;

    public static bool isEnabled
    {
        get { return TrackedController != null && TrackedObject != null; }
    }

    void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
    }

    void Update()
    {
        SteamVR_ControllerManager manager = GetComponent<SteamVR_ControllerManager>();

        if (manager.right.activeInHierarchy)
        {
            TrackedController = manager.right.GetComponent<SteamVR_TrackedController>();
            TrackedObject = manager.right.GetComponent<SteamVR_TrackedObject>();
        }
        else if (manager.left.activeInHierarchy)
        {
            TrackedController = manager.left.GetComponent<SteamVR_TrackedController>();
            TrackedObject = manager.left.GetComponent<SteamVR_TrackedObject>();
        }
        else
        {
            TrackedController = null;
            TrackedObject = null;
        }
    }
}
