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
    /// Reference to the business partners integrated in the process of the document flow.
    /// 
    /// In combination with the element PARTY, this new element replaces the element ORDER_PARTIES.
    /// </summary>
    public class OrderPartiesReference
    {
        /// <summary>
        /// Reference to the buyer. It contains the unique identifier (PARTY_ID) of the respective party
        /// that is defined in the document(PARTY element).
        /// </summary>
        public PartyId BuyerIdRef;

        /// <summary>
        /// Reference to the supplier. It contains the unique identifier (PARTY_ID) of the respective
        /// party that is defined in the document(element PARTY).
        /// </summary>
        public PartyId SupplierIdRef;

        /// <summary>
        /// Refers to business partners integrated in the process of the goods delivery procedure.
        /// </summary>
        public ShipmentPartiesReference ShipmentPartiesReference;
    }
}
