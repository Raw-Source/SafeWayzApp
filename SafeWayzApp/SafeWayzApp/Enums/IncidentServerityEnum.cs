using System;
using System.Collections.Generic;
using System.Text;

namespace SafeWayzApp.Enums
{
    // How bad is the situation from 1 to 5 with 5 being bad and 1 being okay but not okay for lack of better words
    public enum IncidentServerityEnum
    {
        best = 1,
        okay = 2,
        nuetral = 3,
        bad = 4,
        worst = 5,
    }
}
