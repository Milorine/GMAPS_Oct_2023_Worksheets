// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class HMatrix2D 
// {
//     public float[,] entries { get; set; } = new float[3, 3];

//     public HMatrix2D(){
//     for (i = 0; i < 3; i++)
//         {
//             for (j = 0; j < 3; j++)
//             {
//                 entries[i, j] = i * 3 + j + 1;
//             }
//         }
//     }
//     public HMatrix2D(float[,] multiArray){
//     for (int i = 0; i < 3; i++) 
//         { 
//             for (int j = 0; j < 3; j++) 
//             { 
//                 entries[i, j] = multiArray[i, j];
//             } 
//         }  
//     }

//     public HMatrix2D(float m00, float m01, float m02,
//              float m10, float m11, float m12,
//              float m20, float m21, float m22)
//     {
// 	// First row
//         entries[0, 0] = m00;
//         entries[0, 1] = m01;
//         entries[0, 2] = m02;

//         // Second row
//         entries[1, 0] = m10;
//         entries[1, 1] = m11;
//         entries[1, 2] = m12;

//         // Third row
//         entries[2, 0] = m20;
//         entries[2, 1] = m21;
//         entries[2, 2] = m22;
//     }

//     public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
//     {
//         HMatrix2D result = new HMatrix2D();

//     for (int i = 0; i < 3; i++)
//     {
//         for (int j = 0; j < 3; j++)
//         {
//             result.entries[i, j] = left.entries[i, j] + right.entries[i, j];;
//         }
//     }

//     return result;
//     }

//     public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
//     {
//         HMatrix2D result = new HMatrix2D();

//     for (int i = 0; i < 3; i++)
//     {
//         for (int j = 0; j < 3; j++)
//         {
//             result.entries[i, j] = left.entries[i, j] - right.entries[i, j];;
//         }
//     }

//     return result;
//     }

//     public static HMatrix2D operator *(HMatrix2D left, float scalar)
//     {
//         HMatrix2D result = new HMatrix2D();

//     for (int i = 0; i < 3; i++)
//     {
//         for (int j = 0; j < 3; j++)
//         {
//             result.entries[i, j] = left.entries[i, j] * scalar;
//         }
//     }

//     return result;
//     }

//     // Note that the second argument is a HVector2D object
//     //
//     public static HVector2D operator *(HMatrix2D left, HVector2D right)
//     {
//         HVector2D result = new HVector2D();

//     for (int i = 0; i < 3; i++)
//     {
//         result[i] = 0; // Initialize the result vector element to 0

//         for (int j = 0; j < 3; j++)
//         {
//             result[i] += left.entries[i, j] * right[j];
//         }
//     }

//     return result;
//     }

//     // Note that the second argument is a HMatrix2D object
//     //
//     public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
//     {
//         return new HMatrix2D
//         (
// 	    /* 
//             00 01 02    00 xx xx
//             xx xx xx    10 xx xx
//             xx xx xx    20 xx xx
//             */
//             left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

// 	    /* 
//             00 01 02    xx 01 xx
//             xx xx xx    xx 11 xx
//             xx xx xx    xx 21 xx
//             */
//             left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

// 	    // and so on for another 7 entries
// 	);
//     }

//     public static bool operator ==(HMatrix2D left, HMatrix2D right)
//     {
//         // your code here
//     }

//     public static bool operator !=(HMatrix2D left, HMatrix2D right)
//     {
//         // your code here
//     }

//     public override bool Equals(object obj)
//     {
//         // your code here
//     }

//     public override int GetHashCode()
//     {
//         // your code here
//     }

//     public HMatrix2D transpose()
//     {
//         return // your code here
//     }

//     public float getDeterminant()
//     {
//         return // your code here
//     }

//     public void setIdentity()
//     {
//         // your code here
//     }

//     public void setTranslationMat(float transX, float transY)
//     {
//         // your code here
//     }

//     public void setRotationMat(float rotDeg)
//     {
//         // your code here
//     }

//     public void setScalingMat(float scaleX, float scaleY)
//     {
//         // your code here
//     }

//     public void Print()
//     {
//         string result = "";
//         for (int r = 0; r < 3; r++)
//         {
//             for (int c = 0; c < 3; c++)
//             {
//                 result += entries[r, c] + "  ";
//             }
//             result += "\n";
//         }
//         Debug.Log(result);
//     }
// }