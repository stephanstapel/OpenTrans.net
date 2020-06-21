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
            _createOrder();
            _createOrderResponse();
        }


        private void _createOrderResponse()
        {
            OrderResponse response = new OrderResponse()
            {
                Id = "GWAHJV-160131-1470",
                OrderDate = new DateTime(2016, 01, 31, 18, 29, 31),
                OrderChangeSequenceId = 1
            };

            response.Parties.Add(new Party()
            {
                Ids = new List<PartyId>() { new PartyId() { Id = "123456", Type = PartyIdTypes.SupplierSpecific } },
                Roles = { "buyer" },
                Name = "ITscope GmbH",
                Name2 = "Online Plattform",
                Name3 = String.Empty,
                Department = "a",
                Street = "Ludwig-Erhard-Allee 20",
                Zip = "76131",
                City = "Karlsruhe",
                CountryCode = CountryCodes.DE,
                ContactDetails = new Contact()
                {
                    Name = "Support",
                    FirstName = "ITscope",
                    EmailAddresses = { "support@itscope.com" }
                }
            });

            response.Parties.Add(new Party()
            {
                Ids = new List<PartyId>() { new PartyId() { Id = "123456", Type = PartyIdTypes.SupplierSpecific } },
                Roles = { "delivery" },
                Name = "ITscope GmbH",
                Name2 = "Online Plattform",
                Name3 = String.Empty,
                Department = "a",
                Street = "Ludwig-Erhard-Allee 20",
                Zip = "76131",
                City = "Karlsruhe",
                CountryCode = CountryCodes.DE,
                ContactDetails = new Contact()
                {
                    Name = "Support",
                    FirstName = "ITscope",
                    EmailAddresses = { "support@itscope.com" }
                }
            });

            response.Parties.Add(new Party()
            {
                Ids = new List<PartyId>() { new PartyId() { Id = "123456", Type = PartyIdTypes.SupplierSpecific } },
                Roles = { "invoice_recipient" },
                Name = "ITscope GmbH",
                Name2 = "Online Plattform",
                Name3 = String.Empty,
                Department = "a",
                Street = "Ludwig-Erhard-Allee 20",
                Zip = "76131",
                City = "Karlsruhe",
                CountryCode = CountryCodes.DE,
                ContactDetails = new Contact()
                {
                    Name = "Support",
                    FirstName = "ITscope",
                    EmailAddresses = { "support@itscope.com" }
                }
            });

            response.Parties.Add(new Party()
            {
                Ids = new List<PartyId>() { new PartyId() { Id = "10000735", Type = PartyIdTypes.SupplierSpecific } },
                Roles = { "supplier" },
                Name = "ITscope GmbH",
                Name2 = "Online Plattform",
                Name3 = String.Empty,
                Department = "a",
                Street = "Ludwig-Erhard-Allee 20",
                Zip = "76131",
                City = "Karlsruhe",
                CountryCode = CountryCodes.DE,
                ContactDetails = new Contact()
                {
                    Name = "Support",
                    FirstName = "ITscope",
                    EmailAddresses = { "support@itscope.com" }
                }
            });

            response.OrderItems.Add(new OrderItem()
            {
                LineItemId = "100",
                ProductId = new ProductId()
                {
                    SupplierPId = "123002",
                    DescriptionShort = "APPLE iPad Air 2 64GB 3G 4G Grau",
                    DescriptionLong = "APPLE iPad Air 2 64GB 3G 4G Grau&lt;br /&gt;24.63cm/9.7\" IPS(2048 x 1536), Kamera auf Rück - &lt; br / &gt; und Vorderseite, &lt; br / &gt; Bluetooth, Wi - Fi, 4G, Space - grau"
                },
                Quantity = 1,
                OrderUnit = QuantityCodes.C62,
                LineAmount = 562
            });


            response.Save("BE_RESPONSE.xml");
        } // !_createOrderResponse()


        private void _createOrder()
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
                Ids = new List<PartyId>() { new PartyId() { Id = "a", Type = PartyIdTypes.SupplierSpecific } },
                Roles = { PartyRoles.Buyer },
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
                TaxNumber = "a",
                Url = "a",
                FaxNo = "a",
                PhoneNo = "a",
                EmailAddresses = new List<string>()
                {
                    "a",
                    "a"
                }
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

            Order order2 = Order.Load("test.xml");
        } // !_createOrder()
    }
}