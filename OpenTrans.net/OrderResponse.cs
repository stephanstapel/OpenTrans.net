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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTrans.net
{
    public class OrderResponse
    {
        public string OrderId { get; set; }
        public string SupplierOrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int OrderChangeSequenceId { get; set; }
        public List<Party> Parties { get; set; } = new List<Party>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();



        public static OrderResponse Load(Stream stream)
        {
            OrderResponseReader reader = new OrderResponseReader();
            return reader.Load(stream);
        } // !Load()


        public static OrderResponse Load(string filename)
        {
            OrderResponseReader reader = new OrderResponseReader();
            return reader.Load(filename);
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


        public void Save(string filename)
        {
            OrderResponseWriter writer = new OrderResponseWriter();
            writer.Save(this, filename);
        } // !Save()
    }
}
