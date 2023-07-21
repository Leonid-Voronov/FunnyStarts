using System;
using Unity.Mathematics;
using UnityEngine;

namespace Unity.Physics.Authoring
{
    [Serializable]
    internal struct EulerAngles : IEquatable<EulerAngles>
    {
        public static EulerAngles Default => new EulerAngles { RotationOrder = math.RotationOrder.ZXY };

        public float3 Value;
        [HideInInspector]
        public math.RotationOrder RotationOrder;

        internal void SetValue(quaternion value) => Value = math.degrees(Kostyl.ToEuler(value));

        public static implicit operator quaternion(EulerAngles euler) =>
            math.normalize(quaternion.Euler(math.radians(euler.Value), euler.RotationOrder));

        public bool Equals(EulerAngles other) => Value.Equals(other.Value) && RotationOrder == other.RotationOrder;

        public override bool Equals(object obj) => obj is EulerAngles other && Equals(other);

        public override int GetHashCode() => unchecked((int)math.hash(new float4(Value, (float)RotationOrder)));

        /// <summary>
        /// Converts quaternion representation to euler
        /// </summary>
        
    }

    public static class Kostyl
    {
        public static float3 ToEuler(this quaternion quaternion)
        {
            float4 q = quaternion.value;
            double3 res;

            double sinr_cosp = +2.0 * (q.w * q.x + q.y * q.z);
            double cosr_cosp = +1.0 - 2.0 * (q.x * q.x + q.y * q.y);
            res.x = math.atan2(sinr_cosp, cosr_cosp);

            double sinp = +2.0 * (q.w * q.y - q.z * q.x);
            if (math.abs(sinp) >= 1)
            {
                res.y = math.PI / 2 * math.sign(sinp);
            }
            else
            {
                res.y = math.asin(sinp);
            }

            double siny_cosp = +2.0 * (q.w * q.z + q.x * q.y);
            double cosy_cosp = +1.0 - 2.0 * (q.y * q.y + q.z * q.z);
            res.z = math.atan2(siny_cosp, cosy_cosp);

            return (float3)res;
        }
    }
}
