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

namespace OpenTrans.net
{
    /// <summary>
    /// ISO Quantity Codes
    /// 
    /// For web reference, see e.g.
    /// English: https://resources.gs1us.org/GS1-US-Data-Hub-Help-Center/ArtMID/3451/ArticleID/116/Unit-of-Measure-Codes,
    /// German: http://www.robert-kuhlemann.de/iso_masseinheiten.htm
    /// </summary>
    public enum QuantityCodes
    {   
        /// <summary>
        /// English: Invalid Quantity Code
        /// German: Ungültige Maßeinheit
        /// </summary>
        Unknown,
        
        /// <summary>
        /// English: Year
        /// German: Jahr
        /// </summary>
        ANN,
        
        /// <summary>
        /// English: Bag
        /// German: Beutel
        /// </summary>
        BG,
        
        /// <summary>
        /// English: Bucket
        /// German: Eimer / Kübel
        /// </summary>
        BJ,
        
        /// <summary>
        /// English: Basket
        /// German: Korb
        /// </summary>
        BK,
        
        /// <summary>
        /// English: Bottle
        /// German: Flasche
        /// </summary>
        BO,

        /// <summary>
        /// English: Box
        /// German: Box
        /// </summary>
        BX,
        
        /// <summary>
        /// English: One / Piece (pc.)
        /// German: Eins / Stück (Stk.)
        /// </summary>
        C62,
        
        /// <summary>
        /// English: Container
        /// German: Kanister
        /// </summary>
        CH,
        
        /// <summary>
        /// English: Crate
        /// German: Kiste
        /// </summary>
        CR,
        
        /// <summary>
        /// English: Case
        /// German: Kasten
        /// </summary>
        CS,

        /// <summary>
        /// English: Carton
        /// German: Karton
        /// </summary>
        CT,
        
        /// <summary>
        /// English: Pallet (unit load)
        /// German: Pallet
        /// </summary>
        D97,
        
        /// <summary>
        /// English: Day
        /// German: Tag
        /// SI Unit: d
        /// </summary>
        DAY,
        
        /// <summary>
        /// English: Drum
        /// German: Trommel
        /// </summary>
        DR,
        
        /// <summary>
        /// English: Piece (a single item, article or exemplar)
        /// German: Stück (einzelner Gegenstand, Artikel oder Exemplar)
        /// </summary>
        H87,
        
        /// <summary>
        /// English: Hectare
        /// German: Hektar
        /// SI Unit: ha
        /// </summary>
        HAR,
        
        /// <summary>
        /// English: Hour (hrs.)
        /// German: Stunde (Std.)
        /// SI Unit: h 
        /// </summary>
        HUR,
        
        /// <summary>
        /// English: Kilogram
        /// German: Kilogramm
        /// SI Unit: kg
        /// </summary>
        KGM,
        
        /// <summary>
        /// English: Kilometre
        /// German: Kilometer
        /// SI Unit: km
        /// </summary>
        KTM,
        
        /// <summary>
        /// English: Kilowatt hour
        /// German: Kilowattstunde
        /// SI Unit: kWh
        /// </summary>
        KWH,
        
        /// <summary>
        /// English: Lump sum
        /// German: Pauschale
        /// </summary>
        LS,
        
        /// <summary>
        /// English: Litre
        /// German: Liter
        /// SI Unit: l
        /// </summary>
        LTR,
        
        /// <summary>
        /// English: Minute
        /// German: Minute
        /// SI Unit: min
        /// </summary>
        MIN,
        
        /// <summary>
        /// English: Square millimetre
        /// German: Quadratmillimeter
        /// SI Unit: mm^2
        /// </summary>
        MMK,
        
        /// <summary>
        /// English: Millimetre
        /// German: Millimeter
        /// SI Unit: mm 
        /// </summary>
        MMT,
        
        /// <summary>
        /// English: Month
        /// German: Monat
        /// </summary>
        MON,
        
        /// <summary>
        /// English: Square metre
        /// German: Quadratmeter
        /// SI Unit: m^2
        /// </summary>
        MTK,
        
        /// <summary>
        /// English: Cubic metre
        /// German: Kubikmeter
        /// SI Unit: mm^3
        /// </summary>
        MTQ,
        
        /// <summary>
        /// English: Metre
        /// German: Meter
        /// SI Unit: m
        /// </summary>
        MTR,
        
        /// <summary>
        /// English: Number of articles
        /// German: Anzahl Artikel
        /// </summary>
        NAR,
        
        /// <summary>
        /// English: Number of pairs (pr.)
        /// German: Anzahl Paare (Pr.)
        /// </summary>
        NPR,
        
        /// <summary>
        /// English: Percent (pct.)
        /// German: Prozent
        /// Symbol: %
        /// </summary>
        P1,
        
        /// <summary>
        /// English: Piece
        /// German: Stück
        /// </summary>
        PCE,
        
        /// <summary>
        /// English: Pallet (lift)
        /// German: Palette
        /// </summary>
        PF,
        
        /// <summary>
        /// English: Package
        /// German: Pack / Paket
        /// </summary>
        PK,
        
        /// <summary>
        /// English: Roll
        /// German: Rolle
        /// </summary>
        RO,

        /// <summary>
        /// English: Sack
        /// German: Sack
        /// </summary>
        SA,
        
        /// <summary>
        /// English: Second (sec.)
        /// German: Sekunde (Sek.)
        /// SI Unit: s
        /// </summary>
        SEC,
        
        /// <summary>
        /// English: Set
        /// German: Set
        /// </summary>
        SET,
        
        /// <summary>
        /// English: Tin
        /// German: Dose
        /// </summary>
        TN,
        
        /// <summary>
        /// English: Ton (metric)
        /// German: Tonne (metrisch)
        /// SI Unit: t
        /// </summary>
        TNE,
        
        /// <summary>
        /// English: Ten pack
        /// German: Zehnerpack
        /// </summary>
        TP,
        
        /// <summary>
        /// English: Ten pair
        /// German: Zehnerpaar
        /// </summary>
        TPR,
        
        /// <summary>
        /// English: Three pack
        /// German: Dreierpack
        /// </summary>
        P3,
        
        /// <summary>
        /// English: Tray / Tray pack
        /// German: Schale / Tray-Verpackung
        /// </summary>
        PU,
        
        /// <summary>
        /// English: Tube
        /// German: Tube
        /// </summary>
        TU,
        
        /// <summary>
        /// English: Bulk
        /// German: Großmenge
        /// </summary>
        VQ,
        
        /// <summary>
        /// English: Week
        /// German: Woche
        /// </summary>
        WEE
    }
    
    internal static class QuantityCodesExtensions
    {
        public static QuantityCodes FromString(this QuantityCodes c, string s)
        {
            try
            {
                return (QuantityCodes) Enum.Parse(typeof(QuantityCodes), s);
            }
            catch
            {
                return QuantityCodes.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this QuantityCodes c)
        {
            return c.ToString("g");
        } // !ToString()
    }
}
