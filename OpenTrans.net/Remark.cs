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
    /// This element contains the notes for a business document. 
    /// VALUE has to be specified, else the remark will be ignored.
    /// </summary>
    public class Remark
    {
        /// <summary>
        /// The remark itself
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The type of the remark. Custom types are allowed.
        ///
        /// List of predefined types:
        /// deliverynote, dispatchnotification, general, invoice,
        /// order, orderchange, orderresponse, quotation,
        /// receiptacknowledgement, remittanceadvice, invoicelist,
        /// rfqrfq, transport
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// The language used for the remark
        /// </summary>
        public string Lang { get; set; }
    }
}
