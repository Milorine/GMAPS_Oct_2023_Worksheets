// Uncomment this whole file.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HMatrix2D 
{
   public float[,] entries { get; set; } = new float[3, 3];

   public HMatrix2D()
   {
       for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                entries[i, j] = i * 3 + j + 1;
            }
        }
   }

   public HMatrix2D(float[,] multiArray)
   {
       for (int i = 0; i < 3; i++) 
        { 
            for (int j = 0; j < 3; j++) 
            { 
                entries[i, j] = multiArray[i, j];
            } 
        }  
   }

   public HMatrix2D(float m00, float m01, float m02,
            float m10, float m11, float m12,
            float m20, float m21, float m22)
   {
	    // First row
       entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        // Second row
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        // Third row
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
   }

   public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
   {
       HMatrix2D result = new HMatrix2D();

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            result.entries[i, j] = left.entries[i, j] + right.entries[i, j];;
        }
    }

    return result;
   }

   public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
   {
       HMatrix2D result = new HMatrix2D();

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            result.entries[i, j] = left.entries[i, j] - right.entries[i, j];;
        }
    }

    return result;
   }

   public static HMatrix2D operator *(HMatrix2D left, float scalar)
   {
       HMatrix2D result = new HMatrix2D();

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            result.entries[i, j] = left.entries[i, j] * scalar;
        }
    }

    return result;
   }

   // Note that the second argument is a HVector2D object
   //
   public static HVector2D operator *(HMatrix2D left, HVector2D right)
{
    return new HVector2D(
        left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0,2] * right.h,
        left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1,2] * right.h
    );
}
   public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
   {
       return new HMatrix2D
       (
	    /* 
           00 01 02    00 xx xx
           xx xx xx    10 xx xx
           xx xx xx    20 xx xx
           */
           left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
	    /* 
            00 01 02    xx 01 xx
            xx xx xx    xx 11 xx
            xx xx xx    xx 21 xx
            */
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
            left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],
            left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
            left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],
            left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
            left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]
            
	    // and so on for another 7 entries
	) ;
   }

   public static bool operator ==(HMatrix2D left, HMatrix2D right)
   {
       for (int i = 0; i < left.entries.GetLength(0); i++)
    {
        for (int j = 0; j < left.entries.GetLength(1); j++)
        {
            if (left.entries[i, j] != right.entries[i, j])
            {
                return false;
            }
        }
    }
    return true;
   }

   public static bool operator !=(HMatrix2D left, HMatrix2D right)
   {
       for (int i = 0; i < left.entries.GetLength(0); i++)
    {
        for (int j = 0; j < left.entries.GetLength(1); j++)
        {
            if (left.entries[i, j] != right.entries[i, j])
            {
                // Found a mismatched element, consider matrices not equal.
                return true;
            }
        }
    }

    // All elements match, consider matrices equal.
    return false;
   }

   public HMatrix2D transpose()
   {
       HMatrix2D result = new HMatrix2D();

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            result.entries[i, j] = entries[j, i];
        }
    }

    return result;
   }

   public float GetDeterminant()
   {
       float a = entries[0, 0];
        float b = entries[0, 1];
        float c = entries[0, 2];
        float d = entries[1, 0];
        float e = entries[1, 1];
        float f = entries[1, 2];
        float g = entries[2, 0];
        float h = entries[2, 1];
        float i = entries[2, 2];

    // Calculate the determinant using the formula
    return a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);
   }

   public void SetIdentity()
   {
       for (int y = 0; y < 3; y++)
       {
            for (int x = 0; x < 3; x++)
            {  
                entries[y, x] = x == y ? 1.0f : 0.0f;
            }
       }
   }

   public void SetTranslationMatrix(float transX, float transY)
   {
       SetIdentity();
       entries[0, 2] = transX;
       entries[1, 2] = transY;
   }

   public void SetRotationMatrix(float rotDeg)
   {
       SetIdentity();
       float rad = rotDeg * Mathf.Deg2Rad;
       entries[0, 0] = MathF.Cos(rad);
       entries[0, 1] = -MathF.Sin(rad);
       entries[1, 0] = MathF.Sin(rad);
       entries[1, 1] = MathF.Cos(rad);
   }

   public void SetScalingMatrix(float scaleX, float scaleY)
   {
       entries = new float[,]
    {
        { scaleX, 0.0f, 0.0f },
        { 0.0f, scaleY, 0.0f },
        { 0.0f, 0.0f, 1.0f }
    };
   }

   public void Print()
   {
       string result = "";
       for (int r = 0; r < 3; r++)
       {
           for (int c = 0; c < 3; c++)
           {
               result += entries[r, c] + "  ";
           }
           result += "\n";
       }
       Debug.Log(result);
   }
   public override bool Equals(object obj)
    {
        if (obj is HMatrix2D otherMatrix)
        {
            if (ReferenceEquals(this, otherMatrix))
                return true;

            if (entries.GetLength(0) != otherMatrix.entries.GetLength(0) || entries.GetLength(1) != otherMatrix.entries.GetLength(1))
                return false;

            for (int i = 0; i < entries.GetLength(0); i++)
            {
                for (int j = 0; j < entries.GetLength(1); j++)
                {
                    if (entries[i, j] != otherMatrix.entries[i, j])
                        return false;
                }
            }

            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17; // You can choose any prime number as the initial hash value

        unchecked
        {
            // Combine hash codes of all elements in the matrix
            for (int i = 0; i < entries.GetLength(0); i++)
            {
                for (int j = 0; j < entries.GetLength(1); j++)
                {
                    hash = hash * 31 + entries[i, j].GetHashCode();
                }
            }
        }

        return hash;
    }
}
