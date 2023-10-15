using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTrans.net 
{
    /// <summary>
    /// possible values for Feature.ValueType
    /// </summary>
    public enum ValueTypes 
    {
        /// <summary>
        /// select a value from a list of possible values
        /// </summary>
        choice,
        /// <summary>
        /// one value from a range of possible values
        /// </summary>
        range,
        /// <summary>
        /// multiple values from a list of possible values
        /// </summary>
        set,
    }
}
