using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    static class Vectors
    {
        public static Vector Sum(Vector vector1, Vector vector2)
        {
            if (vector1.Length != vector2.Length) throw new FormatException("Векторы имеют разную длину");
            ArrayVector newVector = new ArrayVector(vector1.Length);
            for (int i = 0; i < vector1.Length; i++)
            {
                newVector[i] = (vector1[i] + vector2[i]);
            }
            return (Vector)newVector;
        }
        public static double Scalar(Vector vector1, Vector vector2)
        {
            float scalar = 0;
            if (vector1.Length != vector2.Length) throw new FormatException("Векторы имеют разную длину");
            for (int i = 0; i < vector1.Length; i++)
            {
                scalar = scalar + vector1[i] * vector2[i];
            }
            return scalar;
        }
        public static Vector NumberMul(Vector vector, int number)
        {
            ArrayVector newVector = new ArrayVector(vector.Length);
            for (int i = 0; i < vector.Length; i++)
                newVector[i] = (vector[i] * number);

            return (Vector)newVector;
        }
        public static double GetNorm(Vector vector)
        {
            return vector.GetNorm();
        }
        public static void OutputVector(Vector vector, Stream output)
        {
            byte[] length = BitConverter.GetBytes(vector.Length);
            output.Write(length, 0, 4);
            byte[] tmp;
            for (int i = 0; i < vector.Length; i++)
            {
                tmp = BitConverter.GetBytes(vector[i]);
                output.Write(tmp, 0, 4);
            }
        }
        public static Vector InputVector(Stream input)
        {
            if (input.Position == input.Length)
                return null;
            byte[] tmp = new byte[4];
            input.Read(tmp, 0, 4);
            int length = BitConverter.ToInt32(tmp, 0);
            Vector vector = new ArrayVector(length);
            float coord;
            for (int i = 0; i < length; i++)
            {
                input.Read(tmp, 0, 4);
                coord = BitConverter.ToSingle(tmp, 0);
                vector[i] = coord;
            }
            return vector;
        }
        private static string ReadNum(TextReader input)
        {
            StringBuilder str = new StringBuilder();
            while (input.Peek() != -1 && input.Peek() != ' ')
            {
                str.Append((char)input.Read());
            }
            if (input.Peek() == ' ') input.Read();
            return str.ToString();
        }
        public static void WriteVector(Vector vector, TextWriter output)
        {
            output.Write(vector.Length);
            output.Write(' ');
            for (int i = 0; i < vector.Length; i++)
            {
                output.Write(vector[i]);
                output.Write(' ');
            }
        }
        public static Vector ReadVector(TextReader input)
        {
            if (input.Peek() == -1) return null;
            int length = int.Parse(ReadNum(input));
            Vector vector = new ArrayVector(length);
            for (int i = 0; i < length; i++)
            {
                string st = ReadNum(input);
                vector[i] = float.Parse(st);
            }
            return vector;
        }
    }
}
