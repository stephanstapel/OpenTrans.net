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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace OpenTrans.net
{
    class XmlUtils
    {
        /// <summary>
        ///  reads a certain attribute value
        /// </summary>
        public static string AttributeText(XmlNode node, string attributeName, string defaultText = "")
        {
            try
            {
                XmlAttribute attrib = node.Attributes[attributeName];
                if (attrib != null)
                {
                    return attrib.Value;
                }
            }
            catch
            {
            }

            return defaultText;
        } // !AttributeText()


        /// <summary>
        ///  reads the value from given xpath and interprets the value as boolean
        /// </summary>
        public static bool NodeAsBool(XmlNode node, string xpath, XmlNamespaceManager nsmgr = null, bool defaultValue = true)
        {
            if (node == null)
            {
                return defaultValue;
            }

            string value = NodeAsString(node, xpath, nsmgr);
            if (value == "")
            {
                return defaultValue;
            }
            else
            {
                if ((value.Trim().ToLower() == "true") || (value.Trim() == "1"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        } // !NodeAsBool()


        /// <summary>
        ///  reads the value from given xpath and interprets the value as string
        /// </summary>
        public static string NodeAsString(XmlNode node, string xpath, XmlNamespaceManager nsmgr = null, string defaultValue = "")
        {
            if (node == null)
            {
                return defaultValue;
            }

            try
            {
                XmlNode _node = node.SelectSingleNode(xpath, nsmgr);
                if (_node == null)
                {
                    return defaultValue;
                }
                else
                {
                    return _node.InnerText;
                }
            }
            catch (XPathException)
            {
                return defaultValue;
            }
            catch (Exception ex)
            {
                throw ex;
            };
        } // NodeAsString()


        public static int NodeAsInt(XmlNode node, string xpath, XmlNamespaceManager nsmgr = null, int defaultValue = 0)
        {
            if (node == null)
            {
                return defaultValue;
            }

            string temp = NodeAsString(node, xpath, nsmgr, "");
            if (Int32.TryParse(temp, out int retval))
            {
                return retval;
            }
            else
            {
                return defaultValue;
            }
        } // !NodeAsInt()


        /// <summary>
        ///  reads the value from given xpath and interprets the value as decimal
        /// </summary>
        public static decimal? NodeAsDecimal(XmlNode node, string xpath, XmlNamespaceManager nsmgr = null, decimal? defaultValue = null)
        {
            if (node == null)
            {
                return defaultValue;
            }

            string temp = NodeAsString(node, xpath, nsmgr, "");
            if (decimal.TryParse(temp, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal retval))
            {
                return retval;
            }
            else
            {
                return defaultValue;
            }
        } // !NodeAsDecimal()
    }
}
