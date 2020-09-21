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
    /// Identifier of the product from the perspective of the buyer. The included elements ensure the capability of a unique identification of a product.
    /// </summary>
    public class BuyerProductId    
    {
        /// <summary>
        /// The actual Id that is assigned from the perspective of the buyer
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// This attribute specifies the type of ID, i.e. indicates the organization that has issued the ID.
        /// </summary>
        public BuyerProductIdTypes Type { get; set; }
    }
}
