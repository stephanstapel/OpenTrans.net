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

namespace OpenTrans.net
{
    /// <summary>
    /// This element contains remarks related to a business document. The remark is identified with the
    /// attribute "type" for use in different business documents. It is only permissible to identify remarks
    /// for use in this or the following business documents using the attribute "type".
    /// </summary>
    public class Remark
    {
        /// <summary>
        /// The remark itself.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Specifies the type of remark. The remark is identified for use in a variety of business
        /// documents. The business partner processing the document which matches the attribute evaluates
        /// the information contained, otherwise the information is passed on along the process chain.
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Specifies the used language for the remark.
        /// </summary>
        public string Lang { get; set; }
    }
}
