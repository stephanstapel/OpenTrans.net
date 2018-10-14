using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTrans.net
{
    /// <summary>
    /// data from here:
    /// https://datahub.io/core/country-list
    /// 
    /// to regenerate this file use:
    /// import os
    /// import sys
    /// import csv
    /// 
    /// 
    /// f = file("data_csv.csv")
    /// g = file("output.cs", "w+")
    /// 
    /// csvfile = csv.reader(f, delimiter = ',', quotechar = '"')
    /// next(csvfile, None) # skip header line
    /// 
    /// g.write("switch (code)\n")
    /// g.write("{\n")
    /// for line in csvfile:    
    /// g.write("\tcase CountryCodes." + line[1] + ":\n")
    /// g.write("\t\treturn \"" + line[0] + "\";\n")

    /// g.write("\tdefault:\n")
    /// g.write("\t\t{\n")
    /// g.write("\t\t\treturn \"\";\n")
    /// g.write("\t\t}\n")
    /// g.write("}\n")
    /// f.close()
    /// g.close()
    /// </summary>
    public class Countries
    {
        public static string GetCountry(CountryCodes code)
        {
            switch (code)
            {
                case CountryCodes.AF:
                    return "Afghanistan";
                case CountryCodes.AX:
                    return "Åland Islands";
                case CountryCodes.AL:
                    return "Albania";
                case CountryCodes.DZ:
                    return "Algeria";
                case CountryCodes.AS:
                    return "American Samoa";
                case CountryCodes.AD:
                    return "Andorra";
                case CountryCodes.AO:
                    return "Angola";
                case CountryCodes.AI:
                    return "Anguilla";
                case CountryCodes.AQ:
                    return "Antarctica";
                case CountryCodes.AG:
                    return "Antigua and Barbuda";
                case CountryCodes.AR:
                    return "Argentina";
                case CountryCodes.AM:
                    return "Armenia";
                case CountryCodes.AW:
                    return "Aruba";
                case CountryCodes.AU:
                    return "Australia";
                case CountryCodes.AT:
                    return "Austria";
                case CountryCodes.AZ:
                    return "Azerbaijan";
                case CountryCodes.BS:
                    return "Bahamas";
                case CountryCodes.BH:
                    return "Bahrain";
                case CountryCodes.BD:
                    return "Bangladesh";
                case CountryCodes.BB:
                    return "Barbados";
                case CountryCodes.BY:
                    return "Belarus";
                case CountryCodes.BE:
                    return "Belgium";
                case CountryCodes.BZ:
                    return "Belize";
                case CountryCodes.BJ:
                    return "Benin";
                case CountryCodes.BM:
                    return "Bermuda";
                case CountryCodes.BT:
                    return "Bhutan";
                case CountryCodes.BO:
                    return "Bolivia, Plurinational State of";
                case CountryCodes.BQ:
                    return "Bonaire, Sint Eustatius and Saba";
                case CountryCodes.BA:
                    return "Bosnia and Herzegovina";
                case CountryCodes.BW:
                    return "Botswana";
                case CountryCodes.BV:
                    return "Bouvet Island";
                case CountryCodes.BR:
                    return "Brazil";
                case CountryCodes.IO:
                    return "British Indian Ocean Territory";
                case CountryCodes.BN:
                    return "Brunei Darussalam";
                case CountryCodes.BG:
                    return "Bulgaria";
                case CountryCodes.BF:
                    return "Burkina Faso";
                case CountryCodes.BI:
                    return "Burundi";
                case CountryCodes.KH:
                    return "Cambodia";
                case CountryCodes.CM:
                    return "Cameroon";
                case CountryCodes.CA:
                    return "Canada";
                case CountryCodes.CV:
                    return "Cape Verde";
                case CountryCodes.KY:
                    return "Cayman Islands";
                case CountryCodes.CF:
                    return "Central African Republic";
                case CountryCodes.TD:
                    return "Chad";
                case CountryCodes.CL:
                    return "Chile";
                case CountryCodes.CN:
                    return "China";
                case CountryCodes.CX:
                    return "Christmas Island";
                case CountryCodes.CC:
                    return "Cocos (Keeling) Islands";
                case CountryCodes.CO:
                    return "Colombia";
                case CountryCodes.KM:
                    return "Comoros";
                case CountryCodes.CG:
                    return "Congo";
                case CountryCodes.CD:
                    return "Congo, the Democratic Republic of the";
                case CountryCodes.CK:
                    return "Cook Islands";
                case CountryCodes.CR:
                    return "Costa Rica";
                case CountryCodes.CI:
                    return "Côte d'Ivoire";
                case CountryCodes.HR:
                    return "Croatia";
                case CountryCodes.CU:
                    return "Cuba";
                case CountryCodes.CW:
                    return "Curaçao";
                case CountryCodes.CY:
                    return "Cyprus";
                case CountryCodes.CZ:
                    return "Czech Republic";
                case CountryCodes.DK:
                    return "Denmark";
                case CountryCodes.DJ:
                    return "Djibouti";
                case CountryCodes.DM:
                    return "Dominica";
                case CountryCodes.DO:
                    return "Dominican Republic";
                case CountryCodes.EC:
                    return "Ecuador";
                case CountryCodes.EG:
                    return "Egypt";
                case CountryCodes.SV:
                    return "El Salvador";
                case CountryCodes.GQ:
                    return "Equatorial Guinea";
                case CountryCodes.ER:
                    return "Eritrea";
                case CountryCodes.EE:
                    return "Estonia";
                case CountryCodes.ET:
                    return "Ethiopia";
                case CountryCodes.FK:
                    return "Falkland Islands (Malvinas)";
                case CountryCodes.FO:
                    return "Faroe Islands";
                case CountryCodes.FJ:
                    return "Fiji";
                case CountryCodes.FI:
                    return "Finland";
                case CountryCodes.FR:
                    return "France";
                case CountryCodes.GF:
                    return "French Guiana";
                case CountryCodes.PF:
                    return "French Polynesia";
                case CountryCodes.TF:
                    return "French Southern Territories";
                case CountryCodes.GA:
                    return "Gabon";
                case CountryCodes.GM:
                    return "Gambia";
                case CountryCodes.GE:
                    return "Georgia";
                case CountryCodes.DE:
                    return "Germany";
                case CountryCodes.GH:
                    return "Ghana";
                case CountryCodes.GI:
                    return "Gibraltar";
                case CountryCodes.GR:
                    return "Greece";
                case CountryCodes.GL:
                    return "Greenland";
                case CountryCodes.GD:
                    return "Grenada";
                case CountryCodes.GP:
                    return "Guadeloupe";
                case CountryCodes.GU:
                    return "Guam";
                case CountryCodes.GT:
                    return "Guatemala";
                case CountryCodes.GG:
                    return "Guernsey";
                case CountryCodes.GN:
                    return "Guinea";
                case CountryCodes.GW:
                    return "Guinea-Bissau";
                case CountryCodes.GY:
                    return "Guyana";
                case CountryCodes.HT:
                    return "Haiti";
                case CountryCodes.HM:
                    return "Heard Island and McDonald Islands";
                case CountryCodes.VA:
                    return "Holy See (Vatican City State)";
                case CountryCodes.HN:
                    return "Honduras";
                case CountryCodes.HK:
                    return "Hong Kong";
                case CountryCodes.HU:
                    return "Hungary";
                case CountryCodes.IS:
                    return "Iceland";
                case CountryCodes.IN:
                    return "India";
                case CountryCodes.ID:
                    return "Indonesia";
                case CountryCodes.IR:
                    return "Iran, Islamic Republic of";
                case CountryCodes.IQ:
                    return "Iraq";
                case CountryCodes.IE:
                    return "Ireland";
                case CountryCodes.IM:
                    return "Isle of Man";
                case CountryCodes.IL:
                    return "Israel";
                case CountryCodes.IT:
                    return "Italy";
                case CountryCodes.JM:
                    return "Jamaica";
                case CountryCodes.JP:
                    return "Japan";
                case CountryCodes.JE:
                    return "Jersey";
                case CountryCodes.JO:
                    return "Jordan";
                case CountryCodes.KZ:
                    return "Kazakhstan";
                case CountryCodes.KE:
                    return "Kenya";
                case CountryCodes.KI:
                    return "Kiribati";
                case CountryCodes.KP:
                    return "Korea, Democratic People's Republic of";
                case CountryCodes.KR:
                    return "Korea, Republic of";
                case CountryCodes.KW:
                    return "Kuwait";
                case CountryCodes.KG:
                    return "Kyrgyzstan";
                case CountryCodes.LA:
                    return "Lao People's Democratic Republic";
                case CountryCodes.LV:
                    return "Latvia";
                case CountryCodes.LB:
                    return "Lebanon";
                case CountryCodes.LS:
                    return "Lesotho";
                case CountryCodes.LR:
                    return "Liberia";
                case CountryCodes.LY:
                    return "Libya";
                case CountryCodes.LI:
                    return "Liechtenstein";
                case CountryCodes.LT:
                    return "Lithuania";
                case CountryCodes.LU:
                    return "Luxembourg";
                case CountryCodes.MO:
                    return "Macao";
                case CountryCodes.MK:
                    return "Macedonia, the Former Yugoslav Republic of";
                case CountryCodes.MG:
                    return "Madagascar";
                case CountryCodes.MW:
                    return "Malawi";
                case CountryCodes.MY:
                    return "Malaysia";
                case CountryCodes.MV:
                    return "Maldives";
                case CountryCodes.ML:
                    return "Mali";
                case CountryCodes.MT:
                    return "Malta";
                case CountryCodes.MH:
                    return "Marshall Islands";
                case CountryCodes.MQ:
                    return "Martinique";
                case CountryCodes.MR:
                    return "Mauritania";
                case CountryCodes.MU:
                    return "Mauritius";
                case CountryCodes.YT:
                    return "Mayotte";
                case CountryCodes.MX:
                    return "Mexico";
                case CountryCodes.FM:
                    return "Micronesia, Federated States of";
                case CountryCodes.MD:
                    return "Moldova, Republic of";
                case CountryCodes.MC:
                    return "Monaco";
                case CountryCodes.MN:
                    return "Mongolia";
                case CountryCodes.ME:
                    return "Montenegro";
                case CountryCodes.MS:
                    return "Montserrat";
                case CountryCodes.MA:
                    return "Morocco";
                case CountryCodes.MZ:
                    return "Mozambique";
                case CountryCodes.MM:
                    return "Myanmar";
                case CountryCodes.NA:
                    return "Namibia";
                case CountryCodes.NR:
                    return "Nauru";
                case CountryCodes.NP:
                    return "Nepal";
                case CountryCodes.NL:
                    return "Netherlands";
                case CountryCodes.NC:
                    return "New Caledonia";
                case CountryCodes.NZ:
                    return "New Zealand";
                case CountryCodes.NI:
                    return "Nicaragua";
                case CountryCodes.NE:
                    return "Niger";
                case CountryCodes.NG:
                    return "Nigeria";
                case CountryCodes.NU:
                    return "Niue";
                case CountryCodes.NF:
                    return "Norfolk Island";
                case CountryCodes.MP:
                    return "Northern Mariana Islands";
                case CountryCodes.NO:
                    return "Norway";
                case CountryCodes.OM:
                    return "Oman";
                case CountryCodes.PK:
                    return "Pakistan";
                case CountryCodes.PW:
                    return "Palau";
                case CountryCodes.PS:
                    return "Palestine, State of";
                case CountryCodes.PA:
                    return "Panama";
                case CountryCodes.PG:
                    return "Papua New Guinea";
                case CountryCodes.PY:
                    return "Paraguay";
                case CountryCodes.PE:
                    return "Peru";
                case CountryCodes.PH:
                    return "Philippines";
                case CountryCodes.PN:
                    return "Pitcairn";
                case CountryCodes.PL:
                    return "Poland";
                case CountryCodes.PT:
                    return "Portugal";
                case CountryCodes.PR:
                    return "Puerto Rico";
                case CountryCodes.QA:
                    return "Qatar";
                case CountryCodes.RE:
                    return "Réunion";
                case CountryCodes.RO:
                    return "Romania";
                case CountryCodes.RU:
                    return "Russian Federation";
                case CountryCodes.RW:
                    return "Rwanda";
                case CountryCodes.BL:
                    return "Saint Barthélemy";
                case CountryCodes.SH:
                    return "Saint Helena, Ascension and Tristan da Cunha";
                case CountryCodes.KN:
                    return "Saint Kitts and Nevis";
                case CountryCodes.LC:
                    return "Saint Lucia";
                case CountryCodes.MF:
                    return "Saint Martin (French part)";
                case CountryCodes.PM:
                    return "Saint Pierre and Miquelon";
                case CountryCodes.VC:
                    return "Saint Vincent and the Grenadines";
                case CountryCodes.WS:
                    return "Samoa";
                case CountryCodes.SM:
                    return "San Marino";
                case CountryCodes.ST:
                    return "Sao Tome and Principe";
                case CountryCodes.SA:
                    return "Saudi Arabia";
                case CountryCodes.SN:
                    return "Senegal";
                case CountryCodes.RS:
                    return "Serbia";
                case CountryCodes.SC:
                    return "Seychelles";
                case CountryCodes.SL:
                    return "Sierra Leone";
                case CountryCodes.SG:
                    return "Singapore";
                case CountryCodes.SX:
                    return "Sint Maarten (Dutch part)";
                case CountryCodes.SK:
                    return "Slovakia";
                case CountryCodes.SI:
                    return "Slovenia";
                case CountryCodes.SB:
                    return "Solomon Islands";
                case CountryCodes.SO:
                    return "Somalia";
                case CountryCodes.ZA:
                    return "South Africa";
                case CountryCodes.GS:
                    return "South Georgia and the South Sandwich Islands";
                case CountryCodes.SS:
                    return "South Sudan";
                case CountryCodes.ES:
                    return "Spain";
                case CountryCodes.LK:
                    return "Sri Lanka";
                case CountryCodes.SD:
                    return "Sudan";
                case CountryCodes.SR:
                    return "Suriname";
                case CountryCodes.SJ:
                    return "Svalbard and Jan Mayen";
                case CountryCodes.SZ:
                    return "Swaziland";
                case CountryCodes.SE:
                    return "Sweden";
                case CountryCodes.CH:
                    return "Switzerland";
                case CountryCodes.SY:
                    return "Syrian Arab Republic";
                case CountryCodes.TW:
                    return "Taiwan, Province of China";
                case CountryCodes.TJ:
                    return "Tajikistan";
                case CountryCodes.TZ:
                    return "Tanzania, United Republic of";
                case CountryCodes.TH:
                    return "Thailand";
                case CountryCodes.TL:
                    return "Timor-Leste";
                case CountryCodes.TG:
                    return "Togo";
                case CountryCodes.TK:
                    return "Tokelau";
                case CountryCodes.TO:
                    return "Tonga";
                case CountryCodes.TT:
                    return "Trinidad and Tobago";
                case CountryCodes.TN:
                    return "Tunisia";
                case CountryCodes.TR:
                    return "Turkey";
                case CountryCodes.TM:
                    return "Turkmenistan";
                case CountryCodes.TC:
                    return "Turks and Caicos Islands";
                case CountryCodes.TV:
                    return "Tuvalu";
                case CountryCodes.UG:
                    return "Uganda";
                case CountryCodes.UA:
                    return "Ukraine";
                case CountryCodes.AE:
                    return "United Arab Emirates";
                case CountryCodes.GB:
                    return "United Kingdom";
                case CountryCodes.US:
                    return "United States";
                case CountryCodes.UM:
                    return "United States Minor Outlying Islands";
                case CountryCodes.UY:
                    return "Uruguay";
                case CountryCodes.UZ:
                    return "Uzbekistan";
                case CountryCodes.VU:
                    return "Vanuatu";
                case CountryCodes.VE:
                    return "Venezuela, Bolivarian Republic of";
                case CountryCodes.VN:
                    return "Viet Nam";
                case CountryCodes.VG:
                    return "Virgin Islands, British";
                case CountryCodes.VI:
                    return "Virgin Islands, U.S.";
                case CountryCodes.WF:
                    return "Wallis and Futuna";
                case CountryCodes.EH:
                    return "Western Sahara";
                case CountryCodes.YE:
                    return "Yemen";
                case CountryCodes.ZM:
                    return "Zambia";
                case CountryCodes.ZW:
                    return "Zimbabwe";
                default:
                    {
                        return "";
                    }
            }
        }
    }
}
