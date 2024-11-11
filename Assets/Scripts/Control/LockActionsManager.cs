using UnityEngine;

public static class LockActionsManager
{
    private static bool _isLock;

    public static bool IsLock { get { return _isLock; } }
    public static void Lock()
    {
        _isLock = true;
    }
    public static void UnLock()
    {
        _isLock = false;
    }
}