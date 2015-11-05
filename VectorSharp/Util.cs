using System;
using System.Collections.Generic;
using System.Linq;

public static class Util
{
    public static bool IsAlmostEqualTo(this double left, double right, double variance = 1e-6)
    {
        return Math.Abs(left - right) < variance;
    }
}