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
    /// The element specifies on how the price is calculated based on the price-base. The calculation relies on the price-factor, the price-unit and the amount/number of supplied
    /// price-units.
    /// </summary>
    public class PriceBaseFix
    {
        /// <summary>
        /// Number of supplied price units. In the case of product prices not related to an order unit
        /// the total price of an item-line(PRICE_LINE_AMOUNT) is calculated using a price unit.
        /// Then the calculation of the total price of an item-line is the result of the multiplication of
        /// PRICE_UNIT_VALUE and PRICE_AMOUNT.
        /// </summary>
        public decimal PriceUnitValue { get; set; }

        /// <summary>
        /// Unit of measurement on which the price is calculated
        /// </summary>
        public QuantityCodes PriceUnit { get; set; }

        /// <summary>
        /// The price factor is the conversion factor for price unit and order unit. The underlying formula
        /// is: PRICE_UNIT equals PRICE_UNIT_FACTOR* ORDER_UNIT
        /// </summary>
        public decimal? PriceUnitFactor { get; set; }
    }
}
