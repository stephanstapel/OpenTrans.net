/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
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
        Unknown,

        /// <summary>
        /// select a value from a list of possible values
        /// </summary>
        Choice,
        /// <summary>
        /// one value from a range of possible values
        /// </summary>
        Range,
        /// <summary>
        /// multiple values from a list of possible values
        /// </summary>
        Set,
    }


    internal static class ValueTypesExtensions
    {
        public static ValueTypes FromString(this ValueTypes _, string s)
        {
            s = s.ToLower().Trim();
            switch (s)
            {
                case "choice": return ValueTypes.Choice;
                case "range": return ValueTypes.Range;
                case "set": return ValueTypes.Set;
                default: return ValueTypes.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this ValueTypes v)
        {
            switch (v)
            {                
                case ValueTypes.Choice: return "choice";
                case ValueTypes.Range: return "range";
                case ValueTypes.Set: return "set";
                default: return "";
            }
        } // !EnumToString()
    }
}
