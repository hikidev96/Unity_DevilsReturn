using UnityEngine;

namespace DevilsReturn
{
    public static class VectorHelper
    {
        public static Vector3 Zero()
        {
            return Vector3.zero;
        }

        public static Vector3 FullOf(float value)
        {
            return new Vector3(value, value, value);
        }
    }
}
