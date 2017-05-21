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
using OpenTrans.net;
using System;
using System.Collections.Generic;

namespace OpenTrans.net_Test
{
    internal class Application
    {
        internal void run()
        {
            Order order = new Order()
            {
                Id = "OID1",
                OrderDate = new DateTime(2009, 05, 13, 6, 20, 0),
                DesiredDeliveryDateStart = new DateTime(2009, 05, 20, 10, 0, 0),
                DesiredDeliveryDateEnd = new DateTime(2009, 05, 20, 10, 0, 0),
            };

            order.Parties.Add(new Party()
            {
                Id = "a",
                Roles = { "buyer" },
                Name = "a",
                Name2 = "a",
                Name3 = "a",
                Department = "a",
                Street = "a",
                Zip = "a",
                BoxNo = "a",
                ZipBox = "a",
                City = "a",
                State = "a",
                CountryCode = CountryCodes.DE,
                VATId = "a",
                TaxNumber = "a"
            });

            order.OrderItems.Add(new OrderItem()
            {
                LineItemId = "1",
                OrderUnit = QuantityCodes.C62,
                Quantity = 1.0m,
                LineAmount = 1111,
                Remarks = new List<string>() { "a" }
            });

            order.Save("test.xml");
        }
    }
}