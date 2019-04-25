using System.Collections.Generic;
using UnityEngine;

public static class BezierCurve
{
    public static void GetBezierCurve(Vector3 A, Vector3 B, Vector3 C, Vector3 D, List<Vector3> allRopeSections)
    {
        float resolution = 0.1f;

        allRopeSections.Clear();


        float t = 0;

        while (t <= 1f)
        {
            Vector3 newPos = DeCasteljausAlgorithm(A, B, C, D, t);

            allRopeSections.Add(newPos);
            t += resolution;
        }

        allRopeSections.Add(D);
    }

    static Vector3 DeCasteljausAlgorithm(Vector3 A, Vector3 B, Vector3 C, Vector3 D, float t)
    {
        float oneMinusT = 1f - t;

        Vector3 Q = oneMinusT * A + t * B;
        Vector3 R = oneMinusT * B + t * C;
        Vector3 S = oneMinusT * C + t * D;
        Vector3 P = oneMinusT * Q + t * R;
        Vector3 T = oneMinusT * R + t * S;
        Vector3 U = oneMinusT * P + t * T;

        return U;
    }
}