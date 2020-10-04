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
    /// Specifies the delivery date.
    /// </summary>
    public enum DeliveryDateTypes
    {
        /// <summary>
        /// The date given is to be interpreted by the recipient as a required delivery date.
        /// </summary>
        RequiredDate,

        /// <summary>
        /// The date given is to be interpreted by the recipient as a fixed specified delivery date.
        /// </summary>
        FixedDeliveryDate,

        /// <summary>
        /// Unknown (error) value
        /// </summary>
        Unknown
    }


    internal static class DeliveryDateTypesExtensions
    {
        public static DeliveryDateTypes FromString(this DeliveryDateTypes _, string s)
        {
            s = s.ToLower().Trim();
            switch (s)
            {
                case "optional": return DeliveryDateTypes.RequiredDate;
                case "fixed": return DeliveryDateTypes.FixedDeliveryDate;
                default: return DeliveryDateTypes.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this DeliveryDateTypes c)
        {
            switch (c)
            {
                case DeliveryDateTypes.RequiredDate: return "optional";
                case DeliveryDateTypes.FixedDeliveryDate: return "fixed";
                default: return "";
            }
        } // !ToString()
    }
}
