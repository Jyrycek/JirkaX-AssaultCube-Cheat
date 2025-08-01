﻿using MemoryAccesor;

namespace Structures
{
    public class Matrix
    {
        public float M11 { get; set; }
        public float M12 { get; set; }
        public float M13 { get; set; }
        public float M14 { get; set; }

        public float M21 { get; set; }
        public float M22 { get; set; }
        public float M23 { get; set; }
        public float M24 { get; set; }

        public float M31 { get; set; }
        public float M32 { get; set; }
        public float M33 { get; set; }
        public float M34 { get; set; }

        public float M41 { get; set; }
        public float M42 { get; set; }
        public float M43 { get; set; }
        public float M44 { get; set; }

        private readonly static int viewMatrixOffset = 0x17DF90;

        public Matrix(float m11, float m12, float m13, float m14,
                      float m21, float m22, float m23, float m24,
                      float m31, float m32, float m33, float m34,
                      float m41, float m42, float m43, float m44)
        {
            M11 = m11; M12 = m12; M13 = m13; M14 = m14;
            M21 = m21; M22 = m22; M23 = m23; M24 = m24;
            M31 = m31; M32 = m32; M33 = m33; M34 = m34;
            M41 = m41; M42 = m42; M43 = m43; M44 = m44;
        }

        public static Matrix ReadMatrix()
        {
            var mtx = MemoryManager.ReadMatrix(MemoryManager.processBaseAddress + viewMatrixOffset + 0x4 * 16);

            return new Matrix(
                mtx[0], mtx[1], mtx[2], mtx[3],
                mtx[4], mtx[5], mtx[6], mtx[7],
                mtx[8], mtx[9], mtx[10], mtx[11],
                mtx[12], mtx[13], mtx[14], mtx[15]
        );
        }
    }
}