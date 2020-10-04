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

        /// <summary>
        /// Reference to the supplier. It contains the unique identifier (PARTY_ID) of the respective
        /// party that is defined in the document(element PARTY).
        /// </summary>
        public PartyId SupplierIdRef { get; set; }

        /// <summary>
        /// Product number used by the buying firm. The "type" attribute specifies the type of ID.
        /// If the element is used multiple, the values of the attribute "type" must differ.
        /// </summary>
        public BuyerProductId BuyerPId { get; set; }

        /// <summary>
        /// This element contains the short description of the product. In general, the description
        /// should be short and, whithin the first 40 characters, unique and meaningful, because many
        /// software systems can only interpret these 40 characters(i.e.SAP-OCI, SAP R/3).
        /// Detailed descriptions are beneficial to product search, especially if many products are quite
        /// similar and differ only in specific details.In these cases, product search returns a list of
        /// products from which the right product can easily be determined.
        /// Abbreviations of essential product characteristics should be avoided (e.g., bw for black
        /// and white). However, abbreviations of organisations and standards can be used(e.g.,
        /// ISO, VDE).
        /// </summary>
        public string DescriptionShort { get; set; }

        /// <summary>
        /// This element contains the long description of the product.
        /// Format: The following HTML tags are supported: &lt;b&gt; for bold, &lt;i&gt; for italic, &lt;p&gt; for paragraphs,
        /// &lt;br&gt; for line break and &lt;ul&gt;/&lt;li&gt; for lists.In order to transfer these, the characters
        /// '&lt;‘ and '&gt;‘ must be enclosed in quotation marks, or the BMEcat DTD will not be accepted
        /// by the XML parser(see also chapter Character encoding in XML).
        /// Example: '&lt;' = &lt; or '&gt;' = &gt;
        /// 
        /// Please note:
        /// The target system must support the interpretation of the day in order to achieve the desired
        /// formatting.
        /// </summary>
        public string DescriptionLong { get; set; }
    }
}