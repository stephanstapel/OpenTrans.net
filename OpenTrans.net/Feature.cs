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
    /// This element contains information on a product features (i.e., feature name, data type, explainations, domain).
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Unique name used to describe the feature within the Feature element.
        /// If in this feature is part of a referenced classification or feature group system, then the feature
        /// name must correspond to the name that is defined in the respective system.
        /// This element is language-dependent, thus the feature name has to be given in the language
        /// that is set in the document header(HEADER).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Actual value(s) of the respective feature
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Unit of measurement of the feature
        /// </summary>
        public QuantityCodes Unit { get; set; }

        /// <summary>
        /// Element which can be used to describe the exact meaning of the feature;
        /// the purpose of this element is not to explain the value of the feature in more
        /// detail.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Order in which the feature must appear in the referenced group in the target system; the
        /// order is fixed using ascending integer values
        /// If the element references a standard classification system which also pre-defines feature
        /// orders for features, the entry for the order in this element must correspond to the one predefined
        /// or the element can be left empty.
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// Definition of the feature
        /// </summary>
        public string Template { get; set; }
    }
}
