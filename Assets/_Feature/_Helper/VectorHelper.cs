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

        public static Vector3 ZeroExcept(float x = 0, float y = 0, float z = 0)
        {
            return new Vector3(x, y, z);
        }

        public static Vector2 GetRandomDir()
        {
            return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        }
    }
}
