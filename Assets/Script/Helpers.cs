using UnityEngine;

public static class Helpers
{
    #region Fields

    private static Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

    #endregion

    #region Methods

    public static Vector3 ToIso (this Vector3 input) => isoMatrix.MultiplyPoint3x4(input);

    #endregion
}
