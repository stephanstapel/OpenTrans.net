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
    /// The element specifies a fixed price related to a product. In contrast to the element PRICE_LINE_AMOUNT the fixed product price does not contain any dynamic/variable
    /// decision opportunities(like graduated prices in relation to the ordered quantity). Therefore the element specifies a value not a price policy.The element should only be used in
    /// documents where usually price-information is contained (e.g.invoice).
    /// </summary>
    public class ProductPriceFix
    {
        /// <summary>
        /// Amount of the price
        /// </summary>
        public decimal PriceAmount { get; set; }

        /// <summary>
        /// If nothing is specified in this field the default value 1 is assumed, in other words the price
        /// refers to exactly one order unit.If specified, a multiple or a fraction of the order unit
        /// (element ORDER_UNIT) which indicates the quantity to which all the specified prices refer.
        /// Example: 10 (i.e.the specified price refers to 10 crates)
        /// </summary>
        public decimal? PriceQuantity { get; set; }

        /// <summary>
        /// Specifies the calculation of a price
        /// </summary>
        public PriceBaseFix PriceBaseFix { get; set; }
    }
}
