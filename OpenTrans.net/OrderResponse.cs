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
    /// Every valid ORDERRESPONSE business document in openTRANS®-Format is triggered by the root element ORDERRESPONSE and consists of a header
    /// (ORDERRESPONSE_HEADER), an item level(ORDERRESPONSE_ITEM_LIST) and a summary(ORDERRESPONSE_SUMMARY).
    /// The header is at the beginning of the business document and contains global data valid for all types of business data exchange such as, for example information on suppliers or
    /// information on skeleton agreements which may exist between the buyer and the supplier.The header also lays down default settings for the following item level.
    /// The item level contains the individual positions in the order. In this, information is taken over from the header on the item level, provided it has not been overwritten on item level.
    /// The summary contains a summary of the information on the order.The information in this element is redundant and can be used for control and statistical purposes.
    /// </summary>
    public class OrderResponse
    {
        /// <summary>
        /// Unique order number of the buyer
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Unique order number of the supplier
        /// </summary>
        public string SupplierOrderId { get; set; }

        /// <summary>
        /// Date of the order
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// The alteration sequence is increased by one with the dispatch of each ORDERCHANGE
        /// business document.The numbering begins at 1.
        /// </summary>
        public int OrderChangeSequenceId { get; set; }

        /// <summary>
        /// List of parties that are relevant to this business document
        /// </summary>
        public List<Party> Parties { get; set; } = new List<Party>();

        /// <summary>
        /// This list represents the list of items in the order
        /// </summary>
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        /// <summary>
        /// Loads an order response from the given stream.
        /// 
        /// Make sure that the stream is open. After successful reading, the stream is left open, i.e.
        /// the caller of the library has to take care of the stream lifecycle.
        /// 
        /// If the stream is not open or readable, an IllegalStreamException exception is raised.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static OrderResponse Load(Stream stream)
        {
            OrderResponseReader reader = new OrderResponseReader();
            return reader.Load(stream);
        } // !Load()


        /// <summary>
        /// Loads an order response from the given file.
        /// If the file does not exist, a FileNotFoundException exception is raised.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static OrderResponse Load(string fileName)
        {
            OrderResponseReader reader = new OrderResponseReader();
            return reader.Load(fileName);
        } // !Load()


        /// <summary>
        /// Saves the order response object into a stream.
        /// 
        /// The stream position will be reset to the original position after writing is finished.
        /// This allows easy further processing of the stream.
        /// </summary>
        /// <param name="stream"></param>
        public void Save(Stream stream)
        {
            OrderResponseWriter writer = new OrderResponseWriter();
            writer.Save(this, stream);
        } // !Save()


        /// <summary>
        /// Saves the order response into the given file.
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            OrderResponseWriter writer = new OrderResponseWriter();
            writer.Save(this, fileName);
        } // !Save()
    }
}
