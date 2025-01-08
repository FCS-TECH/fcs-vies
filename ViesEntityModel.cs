// // ***********************************************************************
// // Solution         : Inno.Api.v2
// // Assembly         : FCS.Lib.Vies
// // Filename         : ViesEntityModel.cs
// // Created          : 2025-01-03 14:01
// // Last Modified By : dev
// // Last Modified On : 2025-01-04 12:01
// // ***********************************************************************
// // <copyright company="Frede Hundewadt">
// //     Copyright (C) 2010-2025 Frede Hundewadt
// //     This program is free software: you can redistribute it and/or modify
// //     it under the terms of the GNU Affero General Public License as
// //     published by the Free Software Foundation, either version 3 of the
// //     License, or (at your option) any later version.
// //
// //     This program is distributed in the hope that it will be useful,
// //     but WITHOUT ANY WARRANTY; without even the implied warranty of
// //     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// //     GNU Affero General Public License for more details.
// //
// //     You should have received a copy of the GNU Affero General Public License
// //     along with this program.  If not, see [https://www.gnu.org/licenses]
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

using System;

namespace FCS.Lib.Vies;

/// <summary>
///     Represents a model for VIES (VAT Information Exchange System) entity data.
/// </summary>
/// <remarks>
///     This class encapsulates information retrieved from the VIES system, including
///     country code, VAT number, request date, validity status, name, and address.
///     It is used as a data transfer object for parsing and mapping VIES responses.
/// </remarks>
public class ViesEntityModel
{
    /// <summary>
    ///     Gets or sets the ISO 3166-1 alpha-2 country code associated with the VAT entity.
    /// </summary>
    /// <remarks>
    ///     This property represents the country code of the VAT entity as retrieved from the VIES system.
    ///     It is used to identify the country of origin for the VAT number.
    /// </remarks>
    public string CountryCode { get; set; } = "";

    /// <summary>
    ///     Gets or sets the VAT (Value Added Tax) number associated with the entity.
    /// </summary>
    /// <remarks>
    ///     The VAT number is used for identifying the entity within the VIES (VAT Information Exchange System).
    ///     It is typically combined with the <see cref="CountryCode" /> to form a complete VAT identifier.
    /// </remarks>
    public string VatNumber { get; set; } = "";

    /// <summary>
    ///     Gets or sets the date and time when the VIES request was made.
    /// </summary>
    /// <remarks>
    ///     This property represents the timestamp of the VIES request, indicating when the VAT information
    ///     was queried. It is typically set to the current date and time during the parsing or mapping process.
    /// </remarks>
    public DateTime RequestDate { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the VAT number is valid according to the VIES system.
    /// </summary>
    /// <value>
    ///     <c>true</c> if the VAT number is valid; otherwise, <c>false</c>.
    /// </value>
    /// <remarks>
    ///     This property reflects the validity status of a VAT number as determined by the VIES system.
    ///     It is typically populated based on the response from the VIES service.
    /// </remarks>
    public bool Valid { get; set; }

    /// <summary>
    ///     Gets or sets the name of the entity associated with the VAT number.
    /// </summary>
    /// <remarks>
    ///     This property represents the name of the entity as retrieved from the VIES system.
    ///     It is typically used to identify the company or organization linked to the VAT number.
    /// </remarks>
    public string Name { get; set; } = "";

    /// <summary>
    ///     Gets or sets the address associated with the VIES entity.
    /// </summary>
    /// <remarks>
    ///     This property contains the address information retrieved from the VIES system.
    ///     It may include multiple lines of text, separated by newline characters, and is used
    ///     for further processing or mapping to other data transfer objects.
    /// </remarks>
    public string Address { get; set; } = "";
}