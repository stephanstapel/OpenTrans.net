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
        /// Unknown / Invalid Quantity Code
        /// </summary>
        Unknown,
        
        /// <summary>
        /// Group
        /// </summary>
        Code_10,

        /// <summary>
        /// Outfit
        /// </summary>
        Code_11,

        /// <summary>
        /// Ration
        /// </summary>
        Code_13,

        /// <summary>
        /// Shot
        /// </summary>
        Code_14,

        /// <summary>
        /// Stick
        /// </summary>
        Code_15,

        /// <summary>
        /// Hundred Fifteen Kg Drum
        /// </summary>
        Code_16,

        /// <summary>
        /// Hundred Lb Drum
        /// </summary>
        Code_17,

        /// <summary>
        /// Fiftyfive Gallon (US) Drum
        /// </summary>
        Code_18,

        /// <summary>
        /// Tank Truck
        /// </summary>
        Code_19,

        /// <summary>
        /// Car Mile
        /// </summary>
        Code_1A,

        /// <summary>
        /// Car Count
        /// </summary>
        Code_1B,

        /// <summary>
        /// Locomotive Count
        /// </summary>
        Code_1C,

        /// <summary>
        /// Caboose Count
        /// </summary>
        Code_1D,

        /// <summary>
        /// Empty Car
        /// </summary>
        Code_1E,

        /// <summary>
        /// Train Mile
        /// </summary>
        Code_1F,

        /// <summary>
        /// Fuel Usage Gallon (US)
        /// </summary>
        Code_1G,

        /// <summary>
        /// Caboose Mile
        /// </summary>
        Code_1H,

        /// <summary>
        /// Fixed Rate
        /// </summary>
        Code_1I,

        /// <summary>
        /// Ton Mile
        /// </summary>
        Code_1J,

        /// <summary>
        /// Locomotive Mile
        /// </summary>
        Code_1K,

        /// <summary>
        /// Total Car Count
        /// </summary>
        Code_1L,

        /// <summary>
        /// Total Car Mile
        /// </summary>
        Code_1M,

        /// <summary>
        /// Count
        /// </summary>
        Code_1N,

        /// <summary>
        /// Quarter Mile
        /// </summary>
        Code_1X,

        /// <summary>
        /// Small Spray
        /// </summary>
        Code_4,

        /// <summary>
        /// Lift
        /// </summary>
        Code_5,

        /// <summary>
        /// Heat Lot
        /// </summary>
        Code_8,

        /// <summary>
        /// Twenty Foot Container
        /// </summary>
        Code_20,

        /// <summary>
        /// Forty Foot Container
        /// </summary>
        Code_21,

        /// <summary>
        /// Decilitre per Gram
        /// </summary>
        Code_22,

        /// <summary>
        /// Grams per Cubic Centimetre
        /// </summary>
        Code_23,

        /// <summary>
        /// Theoretical Pound
        /// </summary>
        Code_24,

        /// <summary>
        /// Gram per Square Centimetre
        /// </summary>
        Code_25,

        /// <summary>
        /// Actual Ton
        /// </summary>
        Code_26,

        /// <summary>
        /// Theoretical Ton
        /// </summary>
        Code_27,

        /// <summary>
        /// Kilogram per Square Metre
        /// </summary>
        Code_28,

        /// <summary>
        /// Pound per Thousand Square Feet
        /// </summary>
        Code_29,

        /// <summary>
        /// Radian per Second
        /// </summary>
        Code_2A,

        /// <summary>
        /// Radian per Second Squared
        /// </summary>
        Code_2B,

        /// <summary>
        /// Röntgen
        /// </summary>
        Code_2C,

        /// <summary>
        /// British Thermal Unit per Hour
        /// </summary>
        Code_2I,

        /// <summary>
        /// Cubic Centimetre per Second
        /// </summary>
        Code_2J,

        /// <summary>
        /// Cubic Foot per Hour
        /// </summary>
        Code_2K,

        /// <summary>
        /// Cubic Foot per Minute
        /// </summary>
        Code_2L,

        /// <summary>
        /// Centimetre per Second
        /// </summary>
        Code_2M,

        /// <summary>
        /// Decibel
        /// </summary>
        Code_2N,

        /// <summary>
        /// Kilobyte
        /// </summary>
        Code_2P,

        /// <summary>
        /// Kilo Becquerel
        /// </summary>
        Code_2Q,

        /// <summary>
        /// Kilocurie
        /// </summary>
        Code_2R,

        /// <summary>
        /// Megagram
        /// </summary>
        Code_2U,

        /// <summary>
        /// Megagram per Hour
        /// </summary>
        Code_2V,

        /// <summary>
        /// Bin
        /// </summary>
        Code_2W,

        /// <summary>
        /// Metre per Minute
        /// </summary>
        Code_2X,

        /// <summary>
        /// Milliröntgen
        /// </summary>
        Code_2Y,

        /// <summary>
        /// Millivolt
        /// </summary>
        Code_2Z,

        /// <summary>
        /// Horse Power Day per Air Dry Metric Ton
        /// </summary>
        Code_30,

        /// <summary>
        /// Catch Weight
        /// </summary>
        Code_31,

        /// <summary>
        /// Kilogram per Air Dry Metric Ton
        /// </summary>
        Code_32,

        /// <summary>
        /// Kilopascal Square Metres per Gram
        /// </summary>
        Code_33,

        /// <summary>
        /// Kilopascals per Millimetre
        /// </summary>
        Code_34,

        /// <summary>
        /// Millilitres per Square Centimetre Second
        /// </summary>
        Code_35,

        /// <summary>
        /// Cubic Feet per Minute per Square Foot
        /// </summary>
        Code_36,

        /// <summary>
        /// Ounce per Square Foot
        /// </summary>
        Code_37,

        /// <summary>
        /// Ounces per Square Foot per 0,01 Inch
        /// </summary>
        Code_38,

        /// <summary>
        /// Megajoule
        /// </summary>
        Code_3B,

        /// <summary>
        /// Manmonth
        /// </summary>
        Code_3C,

        /// <summary>
        /// Pound per Pound of Product
        /// </summary>
        Code_3E,

        /// <summary>
        /// Pound per Piece of Product
        /// </summary>
        Code_3G,

        /// <summary>
        /// Kilogram per Kilogram of Product
        /// </summary>
        Code_3H,

        /// <summary>
        /// Kilogram per Piece of Product
        /// </summary>
        Code_3I,

        /// <summary>
        /// Millilitre per Second
        /// </summary>
        Code_40,

        /// <summary>
        /// Millilitre per Minute
        /// </summary>
        Code_41,

        /// <summary>
        /// Super Bulk Bag
        /// </summary>
        Code_43,

        /// <summary>
        /// Fivehundred Kg Bulk Bag
        /// </summary>
        Code_44,

        /// <summary>
        /// Threehundred Kg Bulk Bag
        /// </summary>
        Code_45,

        /// <summary>
        /// Fifty Lb Bulk Bag
        /// </summary>
        Code_46,

        /// <summary>
        /// Fifty Lb Bag
        /// </summary>
        Code_47,

        /// <summary>
        /// Bulk Car Load
        /// </summary>
        Code_48,

        /// <summary>
        /// Bobbin
        /// </summary>
        Code_4A,

        /// <summary>
        /// Cap
        /// </summary>
        Code_4B,

        /// <summary>
        /// Centistokes
        /// </summary>
        Code_4C,

        /// <summary>
        /// Twenty Pack
        /// </summary>
        Code_4E,

        /// <summary>
        /// Microlitre
        /// </summary>
        Code_4G,

        /// <summary>
        /// Micrometre
        /// </summary>
        Code_4H,

        /// <summary>
        /// Milliampere
        /// </summary>
        Code_4K,

        /// <summary>
        /// Megabyte
        /// </summary>
        Code_4L,

        /// <summary>
        /// Milligram per Hour
        /// </summary>
        Code_4M,

        /// <summary>
        /// Megabecquerel
        /// </summary>
        Code_4N,

        /// <summary>
        /// Microfarad
        /// </summary>
        Code_4O,

        /// <summary>
        /// Newton per Metre
        /// </summary>
        Code_4P,

        /// <summary>
        /// Ounce Inch
        /// </summary>
        Code_4Q,

        /// <summary>
        /// Ounce Foot
        /// </summary>
        Code_4R,

        /// <summary>
        /// Picofarad
        /// </summary>
        Code_4T,

        /// <summary>
        /// Pound per Hour
        /// </summary>
        Code_4U,

        /// <summary>
        /// Ton (US) per Hour
        /// </summary>
        Code_4W,

        /// <summary>
        /// Kilolitre per Hour
        /// </summary>
        Code_4X,

        /// <summary>
        /// Theoretical Kilograms
        /// </summary>
        Code_53,

        /// <summary>
        /// Theoretical Tonne
        /// </summary>
        Code_54,

        /// <summary>
        /// Sitas
        /// </summary>
        Code_56,

        /// <summary>
        /// Mesh
        /// </summary>
        Code_57,

        /// <summary>
        /// Net kilogram
        /// </summary>
        Code_58,

        /// <summary>
        /// Part per Million
        /// </summary>
        Code_59,

        /// <summary>
        /// Barrel per Minute
        /// </summary>
        Code_5A,

        /// <summary>
        /// Batch
        /// </summary>
        Code_5B,

        /// <summary>
        /// Gallon (US) per Thousand
        /// </summary>
        Code_5C,

        /// <summary>
        /// Mmscf / Day
        /// </summary>
        Code_5E,

        /// <summary>
        /// Pounds per Thousand
        /// </summary>
        Code_5F,

        /// <summary>
        /// Pump
        /// </summary>
        Code_5G,

        /// <summary>
        /// Stage
        /// </summary>
        Code_5H,

        /// <summary>
        /// Standard Cubic Foot
        /// </summary>
        Code_5I,

        /// <summary>
        /// Hydraulic Horse Power
        /// </summary>
        Code_5J,

        /// <summary>
        /// Count per Minute
        /// </summary>
        Code_5K,

        /// <summary>
        /// Seismic Level
        /// </summary>
        Code_5P,

        /// <summary>
        /// Seismic Line
        /// </summary>
        Code_5Q,

        /// <summary>
        /// Percent Weight
        /// </summary>
        Code_60,

        /// <summary>
        /// Part per Billion (US)
        /// </summary>
        Code_61,

        /// <summary>
        /// Percent per 1000 Hour
        /// </summary>
        Code_62,

        /// <summary>
        /// Failure Rate in Time
        /// </summary>
        Code_63,

        /// <summary>
        /// Pound per Square Inch - Gauge
        /// </summary>
        Code_64,

        /// <summary>
        /// Oersted
        /// </summary>
        Code_66,

        /// <summary>
        /// Test Specific Scale
        /// </summary>
        Code_69,

        /// <summary>
        /// Volt Ampere per Pound
        /// </summary>
        Code_71,

        /// <summary>
        /// Watt per Pound
        /// </summary>
        Code_72,

        /// <summary>
        /// Ampere Tum per Centimetre
        /// </summary>
        Code_73,

        /// <summary>
        /// Millipascal
        /// </summary>
        Code_74,

        /// <summary>
        /// Gauss
        /// </summary>
        Code_76,

        /// <summary>
        /// Milli-Inch
        /// </summary>
        Code_77,

        /// <summary>
        /// Kilogauss
        /// </summary>
        Code_78,

        /// <summary>
        /// Pound per Square Inch - Absolute
        /// </summary>
        Code_80,

        /// <summary>
        /// Henry
        /// </summary>
        Code_81,

        /// <summary>
        /// Kilopound per Square Inch
        /// </summary>
        Code_84,

        /// <summary>
        /// Foot Pound-Force
        /// </summary>
        Code_85,

        /// <summary>
        /// Pound per Cubic Foot
        /// </summary>
        Code_87,

        /// <summary>
        /// Poise
        /// </summary>
        Code_89,

        /// <summary>
        /// Saybold Universal Second
        /// </summary>
        Code_90,

        /// <summary>
        /// Stokes
        /// </summary>
        Code_91,

        /// <summary>
        /// Calorie - Calorie per Cubic Centimetre
        /// </summary>
        Code_92,

        /// <summary>
        /// Calorie per Gram
        /// </summary>
        Code_93,

        /// <summary>
        /// Curl Unit
        /// </summary>
        Code_94,

        /// <summary>
        /// Twenty Thousand Gallon (US) Tankcar
        /// </summary>
        Code_95,

        /// <summary>
        /// Ten Thousand Gallon (US) Tankcar
        /// </summary>
        Code_96,

        /// <summary>
        /// Ten Kg Drum
        /// </summary>
        Code_97,

        /// <summary>
        /// Fifteen Kg Drum
        /// </summary>
        Code_98,

        /// <summary>
        /// 15 C Calorie
        /// </summary>
        A1,

        /// <summary>
        /// Ampere Square Metre per Joule Second
        /// </summary>
        A10,

        /// <summary>
        /// Angstrom
        /// </summary>
        A11,

        /// <summary>
        /// Astronomical Unit
        /// </summary>
        A12,

        /// <summary>
        /// Attojoule
        /// </summary>
        A13,

        /// <summary>
        /// Barn
        /// </summary>
        A14,

        /// <summary>
        /// Barn per Electron Volt
        /// </summary>
        A15,

        /// <summary>
        /// Barn per Steradian Electron Volt,
        /// </summary>
        A16,

        /// <summary>
        /// Barn per Sterdian
        /// </summary>
        A17,

        /// <summary>
        /// Becquerel per Kilogram
        /// </summary>
        A18,

        /// <summary>
        /// Becquerel per Metre Cubed
        /// </summary>
        A19,

        /// <summary>
        /// Ampere per Centimetre
        /// </summary>
        A2,

        /// <summary>
        /// British Thermal Unit per Second Square Foot Degree Rankin
        /// </summary>
        A20,

        /// <summary>
        /// British Thermal Unit per Pound Degree Rankin
        /// </summary>
        A21,

        /// <summary>
        /// British Thermal Unit per Second Foot Degree Rankin
        /// </summary>
        A22,

        /// <summary>
        /// British Thermal Unit per Hour Square Foot Degree Rankin
        /// </summary>
        A23,

        /// <summary>
        /// Candela per Square Metre
        /// </summary>
        A24,

        /// <summary>
        /// Cheval Vapeur
        /// </summary>
        A25,

        /// <summary>
        /// Coulomb Metre
        /// </summary>
        A26,

        /// <summary>
        /// Coulomb Metre Squared per Volt
        /// </summary>
        A27,

        /// <summary>
        /// Coulomb per Cubic Centimetre
        /// </summary>
        A28,

        /// <summary>
        /// Coulomb per Cubic Metre
        /// </summary>
        A29,

        /// <summary>
        /// Ampere per Millimetre
        /// </summary>
        A3,

        /// <summary>
        /// Coulomb per Cubic Millimetre
        /// </summary>
        A30,

        /// <summary>
        /// Coulomb per Kilogram Second
        /// </summary>
        A31,

        /// <summary>
        /// Coulomb per Mole
        /// </summary>
        A32,

        /// <summary>
        /// Coulomb per Square Centimetre
        /// </summary>
        A33,

        /// <summary>
        /// Coulomb per Square Metre
        /// </summary>
        A34,

        /// <summary>
        /// Coulomb per Square Millimetre
        /// </summary>
        A35,

        /// <summary>
        /// Cubic Centimetre per Mole
        /// </summary>
        A36,

        /// <summary>
        /// Cubic Decimetre per Mole
        /// </summary>
        A37,

        /// <summary>
        /// Cubic Metre per Coulomb
        /// </summary>
        A38,

        /// <summary>
        /// Cubic Metre per Kilogram
        /// </summary>
        A39,

        /// <summary>
        /// Ampere per Square Centimetre
        /// </summary>
        A4,

        /// <summary>
        /// Cubic Metre per Mole
        /// </summary>
        A40,

        /// <summary>
        /// Ampere per Square Metre
        /// </summary>
        A41,

        /// <summary>
        /// Curie per Kilogram
        /// </summary>
        A42,

        /// <summary>
        /// Deadweight Tonnage
        /// </summary>
        A43,

        /// <summary>
        /// Decalitre
        /// </summary>
        A44,

        /// <summary>
        /// Decametre
        /// </summary>
        A45,

        /// <summary>
        /// Decitex
        /// </summary>
        A47,

        /// <summary>
        /// Degree Rankin
        /// </summary>
        A48,

        /// <summary>
        /// Denier
        /// </summary>
        A49,

        /// <summary>
        /// Ampere Square Metre
        /// </summary>
        A5,

        /// <summary>
        /// Dyn Second per Cubic Centimetre
        /// </summary>
        A50,

        /// <summary>
        /// Dyne Second per Centimetre
        /// </summary>
        A51,

        /// <summary>
        /// Dyne Second per Centimetre to the Fifth
        /// </summary>
        A52,

        /// <summary>
        /// Electronvolt
        /// </summary>
        A53,

        /// <summary>
        /// Electronvolt per Metre
        /// </summary>
        A54,

        /// <summary>
        /// Electronvolt Square Metre
        /// </summary>
        A55,

        /// <summary>
        /// Electronvolt Square Metre per Kilogram
        /// </summary>
        A56,

        /// <summary>
        /// Erg
        /// </summary>
        A57,

        /// <summary>
        /// Erg per Centimetre
        /// </summary>
        A58,

        /// <summary>
        /// Ampere per Square Metre Kelvin Squared
        /// </summary>
        A6,

        /// <summary>
        /// Erg per Cubic Centimetre
        /// </summary>
        A60,

        /// <summary>
        /// Erg per Gram
        /// </summary>
        A61,

        /// <summary>
        /// Erg per Gram Second
        /// </summary>
        A62,

        /// <summary>
        /// Erg per Second
        /// </summary>
        A63,

        /// <summary>
        /// Erg per Second Square Centimetre
        /// </summary>
        A64,

        /// <summary>
        /// Erg per Square Centimetre Second
        /// </summary>
        A65,

        /// <summary>
        /// Erg Square Centimetre
        /// </summary>
        A66,

        /// <summary>
        /// Erg Square Centimetre per Gram
        /// </summary>
        A67,

        /// <summary>
        /// Exajoule
        /// </summary>
        A68,

        /// <summary>
        /// Farad per Metre
        /// </summary>
        A69,

        /// <summary>
        /// Ampere per Square Millimetre
        /// </summary>
        A7,

        /// <summary>
        /// Femtojoule
        /// </summary>
        A70,

        /// <summary>
        /// Femtometre
        /// </summary>
        A71,

        /// <summary>
        /// Foot per Second Squared
        /// </summary>
        A73,

        /// <summary>
        /// Foot Pound-Force per Second
        /// </summary>
        A74,

        /// <summary>
        /// Freight Ton
        /// </summary>
        A75,

        /// <summary>
        /// Gal
        /// </summary>
        A76,

        /// <summary>
        /// Gaussian Cgs Unit of Displacement
        /// </summary>
        A77,

        /// <summary>
        /// Gaussian Cgs Unit of Electic Current
        /// </summary>
        A78,

        /// <summary>
        /// Gaussian Cgs Unit of Electric Charge
        /// </summary>
        A79,

        /// <summary>
        /// Ampere Second
        /// </summary>
        A8,

        /// <summary>
        /// Gaussian Cgs Unit of Electric Field Strength
        /// </summary>
        A80,

        /// <summary>
        /// Gaussian Cgs Unit of Electric Polarization
        /// </summary>
        A81,

        /// <summary>
        /// Gaussian Cgs Unit of Electric Potential
        /// </summary>
        A82,

        /// <summary>
        /// Gaussian Cgs Unit of Magnetization
        /// </summary>
        A83,

        /// <summary>
        /// Gigacoulomb per Cubic Metre
        /// </summary>
        A84,

        /// <summary>
        /// Gigaelectronvolt
        /// </summary>
        A85,

        /// <summary>
        /// Gigahertz
        /// </summary>
        A86,

        /// <summary>
        /// Gigaohm
        /// </summary>
        A87,

        /// <summary>
        /// Gigaohm Metre
        /// </summary>
        A88,

        /// <summary>
        /// Gigapascal
        /// </summary>
        A89,

        /// <summary>
        /// Rate
        /// </summary>
        A9,

        /// <summary>
        /// Gigawatt
        /// </summary>
        A90,

        /// <summary>
        /// Gon
        /// </summary>
        A91,

        /// <summary>
        /// Gram per Cubic Metre
        /// </summary>
        A93,

        /// <summary>
        /// Gram per Mole
        /// </summary>
        A94,

        /// <summary>
        /// Gray
        /// </summary>
        A95,

        /// <summary>
        /// Gray per Second
        /// </summary>
        A96,

        /// <summary>
        /// Hectopascal
        /// </summary>
        A97,

        /// <summary>
        /// Henry per Metre
        /// </summary>
        A98,

        /// <summary>
        /// Ball
        /// </summary>
        AA,

        /// <summary>
        /// Bulk Pack
        /// </summary>
        AB,

        /// <summary>
        /// Acre
        /// </summary>
        ACR,

        /// <summary>
        /// Byte
        /// </summary>
        AD,

        /// <summary>
        /// Ampere per Metre
        /// </summary>
        AE,

        /// <summary>
        /// Additional Minute
        /// </summary>
        AH,

        /// <summary>
        /// Average Minute per Call
        /// </summary>
        AI,

        /// <summary>
        /// Cop
        /// </summary>
        AJ,

        /// <summary>
        /// Fathom
        /// </summary>
        AK,

        /// <summary>
        /// Access Line
        /// </summary>
        AL,

        /// <summary>
        /// Ampoule
        /// </summary>
        AM,

        /// <summary>
        /// Ampere Hour
        /// </summary>
        AMH,

        /// <summary>
        /// Ampere
        /// </summary>
        AMP,

        /// <summary>
        /// Year
        /// </summary>
        ANN,

        /// <summary>
        /// Aluminium Pound Only
        /// </summary>
        AP,

        /// <summary>
        /// Troy ounce or apothecary ounce
        /// </summary>
        APZ,

        /// <summary>
        /// Anti-Hemophilic Factor (Ahf) Unit
        /// </summary>
        AQ,

        /// <summary>
        /// Suppository
        /// </summary>
        AR,

        /// <summary>
        /// Are
        /// </summary>
        ARE,

        /// <summary>
        /// Assortment
        /// </summary>
        AS,

        /// <summary>
        /// Alcoholic Strength By Mass
        /// </summary>
        ASM,

        /// <summary>
        /// Alcoholic Strength By Volume
        /// </summary>
        ASU,

        /// <summary>
        /// Standard Atmosphere
        /// </summary>
        ATM,

        /// <summary>
        /// Technical Atmosphere
        /// </summary>
        ATT,

        /// <summary>
        /// Capsule
        /// </summary>
        AV,

        /// <summary>
        /// Powder Filled Vial
        /// </summary>
        AW,

        /// <summary>
        /// Gauge
        /// </summary>
        AWG,

        /// <summary>
        /// Anti XA Unit
        /// </summary>
        AXU,

        /// <summary>
        /// Assembly
        /// </summary>
        AY,

        /// <summary>
        /// British Thermal Unit per Pound
        /// </summary>
        AZ,

        /// <summary>
        /// Btu per Cubic Foot
        /// </summary>
        B0,

        /// <summary>
        /// Barrel (US) per Day
        /// </summary>
        B1,

        /// <summary>
        /// Bit per Second
        /// </summary>
        B10,

        /// <summary>
        /// Joule per Kilogram Kelvin
        /// </summary>
        B11,

        /// <summary>
        /// Joule per Metre
        /// </summary>
        B12,

        /// <summary>
        /// Joule per Square Metre
        /// </summary>
        B13,

        /// <summary>
        /// Joule per Metre to the Fourth Power
        /// </summary>
        B14,

        /// <summary>
        /// Joule per Mole
        /// </summary>
        B15,

        /// <summary>
        /// Joule per Mole Kelvin
        /// </summary>
        B16,

        /// <summary>
        /// Joule Second
        /// </summary>
        B18,

        /// <summary>
        /// Bunk
        /// </summary>
        B2,

        /// <summary>
        /// Joule Square Metre per Kilogram
        /// </summary>
        B20,

        /// <summary>
        /// Kelvin per Watt
        /// </summary>
        B21,

        /// <summary>
        /// Kiloampere
        /// </summary>
        B22,

        /// <summary>
        /// Kiloampere per Square Metre
        /// </summary>
        B23,

        /// <summary>
        /// Kiloampere per Metre
        /// </summary>
        B24,

        /// <summary>
        /// Kilobecquerel per Kilogram
        /// </summary>
        B25,

        /// <summary>
        /// Kilocoulomb
        /// </summary>
        B26,

        /// <summary>
        /// Kilocoulomb per Cubic Metre
        /// </summary>
        B27,

        /// <summary>
        /// Kilocoulomb per Square Metre
        /// </summary>
        B28,

        /// <summary>
        /// Kiloelectronvolt
        /// </summary>
        B29,

        /// <summary>
        /// Batting Pound
        /// </summary>
        B3,

        /// <summary>
        /// Kilogram Metre per Second
        /// </summary>
        B31,

        /// <summary>
        /// Kilogram Metre Squared
        /// </summary>
        B32,

        /// <summary>
        /// Kilogram Metre Squared per Second
        /// </summary>
        B33,

        /// <summary>
        /// Kilogram per Cubic Decimetre
        /// </summary>
        B34,

        /// <summary>
        /// Kilogram per Litre
        /// </summary>
        B35,

        /// <summary>
        /// Thermochemical Calorie per Gram
        /// </summary>
        B36,

        /// <summary>
        /// Kilogram-Force
        /// </summary>
        B37,

        /// <summary>
        /// Kilogram-Force Metre
        /// </summary>
        B38,

        /// <summary>
        /// Kilogram-Force Metre per Second
        /// </summary>
        B39,

        /// <summary>
        /// Barrel, Imperial
        /// </summary>
        B4,

        /// <summary>
        /// Kilogram-Force per Square Metre
        /// </summary>
        B40,

        /// <summary>
        /// Kilojoule per Kelvin
        /// </summary>
        B41,

        /// <summary>
        /// Kilojoule per Kilogram
        /// </summary>
        B42,

        /// <summary>
        /// Kilojoule per Kilogram Kelvin
        /// </summary>
        B43,

        /// <summary>
        /// Kilojoule per Mole
        /// </summary>
        B44,

        /// <summary>
        /// Kilomole
        /// </summary>
        B45,

        /// <summary>
        /// Kilomole per Cubic Metre
        /// </summary>
        B46,

        /// <summary>
        /// Kilonewton
        /// </summary>
        B47,

        /// <summary>
        /// Kilonewton Metre
        /// </summary>
        B48,

        /// <summary>
        /// Kiloohm
        /// </summary>
        B49,

        /// <summary>
        /// Billet
        /// </summary>
        B5,

        /// <summary>
        /// Kiloohm Metre
        /// </summary>
        B50,

        /// <summary>
        /// Kilopond
        /// </summary>
        B51,

        /// <summary>
        /// Kilosecond
        /// </summary>
        B52,

        /// <summary>
        /// Kilosiemens
        /// </summary>
        B53,

        /// <summary>
        /// Kilosiemens per Metre
        /// </summary>
        B54,

        /// <summary>
        /// Kilovolt per Metre
        /// </summary>
        B55,

        /// <summary>
        /// Kiloweber per Metre
        /// </summary>
        B56,

        /// <summary>
        /// Light Year
        /// </summary>
        B57,

        /// <summary>
        /// Litre per Mole
        /// </summary>
        B58,

        /// <summary>
        /// Lumen Hour
        /// </summary>
        B59,

        /// <summary>
        /// Bun
        /// </summary>
        B6,

        /// <summary>
        /// Lumens per Square Meter
        /// </summary>
        B60,

        /// <summary>
        /// Lumen per Watt
        /// </summary>
        B61,

        /// <summary>
        /// Lumen Second
        /// </summary>
        B62,

        /// <summary>
        /// Lux Hour
        /// </summary>
        B63,

        /// <summary>
        /// Lux Second
        /// </summary>
        B64,

        /// <summary>
        /// Maxwell
        /// </summary>
        B65,

        /// <summary>
        /// Megaampere per Square Metre
        /// </summary>
        B66,

        /// <summary>
        /// Megabecquerel per Kilogram
        /// </summary>
        B67,

        /// <summary>
        /// Megacoulomb per Cubic Metre
        /// </summary>
        B69,

        /// <summary>
        /// Cycle
        /// </summary>
        B7,

        /// <summary>
        /// Megacoulomb per Square Metre
        /// </summary>
        B70,

        /// <summary>
        /// Megaelectronvolt
        /// </summary>
        B71,

        /// <summary>
        /// Megagram per Cubic Metre
        /// </summary>
        B72,

        /// <summary>
        /// Meganewton
        /// </summary>
        B73,

        /// <summary>
        /// Meganewton Metre
        /// </summary>
        B74,

        /// <summary>
        /// Megaohm
        /// </summary>
        B75,

        /// <summary>
        /// Megaohm Metre
        /// </summary>
        B76,

        /// <summary>
        /// Megasiemens per Metre
        /// </summary>
        B77,

        /// <summary>
        /// Megavolt
        /// </summary>
        B78,

        /// <summary>
        /// Megavolt per Metre
        /// </summary>
        B79,

        /// <summary>
        /// Joule per Cubic Metre
        /// </summary>
        B8,

        /// <summary>
        /// Reciprocal Metre Squared Reciprocal Second
        /// </summary>
        B81,

        /// <summary>
        /// Metre to the Fourth Power
        /// </summary>
        B83,

        /// <summary>
        /// Microampere
        /// </summary>
        B84,

        /// <summary>
        /// Microbar
        /// </summary>
        B85,

        /// <summary>
        /// Microcoulomb
        /// </summary>
        B86,

        /// <summary>
        /// Microcoulomb per Cubic Metre
        /// </summary>
        B87,

        /// <summary>
        /// Microcoulomb per Square Metre
        /// </summary>
        B88,

        /// <summary>
        /// Microfarad per Metre
        /// </summary>
        B89,

        /// <summary>
        /// Batt
        /// </summary>
        B9,

        /// <summary>
        /// Microhenry
        /// </summary>
        B90,

        /// <summary>
        /// Microhenry per Metre
        /// </summary>
        B91,

        /// <summary>
        /// Micronewton
        /// </summary>
        B92,

        /// <summary>
        /// Micronewton Metre
        /// </summary>
        B93,

        /// <summary>
        /// Microohm
        /// </summary>
        B94,

        /// <summary>
        /// Microohm Metre
        /// </summary>
        B95,

        /// <summary>
        /// Micropascal
        /// </summary>
        B96,

        /// <summary>
        /// Microradian
        /// </summary>
        B97,

        /// <summary>
        /// Microsecond
        /// </summary>
        B98,

        /// <summary>
        /// Microsiemens
        /// </summary>
        B99,

        /// <summary>
        /// Bar (unit of pressure)
        /// </summary>
        BAR,

        /// <summary>
        /// Base box
        /// </summary>
        BB,

        /// <summary>
        /// Board
        /// </summary>
        BD,

        /// <summary>
        /// Bundle
        /// </summary>
        BE,

        /// <summary>
        /// Board Foot
        /// </summary>
        BFT,

        /// <summary>
        /// Bag
        /// </summary>
        BG,

        /// <summary>
        /// Brush
        /// </summary>
        BH,

        /// <summary>
        /// Brake Horse Power
        /// </summary>
        BHP,

        /// <summary>
        /// Billion (Trillion in US)
        /// </summary>
        BIL,

        /// <summary>
        /// Bucket
        /// </summary>
        BJ,

        /// <summary>
        /// Basket
        /// </summary>
        BK,

        /// <summary>
        /// Bale
        /// </summary>
        BL,

        /// <summary>
        /// Dry Barrel (US)
        /// </summary>
        BLD,

        /// <summary>
        /// Barrel US
        /// </summary>
        BLL,

        /// <summary>
        /// Bottle
        /// </summary>
        BO,

        /// <summary>
        /// Hundred board foot
        /// </summary>
        BP,

        /// <summary>
        /// Beats per Minute
        /// </summary>
        BPM,

        /// <summary>
        /// Becquerel
        /// </summary>
        BQL,

        /// <summary>
        /// Bar
        /// </summary>
        BR,

        /// <summary>
        /// Bolt
        /// </summary>
        BT,

        /// <summary>
        /// British thermal unit
        /// </summary>
        BTU,

        /// <summary>
        /// Bushel (US)
        /// </summary>
        BUA,

        /// <summary>
        /// Bushel (UK)
        /// </summary>
        BUI,

        /// <summary>
        /// Base Weight
        /// </summary>
        BW,

        /// <summary>
        /// Box
        /// </summary>
        BX,

        /// <summary>
        /// Million Btus
        /// </summary>
        BZ,

        /// <summary>
        /// Call
        /// </summary>
        C0,

        /// <summary>
        /// Composite Product Pound (Total Weight)
        /// </summary>
        C1,

        /// <summary>
        /// Millifarad
        /// </summary>
        C10,

        /// <summary>
        /// Milligal
        /// </summary>
        C11,

        /// <summary>
        /// Milligram per Metre
        /// </summary>
        C12,

        /// <summary>
        /// Milligray
        /// </summary>
        C13,

        /// <summary>
        /// Millihenry
        /// </summary>
        C14,

        /// <summary>
        /// Millijoule
        /// </summary>
        C15,

        /// <summary>
        /// Millimetre per Second
        /// </summary>
        C16,

        /// <summary>
        /// Millimetre Squared per Second
        /// </summary>
        C17,

        /// <summary>
        /// Millimole
        /// </summary>
        C18,

        /// <summary>
        /// Mole per Kilogram
        /// </summary>
        C19,

        /// <summary>
        /// Carset
        /// </summary>
        C2,

        /// <summary>
        /// Millinewton
        /// </summary>
        C20,

        /// <summary>
        /// Millinewton per Metre
        /// </summary>
        C22,

        /// <summary>
        /// Milliohm Metre
        /// </summary>
        C23,

        /// <summary>
        /// Millipascal Second
        /// </summary>
        C24,

        /// <summary>
        /// Milliradian
        /// </summary>
        C25,

        /// <summary>
        /// Millisecond
        /// </summary>
        C26,

        /// <summary>
        /// Millisiemens
        /// </summary>
        C27,

        /// <summary>
        /// Millisievert
        /// </summary>
        C28,

        /// <summary>
        /// Millitesla
        /// </summary>
        C29,

        /// <summary>
        /// Microvolt per Metre
        /// </summary>
        C3,

        /// <summary>
        /// Millivolt per Metre
        /// </summary>
        C30,

        /// <summary>
        /// Milliwatt
        /// </summary>
        C31,

        /// <summary>
        /// Milliwatt per Square Metre
        /// </summary>
        C32,

        /// <summary>
        /// Milliweber
        /// </summary>
        C33,

        /// <summary>
        /// Mole
        /// </summary>
        C34,

        /// <summary>
        /// Mole per Cubic Decimetre
        /// </summary>
        C35,

        /// <summary>
        /// Mole per Cubic Metre
        /// </summary>
        C36,

        /// <summary>
        /// Mole per Litre
        /// </summary>
        C38,

        /// <summary>
        /// Nanoampere
        /// </summary>
        C39,

        /// <summary>
        /// Carload
        /// </summary>
        C4,

        /// <summary>
        /// Nanocoulomb
        /// </summary>
        C40,

        /// <summary>
        /// Nanofarad
        /// </summary>
        C41,

        /// <summary>
        /// Nanofarad per Metre
        /// </summary>
        C42,

        /// <summary>
        /// Nanohenry
        /// </summary>
        C43,

        /// <summary>
        /// Nanohenry per Metre
        /// </summary>
        C44,

        /// <summary>
        /// Nanometre
        /// </summary>
        C45,

        /// <summary>
        /// Nanoohm Metre
        /// </summary>
        C46,

        /// <summary>
        /// Nanosecond
        /// </summary>
        C47,

        /// <summary>
        /// Nanotesla
        /// </summary>
        C48,

        /// <summary>
        /// Nanowatt
        /// </summary>
        C49,

        /// <summary>
        /// Cost
        /// </summary>
        C5,

        /// <summary>
        /// Neper
        /// </summary>
        C50,

        /// <summary>
        /// Neper per Second
        /// </summary>
        C51,

        /// <summary>
        /// Picometre
        /// </summary>
        C52,

        /// <summary>
        /// Newton Metre Second
        /// </summary>
        C53,

        /// <summary>
        /// Newton Metre Squared Kilogram Squared
        /// </summary>
        C54,

        /// <summary>
        /// Newton per Square Metre
        /// </summary>
        C55,

        /// <summary>
        /// Newton per Square Millimetre
        /// </summary>
        C56,

        /// <summary>
        /// Newton Second
        /// </summary>
        C57,

        /// <summary>
        /// Newton Second per Metre
        /// </summary>
        C58,

        /// <summary>
        /// Octave
        /// </summary>
        C59,

        /// <summary>
        /// Cell
        /// </summary>
        C6,

        /// <summary>
        /// Ohm Centimetre
        /// </summary>
        C60,

        /// <summary>
        /// Ohm Metre
        /// </summary>
        C61,

        /// <summary>
        /// One
        /// </summary>
        C62,

        /// <summary>
        /// Parsec
        /// </summary>
        C63,

        /// <summary>
        /// Pascal per Kelvin
        /// </summary>
        C64,

        /// <summary>
        /// Pascal Second
        /// </summary>
        C65,

        /// <summary>
        /// Pascal Second per Cubic Metre
        /// </summary>
        C66,

        /// <summary>
        /// Pascal Second per Metre
        /// </summary>
        C67,

        /// <summary>
        /// Petajoule
        /// </summary>
        C68,

        /// <summary>
        /// Phon
        /// </summary>
        C69,

        /// <summary>
        /// Centipoise
        /// </summary>
        C7,

        /// <summary>
        /// Picoampere
        /// </summary>
        C70,

        /// <summary>
        /// Picocoulomb
        /// </summary>
        C71,

        /// <summary>
        /// Picofarad per Metre
        /// </summary>
        C72,

        /// <summary>
        /// Picohenry
        /// </summary>
        C73,

        /// <summary>
        /// Picowatt
        /// </summary>
        C75,

        /// <summary>
        /// Picowatt per Square Metre
        /// </summary>
        C76,

        /// <summary>
        /// Pound Gage
        /// </summary>
        C77,

        /// <summary>
        /// Pound-Force
        /// </summary>
        C78,

        /// <summary>
        /// Millicoulomb per Kilogram
        /// </summary>
        C8,

        /// <summary>
        /// Rad
        /// </summary>
        C80,

        /// <summary>
        /// Radian
        /// </summary>
        C81,

        /// <summary>
        /// Radian Meter Squared per Mole
        /// </summary>
        C82,

        /// <summary>
        /// Radian Metre Squared per Kilogram
        /// </summary>
        C83,

        /// <summary>
        /// Radian per Metre
        /// </summary>
        C84,

        /// <summary>
        /// Reciprocal â Ngstr"M
        /// </summary>
        C85,

        /// <summary>
        /// Reciprocal Cubic Metre
        /// </summary>
        C86,

        /// <summary>
        /// Reciprocal Cubic Metre per Second
        /// </summary>
        C87,

        /// <summary>
        /// Reciprocal Electron Volt per Cubic Metre
        /// </summary>
        C88,

        /// <summary>
        /// Reciprocal Henry
        /// </summary>
        C89,

        /// <summary>
        /// Coil Group
        /// </summary>
        C9,

        /// <summary>
        /// Reciprocal Joule per Cubic Metre
        /// </summary>
        C90,

        /// <summary>
        /// Reciprocal Kelvin or Kelvin to the Power Minus One
        /// </summary>
        C91,

        /// <summary>
        /// Reciprocal Metre
        /// </summary>
        C92,

        /// <summary>
        /// Reciprocal Square Metre
        /// </summary>
        C93,

        /// <summary>
        /// Reciprocal Minute
        /// </summary>
        C94,

        /// <summary>
        /// Reciprocal Mole
        /// </summary>
        C95,

        /// <summary>
        /// Reciprocal Pascal or Pascal to the Power Minus One
        /// </summary>
        C96,

        /// <summary>
        /// Reciprocal Second
        /// </summary>
        C97,

        /// <summary>
        /// Reciprocal Second per Cubic Metre
        /// </summary>
        C98,

        /// <summary>
        /// Reciprocal Second per Metre Squared
        /// </summary>
        C99,

        /// <summary>
        /// Can
        /// </summary>
        CA,

        /// <summary>
        /// Carrying Capacity in Metric Ton
        /// </summary>
        CCT,

        /// <summary>
        /// Candela
        /// </summary>
        CDL,

        /// <summary>
        /// Degree Celsius
        /// </summary>
        CEL,

        /// <summary>
        /// Hundred
        /// </summary>
        CEN,

        /// <summary>
        /// Colony Forming Units
        /// </summary>
        CFU,

        /// <summary>
        /// Card
        /// </summary>
        CG,

        /// <summary>
        /// Centigram
        /// </summary>
        CGM,

        /// <summary>
        /// Container
        /// </summary>
        CH,

        /// <summary>
        /// Cone
        /// </summary>
        CJ,

        /// <summary>
        /// Connector
        /// </summary>
        CK,

        /// <summary>
        /// Coulomb per Kilogram
        /// </summary>
        CKG,

        /// <summary>
        /// Coil
        /// </summary>
        CL,

        /// <summary>
        /// Hundred Leave
        /// </summary>
        CLF,

        /// <summary>
        /// Centilitre
        /// </summary>
        CLT,

        /// <summary>
        /// Square centimetre
        /// </summary>
        CMK,

        /// <summary>
        /// Cubic centimetre
        /// </summary>
        CMQ,

        /// <summary>
        /// Centimetre
        /// </summary>
        CMT,

        /// <summary>
        /// Hundred Pack
        /// </summary>
        CNP,

        /// <summary>
        /// Cental (UK)
        /// </summary>
        CNT,

        /// <summary>
        /// Carboy
        /// </summary>
        CO,

        /// <summary>
        /// Coulomb
        /// </summary>
        COU,

        /// <summary>
        /// Cartridge
        /// </summary>
        CQ,

        /// <summary>
        /// Crate
        /// </summary>
        CR,

        /// <summary>
        /// Case
        /// </summary>
        CS,

        /// <summary>
        /// Carton
        /// </summary>
        CT,

        /// <summary>
        /// Metric Carat
        /// </summary>
        CTM,

        /// <summary>
        /// Cup
        /// </summary>
        CU,

        /// <summary>
        /// Curie
        /// </summary>
        CUR,

        /// <summary>
        /// Cover
        /// </summary>
        CV,

        /// <summary>
        /// Hundred pound (cwt) / hundred weight (US)
        /// </summary>
        CWA,

        /// <summary>
        /// Hundred weight (UK)
        /// </summary>
        CWI,

        /// <summary>
        /// Cylinder
        /// </summary>
        CY,

        /// <summary>
        /// Combo
        /// </summary>
        CZ,

        /// <summary>
        /// Reciprocal Second per Steradian
        /// </summary>
        D1,

        /// <summary>
        /// Siemens per Metre
        /// </summary>
        D10,

        /// <summary>
        /// Siemens Square Metre per Mole
        /// </summary>
        D12,

        /// <summary>
        /// Sievert
        /// </summary>
        D13,

        /// <summary>
        /// Thousand Linear Yard
        /// </summary>
        D14,

        /// <summary>
        /// Sone
        /// </summary>
        D15,

        /// <summary>
        /// Square Centimetre per Erg
        /// </summary>
        D16,

        /// <summary>
        /// Square Centimetre per Steradian Erg
        /// </summary>
        D17,

        /// <summary>
        /// Metre Kelvin
        /// </summary>
        D18,

        /// <summary>
        /// Square Metre Kelvin per Watt
        /// </summary>
        D19,

        /// <summary>
        /// Reciprocal Second per Steradian Metre Squared
        /// </summary>
        D2,

        /// <summary>
        /// Square Metre per Joule
        /// </summary>
        D20,

        /// <summary>
        /// Square Metre per Kilogram
        /// </summary>
        D21,

        /// <summary>
        /// Square Metre per Mole
        /// </summary>
        D22,

        /// <summary>
        /// Pen Gram (Protein)
        /// </summary>
        D23,

        /// <summary>
        /// Square Metre per Steradian
        /// </summary>
        D24,

        /// <summary>
        /// Square Metre per Steradian Joule
        /// </summary>
        D25,

        /// <summary>
        /// Square Metre per Volt Second
        /// </summary>
        D26,

        /// <summary>
        /// Steradian
        /// </summary>
        D27,

        /// <summary>
        /// Syphon
        /// </summary>
        D28,

        /// <summary>
        /// Terahertz
        /// </summary>
        D29,

        /// <summary>
        /// Terajoule
        /// </summary>
        D30,

        /// <summary>
        /// Terawatt
        /// </summary>
        D31,

        /// <summary>
        /// Terawatt hour
        /// </summary>
        D32,

        /// <summary>
        /// Tesla
        /// </summary>
        D33,

        /// <summary>
        /// Tex
        /// </summary>
        D34,

        /// <summary>
        /// Thermochemical Calorie
        /// </summary>
        D35,

        /// <summary>
        /// Thermochemical Calorie per Gram Kelvin
        /// </summary>
        D37,

        /// <summary>
        /// Thermochemical Calorie per Second Centimetre Kelvin
        /// </summary>
        D38,

        /// <summary>
        /// Thermochemical Calorie per Second Square Centimetre Kelvin
        /// </summary>
        D39,

        /// <summary>
        /// Thousand Litre
        /// </summary>
        D40,

        /// <summary>
        /// Tonne per Cubic Metre
        /// </summary>
        D41,

        /// <summary>
        /// Tropical Year
        /// </summary>
        D42,

        /// <summary>
        /// Atomic Mass Units (AMU)
        /// </summary>
        D43,

        /// <summary>
        /// Var
        /// </summary>
        D44,

        /// <summary>
        /// Volt Squared per Kelvin Squared
        /// </summary>
        D45,

        /// <summary>
        /// Volt - Ampere
        /// </summary>
        D46,

        /// <summary>
        /// Volt per Centimetre
        /// </summary>
        D47,

        /// <summary>
        /// Volt per Kelvin
        /// </summary>
        D48,

        /// <summary>
        /// Millivolt per Kelvin
        /// </summary>
        D49,

        /// <summary>
        /// Kilogram per Square Centimetre
        /// </summary>
        D5,

        /// <summary>
        /// Volt per Metre
        /// </summary>
        D50,

        /// <summary>
        /// Volt per Millimetre
        /// </summary>
        D51,

        /// <summary>
        /// Watt per Kelvin
        /// </summary>
        D52,

        /// <summary>
        /// Watt per Metre Kelvin
        /// </summary>
        D53,

        /// <summary>
        /// Watt per Square Metre
        /// </summary>
        D54,

        /// <summary>
        /// Heat Transfer Coefficient
        /// </summary>
        D55,

        /// <summary>
        /// Watt per Square Metre Kelvin to the Fourth Power
        /// </summary>
        D56,

        /// <summary>
        /// Watt per Steradian
        /// </summary>
        D57,

        /// <summary>
        /// Watt per Steradian Square Metre
        /// </summary>
        D58,

        /// <summary>
        /// Weber per Metre
        /// </summary>
        D59,

        /// <summary>
        /// Röntgen per Second
        /// </summary>
        D6,

        /// <summary>
        /// Weber per Millimetre
        /// </summary>
        D60,

        /// <summary>
        /// Minute
        /// </summary>
        D61,

        /// <summary>
        /// Second
        /// </summary>
        D62,

        /// <summary>
        /// Book
        /// </summary>
        D63,

        /// <summary>
        /// Block
        /// </summary>
        D64,

        /// <summary>
        /// Round
        /// </summary>
        D65,

        /// <summary>
        /// Cassette
        /// </summary>
        D66,

        /// <summary>
        /// Dollar per Hour
        /// </summary>
        D67,

        /// <summary>
        /// Inch to the Fourth Power
        /// </summary>
        D69,

        /// <summary>
        /// Sandwich
        /// </summary>
        D7,

        /// <summary>
        /// Calorie
        /// </summary>
        D70,

        /// <summary>
        /// International Table (It) Calorie per Second Centimetre Kelvin
        /// </summary>
        D71,

        /// <summary>
        /// International Table (It) Calorie per Second Square Centimetre Kelvin
        /// </summary>
        D72,

        /// <summary>
        /// Joule Square Metre
        /// </summary>
        D73,

        /// <summary>
        /// Kilogram per Mole
        /// </summary>
        D74,

        /// <summary>
        /// International Table (It) Calorie per Gram
        /// </summary>
        D75,

        /// <summary>
        /// International Table (It) Calorie per Gram Kelvin
        /// </summary>
        D76,

        /// <summary>
        /// Megacoulomb
        /// </summary>
        D77,

        /// <summary>
        /// Beam
        /// </summary>
        D79,

        /// <summary>
        /// Draize Score
        /// </summary>
        D8,

        /// <summary>
        /// Microwatt
        /// </summary>
        D80,

        /// <summary>
        /// Microtesla
        /// </summary>
        D81,

        /// <summary>
        /// Microvolt
        /// </summary>
        D82,

        /// <summary>
        /// Millinewton Metre
        /// </summary>
        D83,

        /// <summary>
        /// Microwatt per Square Metre
        /// </summary>
        D85,

        /// <summary>
        /// Millicoulomb
        /// </summary>
        D86,

        /// <summary>
        /// Millimole per Kilogram
        /// </summary>
        D87,

        /// <summary>
        /// Millicoulomb per Cubic Metre
        /// </summary>
        D88,

        /// <summary>
        /// Millicoulomb per Square Metre
        /// </summary>
        D89,

        /// <summary>
        /// Dyne per Square Centimeter
        /// </summary>
        D9,

        /// <summary>
        /// Cubic Metre (Net)
        /// </summary>
        D90,

        /// <summary>
        /// Rem
        /// </summary>
        D91,

        /// <summary>
        /// Band
        /// </summary>
        D92,

        /// <summary>
        /// Second per Cubic Metre
        /// </summary>
        D93,

        /// <summary>
        /// Second per Radian Cubic Metre
        /// </summary>
        D94,

        /// <summary>
        /// Joule per Gram
        /// </summary>
        D95,

        /// <summary>
        /// Pound Gross
        /// </summary>
        D96,

        /// <summary>
        /// Pallet / Unit Load
        /// </summary>
        D97,

        /// <summary>
        /// Mass Pound
        /// </summary>
        D98,

        /// <summary>
        /// Sleeve
        /// </summary>
        D99,

        /// <summary>
        /// Decare
        /// </summary>
        DAA,

        /// <summary>
        /// Ten Day
        /// </summary>
        DAD,

        /// <summary>
        /// Days
        /// </summary>
        DAY,

        /// <summary>
        /// Dry Pound
        /// </summary>
        DB,

        /// <summary>
        /// Disk (Disc)
        /// </summary>
        DC,

        /// <summary>
        /// Degree (Unit of Angel)
        /// </summary>
        DD,

        /// <summary>
        /// Deal
        /// </summary>
        DE,

        /// <summary>
        /// Decade
        /// </summary>
        DEC,

        /// <summary>
        /// Decigram
        /// </summary>
        DG,

        /// <summary>
        /// Dispenser
        /// </summary>
        DI,

        /// <summary>
        /// Decagram
        /// </summary>
        DJ,

        /// <summary>
        /// Decilitre
        /// </summary>
        DLT,

        /// <summary>
        /// Square decimetre
        /// </summary>
        DMK,

        /// <summary>
        /// Cubic decimetre
        /// </summary>
        DMQ,

        /// <summary>
        /// Decimetre
        /// </summary>
        DMT,

        /// <summary>
        /// Decinewton Metre
        /// </summary>
        DN,

        /// <summary>
        /// Dozen Piece
        /// </summary>
        DPC,

        /// <summary>
        /// Dozen Pair
        /// </summary>
        DPR,

        /// <summary>
        /// Displacement Tonnage
        /// </summary>
        DPT,

        /// <summary>
        /// Data Record
        /// </summary>
        DQ,

        /// <summary>
        /// Drum
        /// </summary>
        DR,

        /// <summary>
        /// Dram (US)
        /// </summary>
        DRA,

        /// <summary>
        /// Dram (UK)
        /// </summary>
        DRI,

        /// <summary>
        /// Dozen Roll
        /// </summary>
        DRL,

        /// <summary>
        /// Drachm / Dram
        /// </summary>
        DRM,

        /// <summary>
        /// Display
        /// </summary>
        DS,

        /// <summary>
        /// Dry Ton
        /// </summary>
        DT,

        /// <summary>
        /// Decitonne
        /// </summary>
        DTN,

        /// <summary>
        /// Dyne
        /// </summary>
        DU,

        /// <summary>
        /// Pennyweight
        /// </summary>
        DWT,

        /// <summary>
        /// Dyne per Centimetre
        /// </summary>
        DX,

        /// <summary>
        /// Directory Book
        /// </summary>
        DY,

        /// <summary>
        /// Dozen
        /// </summary>
        DZN,

        /// <summary>
        /// Dozen Pack
        /// </summary>
        DZP,

        /// <summary>
        /// Milliampere Hour
        /// </summary>
        E09,

        /// <summary>
        /// Kilocalorie (international table)
        /// </summary>
        E14,

        /// <summary>
        /// Belt
        /// </summary>
        E2,

        /// <summary>
        /// Dose
        /// </summary>
        E27,

        /// <summary>
        /// Trailer
        /// </summary>
        E3,

        /// <summary>
        /// Litre per Hour
        /// </summary>
        E32,

        /// <summary>
        /// Gigabyte
        /// </summary>
        E34,

        /// <summary>
        /// Terabyte
        /// </summary>
        E35,

        /// <summary>
        /// Pixel
        /// </summary>
        E37,

        /// <summary>
        /// Dots per Inch
        /// </summary>
        E39,

        /// <summary>
        /// Gross kilogram
        /// </summary>
        E4,

        /// <summary>
        /// Metric Long Ton
        /// </summary>
        E5,

        /// <summary>
        /// Use
        /// </summary>
        E55,

        /// <summary>
        /// Each
        /// </summary>
        EA,

        /// <summary>
        /// Electronic Mail Box
        /// </summary>
        EB,

        /// <summary>
        /// Each per Month
        /// </summary>
        EC,

        /// <summary>
        /// ELISA Units
        /// </summary>
        ELU,

        /// <summary>
        /// Eleven Pack
        /// </summary>
        EP,

        /// <summary>
        /// Equivalent Gallon
        /// </summary>
        EQ,

        /// <summary>
        /// Envelope
        /// </summary>
        EV,

        /// <summary>
        /// Thousand Cubic Feet per Day
        /// </summary>
        F1,

        /// <summary>
        /// Gram per Hour
        /// </summary>
        F27,

        /// <summary>
        /// Fibre per Cubic Centimetre of Air
        /// </summary>
        F9,

        /// <summary>
        /// Degree Fahrenheit
        /// </summary>
        FAH,

        /// <summary>
        /// Farad
        /// </summary>
        FAR,

        /// <summary>
        /// Field
        /// </summary>
        FB,

        /// <summary>
        /// Thousand Cubic Feet
        /// </summary>
        FC,

        /// <summary>
        /// Million Particle per Cubic Foot
        /// </summary>
        FD,

        /// <summary>
        /// Track Foot
        /// </summary>
        FE,

        /// <summary>
        /// Hundred Cubic Metre
        /// </summary>
        FF,

        /// <summary>
        /// Transdermal Patch
        /// </summary>
        FG,

        /// <summary>
        /// Micromole
        /// </summary>
        FH,

        /// <summary>
        /// Sizing Factor
        /// </summary>
        FJ,

        /// <summary>
        /// Flake Ton
        /// </summary>
        FL,

        /// <summary>
        /// Million Cubic Feet
        /// </summary>
        FM,

        /// <summary>
        /// Foot
        /// </summary>
        FOT,

        /// <summary>
        /// Pound per Square Foot
        /// </summary>
        FP,

        /// <summary>
        /// Foot per Minute
        /// </summary>
        FR,

        /// <summary>
        /// Foot per Second
        /// </summary>
        FS,

        /// <summary>
        /// Square foot
        /// </summary>
        FTK,

        /// <summary>
        /// Cubic foot
        /// </summary>
        FTQ,

        /// <summary>
        /// Gallon (US) per Minute
        /// </summary>
        G2,

        /// <summary>
        /// Cup (US)
        /// </summary>
        G21,

        /// <summary>
        /// Peck
        /// </summary>
        G23,

        /// <summary>
        /// Tablespoon
        /// </summary>
        G24,

        /// <summary>
        /// Teaspoon
        /// </summary>
        G25,

        /// <summary>
        /// Imperial Gallon per Minute
        /// </summary>
        G3,

        /// <summary>
        /// Microfiche Sheet
        /// </summary>
        G7,

        /// <summary>
        /// Gallon (US) per Day
        /// </summary>
        GB,

        /// <summary>
        /// Gigabecquerel
        /// </summary>
        GBQ,

        /// <summary>
        /// Gram per 100 Gram
        /// </summary>
        GC,

        /// <summary>
        /// Gross Barrel
        /// </summary>
        GD,

        /// <summary>
        /// Pound per Gallon (US)
        /// </summary>
        GE,

        /// <summary>
        /// Gram per Metre (Gram per 100 Centimetres)
        /// </summary>
        GF,

        /// <summary>
        /// Gram of Fissile Isotope
        /// </summary>
        GFI,

        /// <summary>
        /// Great Gross
        /// </summary>
        GGR,

        /// <summary>
        /// Half Gallon (US)
        /// </summary>
        GH,

        /// <summary>
        /// Gill (US)
        /// </summary>
        GIA,

        /// <summary>
        /// Gill (UK)
        /// </summary>
        GII,

        /// <summary>
        /// Gram per Millilitre
        /// </summary>
        GJ,

        /// <summary>
        /// Gram per Kilogram
        /// </summary>
        GK,

        /// <summary>
        /// Gram per Litre
        /// </summary>
        GL,

        /// <summary>
        /// Dry Gallon (US)
        /// </summary>
        GLD,

        /// <summary>
        /// Gallon (UK)
        /// </summary>
        GLI,

        /// <summary>
        /// Gallon (US)
        /// </summary>
        GLL,

        /// <summary>
        /// Gram per Square Metre
        /// </summary>
        GM,

        /// <summary>
        /// Gross Gallon
        /// </summary>
        GN,

        /// <summary>
        /// Milligrams per Square Metre
        /// </summary>
        GO,

        /// <summary>
        /// Milligram per Cubic Metre
        /// </summary>
        GP,

        /// <summary>
        /// Microgram per Cubic Meter
        /// </summary>
        GQ,

        /// <summary>
        /// Gram
        /// </summary>
        GRM,

        /// <summary>
        /// Grain
        /// </summary>
        GRN,

        /// <summary>
        /// Gross
        /// </summary>
        GRO,

        /// <summary>
        /// Gross Register Ton
        /// </summary>
        GRT,

        /// <summary>
        /// Gross Ton
        /// </summary>
        GT,

        /// <summary>
        /// Gigajoule
        /// </summary>
        GV,

        /// <summary>
        /// Gallon per Thousand Cubic Feet
        /// </summary>
        GW,

        /// <summary>
        /// Gigawatt Hour
        /// </summary>
        GWH,

        /// <summary>
        /// Gross Yard
        /// </summary>
        GY,

        /// <summary>
        /// Gage System
        /// </summary>
        GZ,

        /// <summary>
        /// Half Page
        /// </summary>
        H1,

        /// <summary>
        /// Half Litre
        /// </summary>
        H2,

        /// <summary>
        /// French Gauge
        /// </summary>
        H79,

        /// <summary>
        /// Piece
        /// </summary>
        H87,

        /// <summary>
        /// Hank
        /// </summary>
        HA,

        /// <summary>
        /// Hectare
        /// </summary>
        HAR,

        /// <summary>
        /// Hectobar
        /// </summary>
        HBA,

        /// <summary>
        /// Hundred Boxe
        /// </summary>
        HBX,

        /// <summary>
        /// Hundred Count
        /// </summary>
        HC,

        /// <summary>
        /// Half dozen
        /// </summary>
        HD,

        /// <summary>
        /// Hundredth of a Carat
        /// </summary>
        HE,

        /// <summary>
        /// Histamine Equivalent Prick
        /// </summary>
        HEP,

        /// <summary>
        /// Hundred Feet
        /// </summary>
        HF,

        /// <summary>
        /// Hectogram
        /// </summary>
        HGM,

        /// <summary>
        /// Hundred Cubic Feet
        /// </summary>
        HH,

        /// <summary>
        /// Hundred Sheet
        /// </summary>
        HI,

        /// <summary>
        /// Hundred International Unit
        /// </summary>
        HIU,

        /// <summary>
        /// Metric Horse Power
        /// </summary>
        HJ,

        /// <summary>
        /// Hundred Kilogram
        /// </summary>
        HK,

        /// <summary>
        /// Hundred Feet (Linear)
        /// </summary>
        HL,

        /// <summary>
        /// Hectolitre
        /// </summary>
        HLT,

        /// <summary>
        /// Mile per Hour
        /// </summary>
        HM,

        /// <summary>
        /// Million Cubic Metre
        /// </summary>
        HMQ,

        /// <summary>
        /// Hectometre
        /// </summary>
        HMT,

        /// <summary>
        /// Conventional Millimetre of Mercury
        /// </summary>
        HN,

        /// <summary>
        /// Hundred Troy Ounce
        /// </summary>
        HO,

        /// <summary>
        /// Conventional Millimetre of Water
        /// </summary>
        HP,

        /// <summary>
        /// Hectolitre of Pure Alcohol
        /// </summary>
        HPA,

        /// <summary>
        /// Hundred Square Feet
        /// </summary>
        HS,

        /// <summary>
        /// Half Hour
        /// </summary>
        HT,

        /// <summary>
        /// Hertz
        /// </summary>
        HTZ,

        /// <summary>
        /// Hour
        /// </summary>
        HUR,

        /// <summary>
        /// Hundred Yard
        /// </summary>
        HY,

        /// <summary>
        /// Inch Pound (Pound Inch)
        /// </summary>
        IA,

        /// <summary>
        /// Count per Inch
        /// </summary>
        IC,

        /// <summary>
        /// Person
        /// </summary>
        IE,

        /// <summary>
        /// Inches of Water
        /// </summary>
        IF,

        /// <summary>
        /// Column Inch
        /// </summary>
        II,

        /// <summary>
        /// Inch per Minute
        /// </summary>
        IL,

        /// <summary>
        /// Impression
        /// </summary>
        IM,

        /// <summary>
        /// Inches
        /// </summary>
        INH,

        /// <summary>
        /// Square inch
        /// </summary>
        INK,

        /// <summary>
        /// Cubic inch
        /// </summary>
        INQ,

        /// <summary>
        /// Insurance Policy
        /// </summary>
        IP,

        /// <summary>
        /// Count per Centimetre
        /// </summary>
        IT,

        /// <summary>
        /// Inch per Second (Linear Speed)
        /// </summary>
        IU,

        /// <summary>
        /// Inch per Second Squared (Acceleration)
        /// </summary>
        IV,

        /// <summary>
        /// Joule per Kilogram
        /// </summary>
        J2,

        /// <summary>
        /// Jumbo
        /// </summary>
        JB,

        /// <summary>
        /// Joule per Kelvin
        /// </summary>
        JE,

        /// <summary>
        /// Jug
        /// </summary>
        JG,

        /// <summary>
        /// Megajoule per Kilogram
        /// </summary>
        JK,

        /// <summary>
        /// Megajoule per Cubic Metre
        /// </summary>
        JM,

        /// <summary>
        /// Joint
        /// </summary>
        JO,

        /// <summary>
        /// Joule
        /// </summary>
        JOU,

        /// <summary>
        /// Jar
        /// </summary>
        JR,

        /// <summary>
        /// Kilowatt Demand
        /// </summary>
        K1,

        /// <summary>
        /// Kilovolt Ampere Reactive Demand
        /// </summary>
        K2,

        /// <summary>
        /// Kilovolt Ampere Reactive Hour
        /// </summary>
        K3,

        /// <summary>
        /// Kilovolt Ampere (Reactive)
        /// </summary>
        K5,

        /// <summary>
        /// Kilolitre
        /// </summary>
        K6,

        /// <summary>
        /// Cake
        /// </summary>
        KA,

        /// <summary>
        /// Kilocharacter
        /// </summary>
        KB,

        /// <summary>
        /// Kilobar
        /// </summary>
        KBA,

        /// <summary>
        /// Kilogram Decimal
        /// </summary>
        KD,

        /// <summary>
        /// Kelvin
        /// </summary>
        KEL,

        /// <summary>
        /// Kilopacket
        /// </summary>
        KF,

        /// <summary>
        /// Keg
        /// </summary>
        KG,

        /// <summary>
        /// Kilogram
        /// </summary>
        KGM,

        /// <summary>
        /// Kilogram per Second
        /// </summary>
        KGS,

        /// <summary>
        /// Kilohertz
        /// </summary>
        KHZ,

        /// <summary>
        /// Kilogram per Millimetre Width
        /// </summary>
        KI,

        /// <summary>
        /// Kallikrein inactivator unit.
        /// </summary>
        KIU,

        /// <summary>
        /// Kilosegment
        /// </summary>
        KJ,

        /// <summary>
        /// Kilojoule
        /// </summary>
        KJO,

        /// <summary>
        /// Kilogram per Metre
        /// </summary>
        KL,

        /// <summary>
        /// Kilometre per Hour
        /// </summary>
        KMH,

        /// <summary>
        /// Square Kilometre
        /// </summary>
        KMK,

        /// <summary>
        /// Kilogram per Cubic Metre
        /// </summary>
        KMQ,

        /// <summary>
        /// Kilometre
        /// </summary>
        KMT,

        /// <summary>
        /// Kilogram of Nitrogen
        /// </summary>
        KNI,

        /// <summary>
        /// Kilonewton per Square Metre
        /// </summary>
        KNM,

        /// <summary>
        /// Kilogram Named Substance
        /// </summary>
        KNS,

        /// <summary>
        /// Knot
        /// </summary>
        KNT,

        /// <summary>
        /// The Milliequivalence Caustic Potash per Gram of Product
        /// </summary>
        KO,

        /// <summary>
        /// Kilopascal
        /// </summary>
        KPA,

        /// <summary>
        /// Kilogram of Potassium Hydroxide (Caustic Potash)
        /// </summary>
        KPH,

        /// <summary>
        /// Kilogram of Potassium Oxide
        /// </summary>
        KPO,

        /// <summary>
        /// Kilogram of Phosphorus Pentoxide (Phosphoric Anhydride)
        /// </summary>
        KPP,

        /// <summary>
        /// Kiloröntgen
        /// </summary>
        KR,

        /// <summary>
        /// Thousand Pound per Square Inch
        /// </summary>
        KS,

        /// <summary>
        /// Kilogram of Substance 90 % Dry
        /// </summary>
        KSD,

        /// <summary>
        /// Kilogram of Sodium Hydroxide (Caustic Soda)
        /// </summary>
        KSH,

        /// <summary>
        /// Kit
        /// </summary>
        KT,

        /// <summary>
        /// Kilometre
        /// </summary>
        KTM,

        /// <summary>
        /// Kilotonne
        /// </summary>
        KTN,

        /// <summary>
        /// Kilogram of Uranium
        /// </summary>
        KUR,

        /// <summary>
        /// Kilovolt
        /// </summary>
        KVA,

        /// <summary>
        /// Kilovar
        /// </summary>
        KVR,

        /// <summary>
        /// Kilovolt
        /// </summary>
        KVT,

        /// <summary>
        /// Kilograms per Millimeter
        /// </summary>
        KW,

        /// <summary>
        /// Kilowatt hour
        /// </summary>
        KWH,

        /// <summary>
        /// Kilowatt
        /// </summary>
        KWT,

        /// <summary>
        /// Millilitre per Kilogram
        /// </summary>
        KX,

        /// <summary>
        /// Litre per Minute
        /// </summary>
        L2,

        /// <summary>
        /// Pound per Cubic Inch
        /// </summary>
        LA,

        /// <summary>
        /// Pound
        /// </summary>
        LBR,

        /// <summary>
        /// Troy Pound (US)
        /// </summary>
        LBT,

        /// <summary>
        /// Linear Centimetre
        /// </summary>
        LC,

        /// <summary>
        /// Litre per Day
        /// </summary>
        LD,

        /// <summary>
        /// Lite
        /// </summary>
        LE,

        /// <summary>
        /// Leaf
        /// </summary>
        LEF,

        /// <summary>
        /// Linear foot
        /// </summary>
        LF,

        /// <summary>
        /// Labour Hour
        /// </summary>
        LH,

        /// <summary>
        /// Linear Inch
        /// </summary>
        LI,

        /// <summary>
        /// Large Spray
        /// </summary>
        LJ,

        /// <summary>
        /// Link
        /// </summary>
        LK,

        /// <summary>
        /// Linear metre
        /// </summary>
        LM,

        /// <summary>
        /// Length
        /// </summary>
        LN,

        /// <summary>
        /// Lot
        /// </summary>
        LO,

        /// <summary>
        /// Liquid Pound
        /// </summary>
        LP,

        /// <summary>
        /// Litre of Pure Alcohol
        /// </summary>
        LPA,

        /// <summary>
        /// Layer
        /// </summary>
        LR,

        /// <summary>
        /// Lump Sum
        /// </summary>
        LS,

        /// <summary>
        /// Ton (UK) or Long Ton (US)
        /// </summary>
        LTN,

        /// <summary>
        /// Litre
        /// </summary>
        LTR,

        /// <summary>
        /// Lumen
        /// </summary>
        LUM,

        /// <summary>
        /// Lux
        /// </summary>
        LUX,

        /// <summary>
        /// Linear Yard per Pound
        /// </summary>
        LX,

        /// <summary>
        /// Linear Yard
        /// </summary>
        LY,

        /// <summary>
        /// Magnetic Tape
        /// </summary>
        M0,

        /// <summary>
        /// Milligrams per Litre
        /// </summary>
        M1,

        /// <summary>
        /// Monetary Value
        /// </summary>
        M4,

        /// <summary>
        /// Microcurie
        /// </summary>
        M5,

        /// <summary>
        /// Micro-Inch
        /// </summary>
        M7,

        /// <summary>
        /// Million Btu per 1000 Cubic Feet
        /// </summary>
        M9,

        /// <summary>
        /// Machine per Unit
        /// </summary>
        MA,

        /// <summary>
        /// Mega Litre
        /// </summary>
        MAL,

        /// <summary>
        /// Megametre
        /// </summary>
        MAM,

        /// <summary>
        /// Megawatt
        /// </summary>
        MAW,

        /// <summary>
        /// Thousand Standard Brick Equivalent
        /// </summary>
        MBE,

        /// <summary>
        /// Thousand Board Feet
        /// </summary>
        MBF,

        /// <summary>
        /// Millibar
        /// </summary>
        MBR,

        /// <summary>
        /// Microgram
        /// </summary>
        MC,

        /// <summary>
        /// Millicurie
        /// </summary>
        MCU,

        /// <summary>
        /// Air Dry Metric Ton
        /// </summary>
        MD,

        /// <summary>
        /// Milliequivalents
        /// </summary>
        MEQ,

        /// <summary>
        /// Milligram per Square Foot per Side
        /// </summary>
        MF,

        /// <summary>
        /// Milligram
        /// </summary>
        MGM,

        /// <summary>
        /// Megahertz
        /// </summary>
        MHZ,

        /// <summary>
        /// Square Mile
        /// </summary>
        MIK,

        /// <summary>
        /// Thousand
        /// </summary>
        MIL,

        /// <summary>
        /// Minute (unit of time)
        /// </summary>
        MIN,

        /// <summary>
        /// Million
        /// </summary>
        MIO,

        /// <summary>
        /// Million International Unit (NIE)
        /// </summary>
        MIU,

        /// <summary>
        /// Milligram per Square Inch
        /// </summary>
        MK,

        /// <summary>
        /// Milliard
        /// </summary>
        MLD,

        /// <summary>
        /// Millilitre
        /// </summary>
        MLT,

        /// <summary>
        /// Square Millimetre
        /// </summary>
        MMK,

        /// <summary>
        /// Cubic Millimetre
        /// </summary>
        MMQ,

        /// <summary>
        /// Millimetre
        /// </summary>
        MMT,

        /// <summary>
        /// Month
        /// </summary>
        MON,

        /// <summary>
        /// Megapascal
        /// </summary>
        MPA,

        /// <summary>
        /// Most Probable Number
        /// </summary>
        MPN,

        /// <summary>
        /// Thousand Metre
        /// </summary>
        MQ,

        /// <summary>
        /// Cubic Metre per Hour
        /// </summary>
        MQH,

        /// <summary>
        /// Cubic Metre per Second
        /// </summary>
        MQS,

        /// <summary>
        /// Metre per Second Squared
        /// </summary>
        MSK,

        /// <summary>
        /// Mat
        /// </summary>
        MT,

        /// <summary>
        /// Square Metre
        /// </summary>
        MTK,

        /// <summary>
        /// Cubic Metre
        /// </summary>
        MTQ,

        /// <summary>
        /// Metre
        /// </summary>
        MTR,

        /// <summary>
        /// Metre per Second
        /// </summary>
        MTS,

        /// <summary>
        /// Number of Mults
        /// </summary>
        MV,

        /// <summary>
        /// Megavolt - Ampere
        /// </summary>
        MVA,

        /// <summary>
        /// Megawatt Hour (1000 kW.h)
        /// </summary>
        MWH,

        /// <summary>
        /// Pen Calorie
        /// </summary>
        N1,

        /// <summary>
        /// Number of Lines
        /// </summary>
        N2,

        /// <summary>
        /// Print Point
        /// </summary>
        N3,

        /// <summary>
        /// Milligram per Kilogram
        /// </summary>
        NA,

        /// <summary>
        /// Number of Articles
        /// </summary>
        NAR,

        /// <summary>
        /// Barge
        /// </summary>
        NB,

        /// <summary>
        /// Number of Bobbins
        /// </summary>
        NBB,

        /// <summary>
        /// Car
        /// </summary>
        NC,

        /// <summary>
        /// Number of Cells
        /// </summary>
        NCL,

        /// <summary>
        /// Net Barrel
        /// </summary>
        ND,

        /// <summary>
        /// Net Litre
        /// </summary>
        NE,

        /// <summary>
        /// Newton
        /// </summary>
        NEW,

        /// <summary>
        /// Message
        /// </summary>
        NF,

        /// <summary>
        /// Net Gallon (US)
        /// </summary>
        NG,

        /// <summary>
        /// Message Hour
        /// </summary>
        NH,

        /// <summary>
        /// Net Imperial Gallon
        /// </summary>
        NI,

        /// <summary>
        /// Number of International Units
        /// </summary>
        NIU,

        /// <summary>
        /// Number of Screens
        /// </summary>
        NJ,

        /// <summary>
        /// Load
        /// </summary>
        NL,

        /// <summary>
        /// Nautical Mile
        /// </summary>
        NMI,

        /// <summary>
        /// Number of Packs
        /// </summary>
        NMP,

        /// <summary>
        /// Train
        /// </summary>
        NN,

        /// <summary>
        /// Number of Parcels
        /// </summary>
        NPL,

        /// <summary>
        /// Number of Pairs
        /// </summary>
        NPR,

        /// <summary>
        /// Number of Parts
        /// </summary>
        NPT,

        /// <summary>
        /// Mho
        /// </summary>
        NQ,

        /// <summary>
        /// Micromho
        /// </summary>
        NR,

        /// <summary>
        /// Number of Rolls
        /// </summary>
        NRL,

        /// <summary>
        /// Net Ton
        /// </summary>
        NT,

        /// <summary>
        /// Net Register Ton
        /// </summary>
        NTT,

        /// <summary>
        /// Newton Metre
        /// </summary>
        NU,

        /// <summary>
        /// Vehicle
        /// </summary>
        NV,

        /// <summary>
        /// Part per Thousand
        /// </summary>
        NX,

        /// <summary>
        /// Pound per Air Dry Metric Ton
        /// </summary>
        NY,

        /// <summary>
        /// Panel
        /// </summary>
        OA,

        /// <summary>
        /// Ohm
        /// </summary>
        OHM,

        /// <summary>
        /// Ounces per Square Yard
        /// </summary>
        ON,

        /// <summary>
        /// Ounce
        /// </summary>
        ONZ,

        /// <summary>
        /// Two Pack
        /// </summary>
        OP,

        /// <summary>
        /// Oscillations per Minute
        /// </summary>
        OPM,

        /// <summary>
        /// Overtime Hour
        /// </summary>
        OT,

        /// <summary>
        /// Ounce Av
        /// </summary>
        OZ,

        /// <summary>
        /// Fluid ounce (US)
        /// </summary>
        OZA,

        /// <summary>
        /// Fluid ounce (UK)
        /// </summary>
        OZI,

        /// <summary>
        /// Page - Electronic
        /// </summary>
        P0,

        /// <summary>
        /// Percent
        /// </summary>
        P1,

        /// <summary>
        /// Pound per Foot
        /// </summary>
        P2,

        /// <summary>
        /// Three Pack
        /// </summary>
        P3,

        /// <summary>
        /// Four Pack
        /// </summary>
        P4,

        /// <summary>
        /// Five Pack
        /// </summary>
        P5,

        /// <summary>
        /// Six Pack
        /// </summary>
        P6,

        /// <summary>
        /// Seven Pack
        /// </summary>
        P7,

        /// <summary>
        /// Eight Pack
        /// </summary>
        P8,

        /// <summary>
        /// Nine Pack
        /// </summary>
        P9,

        /// <summary>
        /// Packet
        /// </summary>
        PA,

        /// <summary>
        /// Pascal
        /// </summary>
        PAL,

        /// <summary>
        /// Pair Inch
        /// </summary>
        PB,

        /// <summary>
        /// Piece
        /// </summary>
        PCE,

        /// <summary>
        /// Pad
        /// </summary>
        PD,

        /// <summary>
        /// Pound Equivalent
        /// </summary>
        PE,

        /// <summary>
        /// Pallet (Lift)
        /// </summary>
        PF,

        /// <summary>
        /// Plaque Forming Unit(s)
        /// </summary>
        PFU,

        /// <summary>
        /// Plate
        /// </summary>
        PG,

        /// <summary>
        /// Proof Gallon
        /// </summary>
        PGL,

        /// <summary>
        /// Pitch
        /// </summary>
        PI,

        /// <summary>
        /// Package
        /// </summary>
        PK,

        /// <summary>
        /// Pail
        /// </summary>
        PL,

        /// <summary>
        /// Pound Percentage
        /// </summary>
        PM,

        /// <summary>
        /// Pound Net
        /// </summary>
        PN,

        /// <summary>
        /// Point
        /// </summary>
        PNT,

        /// <summary>
        /// Pound per Inch of Length
        /// </summary>
        PO,

        /// <summary>
        /// Page per Inch
        /// </summary>
        PQ,

        /// <summary>
        /// Pair
        /// </summary>
        PR,

        /// <summary>
        /// Potential Renal Solute Load
        /// </summary>
        PRS,

        /// <summary>
        /// Pound-Force per Square Inch
        /// </summary>
        PS,

        /// <summary>
        /// Pint (US)
        /// </summary>
        PT,

        /// <summary>
        /// Dry Pint (US)
        /// </summary>
        PTD,

        /// <summary>
        /// Pint (UK)
        /// </summary>
        PTI,

        /// <summary>
        /// Liquid pint (US)
        /// </summary>
        PTL,

        /// <summary>
        /// Portion
        /// </summary>
        PTN,

        /// <summary>
        /// Tray / Tray Pack
        /// </summary>
        PU,

        /// <summary>
        /// Half Pint (US)
        /// </summary>
        PV,

        /// <summary>
        /// Pound per Inch of Width
        /// </summary>
        PW,

        /// <summary>
        /// Peck Dry (US)
        /// </summary>
        PY,

        /// <summary>
        /// Peck Dry (UK)
        /// </summary>
        PZ,

        /// <summary>
        /// Meal
        /// </summary>
        Q3,

        /// <summary>
        /// pH (Potential of Hydrogen)
        /// </summary>
        Q30,

        /// <summary>
        /// Femtolitre
        /// </summary>
        Q32,

        /// <summary>
        /// Picolitre
        /// </summary>
        Q33,

        /// <summary>
        /// Nanolitre
        /// </summary>
        Q34,

        /// <summary>
        /// Page - Facsimile
        /// </summary>
        QA,

        /// <summary>
        /// Quarter (of a Year)
        /// </summary>
        QAN,

        /// <summary>
        /// Page - hardcopy
        /// </summary>
        QB,

        /// <summary>
        /// Quarter Dozen
        /// </summary>
        QD,

        /// <summary>
        /// Quarter Hour
        /// </summary>
        QH,

        /// <summary>
        /// Quarter Kilogram
        /// </summary>
        QK,

        /// <summary>
        /// Quire
        /// </summary>
        QR,

        /// <summary>
        /// Quart (US)
        /// </summary>
        QT,

        /// <summary>
        /// Pump or Quart (US dry)
        /// </summary>
        QTD,

        /// <summary>
        /// Proof Gallon or Quart (UK)
        /// </summary>
        QTI,

        /// <summary>
        /// Liquid Quart (US)
        /// </summary>
        QTL,

        /// <summary>
        /// Quarter (UK)
        /// </summary>
        QTR,

        /// <summary>
        /// Pica
        /// </summary>
        R1,

        /// <summary>
        /// Thousand Cubic Metre
        /// </summary>
        R9,

        /// <summary>
        /// Rack
        /// </summary>
        RA,

        /// <summary>
        /// Rod
        /// </summary>
        RD,

        /// <summary>
        /// Ring
        /// </summary>
        RG,

        /// <summary>
        /// Running or Operating Hour
        /// </summary>
        RH,

        /// <summary>
        /// Roll Metric Measure
        /// </summary>
        RK,

        /// <summary>
        /// Reel
        /// </summary>
        RL,

        /// <summary>
        /// Ream
        /// </summary>
        RM,

        /// <summary>
        /// Ream Metric Measure
        /// </summary>
        RN,

        /// <summary>
        /// Roll
        /// </summary>
        RO,

        /// <summary>
        /// Pound per Ream
        /// </summary>
        RP,

        /// <summary>
        /// Revolutions per Minute
        /// </summary>
        RPM,

        /// <summary>
        /// Revolutions per Second
        /// </summary>
        RPS,

        /// <summary>
        /// Reset
        /// </summary>
        RS,

        /// <summary>
        /// Revenue Ton Mile
        /// </summary>
        RT,

        /// <summary>
        /// Run
        /// </summary>
        RU,

        /// <summary>
        /// Square Foot per Second
        /// </summary>
        S3,

        /// <summary>
        /// Square Metre per Second
        /// </summary>
        S4,

        /// <summary>
        /// Sixty Fourths of an Inch
        /// </summary>
        S5,

        /// <summary>
        /// Session
        /// </summary>
        S6,

        /// <summary>
        /// Storage Unit
        /// </summary>
        S7,

        /// <summary>
        /// Standard Advertising Unit
        /// </summary>
        S8,

        /// <summary>
        /// Sack
        /// </summary>
        SA,

        /// <summary>
        /// Half Year (6 Months)
        /// </summary>
        SAN,

        /// <summary>
        /// Score
        /// </summary>
        SCO,

        /// <summary>
        /// Scruple
        /// </summary>
        SCR,

        /// <summary>
        /// Solid Pound
        /// </summary>
        SD,

        /// <summary>
        /// Section
        /// </summary>
        SE,

        /// <summary>
        /// Second (Unit of Time)
        /// </summary>
        SEC,

        /// <summary>
        /// Set
        /// </summary>
        SET,

        /// <summary>
        /// Segment
        /// </summary>
        SG,

        /// <summary>
        /// Shipping Ton
        /// </summary>
        SHT,

        /// <summary>
        /// Siemens
        /// </summary>
        SIE,

        /// <summary>
        /// Split Tanktruck
        /// </summary>
        SK,

        /// <summary>
        /// Slipsheet
        /// </summary>
        SL,

        /// <summary>
        /// Mile (Statute Mile)
        /// </summary>
        SMI,

        /// <summary>
        /// Square Rod
        /// </summary>
        SN,

        /// <summary>
        /// Spool
        /// </summary>
        SO,

        /// <summary>
        /// Shelf Package
        /// </summary>
        SP,

        /// <summary>
        /// Square
        /// </summary>
        SQ,

        /// <summary>
        /// SQ-E
        /// </summary>
        SQE,

        /// <summary>
        /// Strip
        /// </summary>
        SR,

        /// <summary>
        /// Sheet Metric Measure
        /// </summary>
        SS,

        /// <summary>
        /// Short Standard (7200 Matches)
        /// </summary>
        SST,

        /// <summary>
        /// Sheet
        /// </summary>
        ST,

        /// <summary>
        /// Stone (UK)
        /// </summary>
        STI,

        /// <summary>
        /// Ton (US) or Short Ton (UK)
        /// </summary>
        STN,

        /// <summary>
        /// Skid
        /// </summary>
        SV,

        /// <summary>
        /// Skein
        /// </summary>
        SW,

        /// <summary>
        /// Shipment
        /// </summary>
        SX,

        /// <summary>
        /// Telecommunication Line in Service
        /// </summary>
        T0,

        /// <summary>
        /// Thousand Pound Gross
        /// </summary>
        T1,

        /// <summary>
        /// Thousand Piece
        /// </summary>
        T3,

        /// <summary>
        /// Thousand Bag
        /// </summary>
        T4,

        /// <summary>
        /// Thousand Casing
        /// </summary>
        T5,

        /// <summary>
        /// Thousand Gallon (US)
        /// </summary>
        T6,

        /// <summary>
        /// Thousand Impression
        /// </summary>
        T7,

        /// <summary>
        /// Thousand Linear Inch
        /// </summary>
        T8,

        /// <summary>
        /// Kiloampere Hour (Thousand Ampere Hour)
        /// </summary>
        TAH,

        /// <summary>
        /// Truckload
        /// </summary>
        TC,

        /// <summary>
        /// Therm
        /// </summary>
        TD,

        /// <summary>
        /// Tote
        /// </summary>
        TE,

        /// <summary>
        /// Ten Square Yard
        /// </summary>
        TF,

        /// <summary>
        /// Thousand Square Inch
        /// </summary>
        TI,

        /// <summary>
        /// Thousand Square Centimeter
        /// </summary>
        TJ,

        /// <summary>
        /// Tank, Rectangular
        /// </summary>
        TK,

        /// <summary>
        /// Thousand Feet (Linear)
        /// </summary>
        TL,

        /// <summary>
        /// Tin
        /// </summary>
        TN,

        /// <summary>
        /// Tonne
        /// </summary>
        TNE,

        /// <summary>
        /// Ten Pack
        /// </summary>
        TP,

        /// <summary>
        /// Teeth per Inch
        /// </summary>
        TPI,

        /// <summary>
        /// Ten Pair
        /// </summary>
        TPR,

        /// <summary>
        /// Thousand Feet
        /// </summary>
        TQ,

        /// <summary>
        /// Thousand Cubic Metre per Day
        /// </summary>
        TQD,

        /// <summary>
        /// Ten Square Feet
        /// </summary>
        TR,

        /// <summary>
        /// Trillion (Eur)
        /// </summary>
        TRL,

        /// <summary>
        /// Thousand Square Feet
        /// </summary>
        TS,

        /// <summary>
        /// Tonne of Substance 90 % Dry
        /// </summary>
        TSD,

        /// <summary>
        /// Ton of Steam per Hour
        /// </summary>
        TSH,

        /// <summary>
        /// Thousand Linear Metre
        /// </summary>
        TT,

        /// <summary>
        /// Tube
        /// </summary>
        TU,

        /// <summary>
        /// Thousand Kilogram
        /// </summary>
        TV,

        /// <summary>
        /// Thousand Sheet
        /// </summary>
        TW,

        /// <summary>
        /// Tank, Cylindrical
        /// </summary>
        TY,

        /// <summary>
        /// Treatment
        /// </summary>
        U1,

        /// <summary>
        /// Tablet
        /// </summary>
        U2,

        /// <summary>
        /// Torr
        /// </summary>
        UA,

        /// <summary>
        /// Telecommunication Line in Service Average
        /// </summary>
        UB,

        /// <summary>
        /// Telecommunication Port
        /// </summary>
        UC,

        /// <summary>
        /// Tenth Minute
        /// </summary>
        UD,

        /// <summary>
        /// Tenth Hour
        /// </summary>
        UE,

        /// <summary>
        /// Usage per Telecommunication Line Average
        /// </summary>
        UF,

        /// <summary>
        /// Ten Thousand Yard
        /// </summary>
        UH,

        /// <summary>
        /// Million Unit
        /// </summary>
        UM,

        /// <summary>
        /// Volt Ampere per Kilogram
        /// </summary>
        VA,

        /// <summary>
        /// Vial
        /// </summary>
        VI,

        /// <summary>
        /// Volt
        /// </summary>
        VLT,

        /// <summary>
        /// Bulk
        /// </summary>
        VQ,

        /// <summary>
        /// Visit
        /// </summary>
        VS,

        /// <summary>
        /// Wet Kilo
        /// </summary>
        W2,

        /// <summary>
        /// Two Week
        /// </summary>
        W4,

        /// <summary>
        /// Watt per Kilogram
        /// </summary>
        WA,

        /// <summary>
        /// Wet Pound
        /// </summary>
        WB,

        /// <summary>
        /// Cord
        /// </summary>
        WCD,

        /// <summary>
        /// Wet Ton
        /// </summary>
        WE,

        /// <summary>
        /// Weber
        /// </summary>
        WEB,

        /// <summary>
        /// Week
        /// </summary>
        WEE,

        /// <summary>
        /// Wine Gallon
        /// </summary>
        WG,

        /// <summary>
        /// Wheel
        /// </summary>
        WH,

        /// <summary>
        /// Watt hour
        /// </summary>
        WHR,

        /// <summary>
        /// Weight per Square Inch
        /// </summary>
        WI,

        /// <summary>
        /// Working Month
        /// </summary>
        WM,

        /// <summary>
        /// Wrap
        /// </summary>
        WR,

        /// <summary>
        /// Standard
        /// </summary>
        WSD,

        /// <summary>
        /// Watt
        /// </summary>
        WTT,

        /// <summary>
        /// Millilitre of Water
        /// </summary>
        WW,

        /// <summary>
        /// Chain
        /// </summary>
        X1,

        /// <summary>
        /// Retinol Equivalent (RE)
        /// </summary>
        XRE,

        /// <summary>
        /// Centisimal Hahnemannian Dilution (CH)
        /// </summary>
        X_CHD,

        /// <summary>
        /// Decibar
        /// </summary>
        X_DBA,

        /// <summary>
        /// Korsakovian (K)
        /// </summary>
        X_KVN,

        /// <summary>
        /// Millesimai (LM)
        /// </summary>
        X_MLM,

        /// <summary>
        /// Mother tincture (Dry material)
        /// </summary>
        X_MTC,

        /// <summary>
        /// Nanogram
        /// </summary>
        X_NGM,

        /// <summary>
        /// Pixel per Centimetre
        /// </summary>
        X_PPC,

        /// <summary>
        /// Pixel per Inch
        /// </summary>
        X_PPI,

        /// <summary>
        /// Serving
        /// </summary>
        X_SER,

        /// <summary>
        /// Sample per Second
        /// </summary>
        X_SPS,

        /// <summary>
        /// Square Yard
        /// </summary>
        YDK,

        /// <summary>
        /// Cubic Yard
        /// </summary>
        YDQ,

        /// <summary>
        /// Hundred Linear Yard
        /// </summary>
        YL,

        /// <summary>
        /// Yard
        /// </summary>
        YRD,

        /// <summary>
        /// Ten Yard
        /// </summary>
        YT,

        /// <summary>
        /// Lift Van
        /// </summary>
        Z1,

        /// <summary>
        /// Chest
        /// </summary>
        Z2,

        /// <summary>
        /// Cask
        /// </summary>
        Z3,

        /// <summary>
        /// Hogshead
        /// </summary>
        Z4,

        /// <summary>
        /// Lug
        /// </summary>
        Z5,

        /// <summary>
        /// Conference Point
        /// </summary>
        Z6,

        /// <summary>
        /// Newspage Agate Line
        /// </summary>
        Z8,

        /// <summary>
        /// Page
        /// </summary>
        ZP,

        /// <summary>
        /// Mutually Defined
        /// </summary>
        ZZ
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
