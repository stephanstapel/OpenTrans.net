using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace OpenTrans.net.UnitTests
{
    /// <summary>
    /// Validates documents against the official openTRANS 2.1 schema
    /// </summary>
    internal static class SchemaValidator
    {
        private static readonly Lazy<XmlSchemaSet> _Schemas = new Lazy<XmlSchemaSet>(_loadSchemas);


        /// <summary>
        /// Returns all validation errors and warnings, an empty list if the document is valid
        /// </summary>
        internal static List<string> Validate(string xml)
        {
            List<string> errors = new List<string>();
            XmlReaderSettings settings = new XmlReaderSettings()
            {
                ValidationType = ValidationType.Schema,
                Schemas = _Schemas.Value,
                ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings
            };
            settings.ValidationEventHandler += (sender, e) => errors.Add($"{e.Severity} (line {e.Exception.LineNumber}): {e.Message}");

            using (XmlReader reader = XmlReader.Create(new StringReader(xml), settings))
            {
                while (reader.Read())
                {
                }
            }

            return errors;
        } // !Validate()


        private static XmlSchemaSet _loadSchemas()
        {
            string schemaPath = Path.Combine(AppContext.BaseDirectory, "Schemas", "opentrans_2_1.xsd");
            XmlReaderSettings settings = new XmlReaderSettings()
            {
                // xmldsig-core-schema.xsd contains a DTD
                DtdProcessing = DtdProcessing.Parse
            };

            XmlSchemaSet schemas = new XmlSchemaSet() { XmlResolver = new XmlUrlResolver() };
            using (XmlReader reader = XmlReader.Create(schemaPath, settings))
            {
                schemas.Add("http://www.opentrans.org/XMLSchema/2.1", reader);
            }
            schemas.Compile();
            return schemas;
        } // !_loadSchemas()
    }
}
