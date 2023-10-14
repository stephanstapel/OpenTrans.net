using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTrans.net {
    /// <summary>
    /// Represents a phone number of the ADDRESS type
    /// </summary>
    public class Phone {

        /// <summary>
        /// Value of the phone number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// predefined value for Type (see openTRANS spec ADDRESS)
        /// </summary>
        public static string typeMobile = "mobile";

        /// <summary>
        /// predefined value for the Type (see openTRANS spec ADDRESS)
        /// </summary>
        public static string typeOffice = "office";

        /// <summary>
        /// predefined value for the Type (see openTRANS spec ADDRESS)
        /// </summary>
        public static string typePrivate = "private";

        /// <summary>
        /// Type of the phone number - can be a predefined value (see above) or a custom value
        /// </summary>
        public string Type { get; set; }
    }
}
