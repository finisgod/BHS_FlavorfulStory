using UnityEngine;

namespace FlavorfulStory.Saving
{
    /// <summary> ������������� Unity Vector3.</summary>
    /// <remarks> ����������� Unity Vector3 ������ �������������. ��� ������������ ������� ��� ����������.</remarks>
    [System.Serializable]
    public class SerializableVector3
    {
        /// <summary> ���������� �������.</summary>
        private float x, y, z;

        /// <summary> �����������, ������� �� ������������ Vector3 ������� ������������� ������.</summary>
        /// <param name="vector"> ����������� Unity Vector3</param>
        public SerializableVector3(Vector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        /// <summary> ���������� �������������� Vector3 � ������������ �� Unity.</summary>
        /// <returns> ���������� Unity Vector3.</returns>
        public Vector3 ToVector() => new(x, y, z);
    }
}