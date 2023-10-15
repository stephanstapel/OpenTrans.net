﻿/*
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
    public enum PhoneNoTypes
    {
        Mobile,
        Office,
        Private,
        Unknown
    }


    internal static class PhoneNoExtensions
    {
        public static PhoneNoTypes FromString(this PhoneNoTypes _, string s)
        {
            s = s.ToLower().Trim();
            switch (s)
            {
                case "mobile": return PhoneNoTypes.Mobile;
                case "office": return PhoneNoTypes.Office;
                case "private": return PhoneNoTypes.Private;
                default: return PhoneNoTypes.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this PhoneNoTypes p)
        {
            switch (p)
            {
                case PhoneNoTypes.Mobile: return "mobile";
                case PhoneNoTypes.Office: return "office";
                case PhoneNoTypes.Private: return "private";                
                default: return "";
            }
        } // !EnumToString()
    }
}
