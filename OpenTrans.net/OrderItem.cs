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
using System.Collections.Generic;

namespace OpenTrans.net
{
    /// <summary>
    /// A item line contains order information about exactly one item. Any number of item lines can be used, although at least one item line must be used.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// The item ID number is used to uniquely identify the item line of an order within that order.
        /// In combination with the order number and the buyer the item number represents a unique
        /// ID number outside the business process concerned.Example.: P100012
        /// </summary>
        public string LineItemId { get; set; }

        /// <summary>
        /// Identifier of the product. The included elements ensure the capability of a unique identification of a product.
        /// </summary>
        public ProductId ProductId { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public decimal? Quantity { get; set; }

        /// <summary>
        /// A fixed product price
        /// </summary>
        public ProductPriceFix ProductPriceFix { get; set; }

        /// <summary>
        /// Unit in which the product can be ordered; it is only possible to order multiples of the product
        /// unit.
        ///
        /// The price also always refers to this unit(or to part of or multiples of it).
        /// Example: Crate of mineral water with 6 bottles
        /// Order unit: "crate", contents unit/unit of the article: "bottle"
        /// Packing quantity: "6" namespace: BMECAT
        /// </summary>
        public QuantityCodes OrderUnit { get; set; }

        /// <summary>
        /// The total price of the item-line.
        /// </summary>
        public decimal? LineAmount { get; set; }

        /// <summary>
        /// Date of shipment. The delivery date specifies the date the commissioned goods are accepted by
        /// the buyer. If the delivery date deviates from the one specified in the header, the delivery
        /// date on item level is valid.
        /// </summary>
        public DeliveryDate DeliveryDate { get; set; }

        /// <summary>
        /// Remark related to a business document
        /// </summary>
        public List<string> Remarks { get; set; }

        /// <summary>
        /// Description of the product by features and/or classification of the product
        /// </summary>
        public List<Feature> ProductFeatures { get; set; }


        public OrderItem()
        {
            this.Remarks = new List<string>();
            this.ProductFeatures = new List<Feature>();
        }
    }
}
