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
    public class Order
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DesiredDeliveryDateStart { get; set; }
        public DateTime DesiredDeliveryDateEnd { get; set; }
        public List<Party> Parties { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            this.Parties = new List<Party>();
            this.OrderItems = new List<OrderItem>();
        }


        public static Order Load(Stream stream)
        {
            return OrderReader.Load(stream);
        } // !Load()


        public static Order Load(string filename)
        {
            return OrderReader.Load(filename);
        } // !Load()


        /// <summary>
        /// Saves the descriptor object into a stream.
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


        public void Save(string filename)
        {
            OrderWriter writer = new OrderWriter();
            writer.Save(this, filename);
        } // !Save()
    }
}
