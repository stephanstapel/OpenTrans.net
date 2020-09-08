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
    /// Identifier of the product. The included elements ensure the capability of a unique identification of a product.
    /// </summary>
    public class ProductId
    {
        /// <summary>
        /// This element contains the product number issued by the supplier. It is determining for ordering the product; it identifies the product in the supplier catalog.
        /// </summary>
        public SupplierProductId SupplierPId { get; set; }
        public PartyId SupplierIdRef { get; set; }
        public BuyerProductId BuyerPId { get; set; }        
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
    }
}