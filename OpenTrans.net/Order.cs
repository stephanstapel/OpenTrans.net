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
using System.IO;

namespace OpenTrans.net
{
    /// <summary>
    /// Order that is issues from a Buyer to a Seller.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique order number of the buyer
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Date of the order
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Date of shipment. The delivery date specifies the date the commissioned goods are accepted
        /// by the buyer.If the delivery date deviates from the one specified in the header, the
        /// delivery date on item level is valid.To specify exact one date for the shipment, e.g. in the
        /// RECEIPTACKNOWLEDGEMENT-document.
        /// 
        /// This property is accompanied by the property DesiredDeliveryDateEnd which specifies the end of the 
        /// delivery window.
        /// </summary>
        public DateTime DesiredDeliveryDateStart { get; set; }

        /// <summary>
        /// Date of shipment. The delivery date specifies the date the commissioned goods are accepted
        /// by the buyer.If the delivery date deviates from the one specified in the header, the
        /// delivery date on item level is valid.To specify exact one date for the shipment, e.g. in the
        /// RECEIPTACKNOWLEDGEMENT-document.
        /// 
        /// This property is accompanied by the property DesiredDeliveryDateStart which specifies the start of the 
        /// delivery window.
        /// </summary>
        public DateTime DesiredDeliveryDateEnd { get; set; }

        /// <summary>
        /// The element is related to an item and refers to the previous order where the item was ordered
        /// by the customer(purchasing party)
        /// </summary>
        public CustomerOrderReference CustomerOrderReference { get; set; }

        /// <summary>
        /// Reference to the business partners integrated in the process of the document flow
        /// </summary>
        public OrderPartiesReference OrderPartiesReference { get; set; }

        /// <summary>
        /// Provides the currency that is default for all price information in the catalog. If the price of a
        /// product has a different currency, or this element is not used, the the currency has to be
        /// specified in the corresponding element for the respective product.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Flag to indicate whether partial shipment is allowed. If allowed the value is TRUE, FALSE
        /// otherwise.The flag is binding for the order, i.e. if the value is set to FALSE and only partial
        ///  shipments can be made by the recipient of the order, the order shall be invalid.
        /// </summary>
        public bool PartialShipmentAllowed { get; set; }

        /// <summary>
        /// List of parties that are relevant to this business document
        /// </summary>
        public List<Party> Parties { get; set; } = new List<Party>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public OrderSummary OrderSummary { get; set; }


        /// <summary>
        /// Loads an order from the given stream.
        /// 
        /// Make sure that the stream is open. After successful reading, the stream is left open, i.e.
        /// the caller of the library has to take care of the stream lifecycle.
        /// 
        /// If the stream is not open or readable, an IllegalStreamException exception is raised.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Order Load(Stream stream)
        {
            OrderReader reader = new OrderReader();
            return reader.Load(stream);
        } // !Load()


        /// <summary>
        /// Loads an order from the given file.
        /// If the file does not exist, a FileNotFoundException exception is raised.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Order Load(string filename)
        {
            OrderReader reader = new OrderReader();
            return reader.Load(filename);
        } // !Load()


        /// <summary>
        /// Saves the order object into a stream.
        /// 
        /// The stream position will be reset to the original position after writing is finished.
        /// This allows easy further processing of the stream.
        /// </summary>
        /// <param name="stream"></param>
        public void Save(Stream stream)
        {
            OrderWriter writer = new OrderWriter();
            writer.Save(this, stream);
        } // !Save()


        /// <summary>
        /// Saves the order into the given file.
        /// </summary>
        /// <param name="filename"></param>
        public void Save(string filename)
        {
            OrderWriter writer = new OrderWriter();
            writer.Save(this, filename);
        } // !Save()
    }
}
