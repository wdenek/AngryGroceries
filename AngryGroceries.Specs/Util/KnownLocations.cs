using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngryGroceries.Specs.Util;

namespace AngryGroceries.Specs
{
    /// <summary>
    /// enumeration of well-known locations in the app.
    /// </summary>
    public enum KnownLocations
    {
        /// <summary>
        /// The homepage in the application
        /// </summary>
        [KnownLocation("/")]
        Homepage
    }
}
