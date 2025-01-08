// // ***********************************************************************
// // Solution         : Inno.Api.v2
// // Assembly         : FCS.Lib.Vies
// // Filename         : ViesQuery.cs
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

namespace FCS.Lib.Vies;

/// <summary>
///     Represents a query to the VIES (VAT Information Exchange System) for validating VAT numbers.
/// </summary>
/// <remarks>
///     This class is used to encapsulate the details of a VIES query, including the country code and VAT number.
/// </remarks>
/// <example>
///     Example usage:
///     <code>
/// var query = new ViesQuery
/// {
///     CountryCode = "DE",
///     VatNumber = "123456789"
/// };
/// </code>
/// </example>
public class ViesQuery
{
    /// <summary>
    ///     Gets or sets the two-letter country code associated with the VAT number.
    /// </summary>
    /// <value>
    ///     A string representing the ISO 3166-1 alpha-2 country code.
    /// </value>
    /// <remarks>
    ///     This property is used to specify the country for which the VAT number is being validated.
    /// </remarks>
    /// <example>
    ///     Example usage:
    ///     <code>
    /// var query = new ViesQuery
    /// {
    ///     CountryCode = "FR",
    ///     VatNumber = "987654321"
    /// };
    /// </code>
    /// </example>
    public string CountryCode { get; set; } = "";

    /// <summary>
    ///     Gets or sets the VAT number to be validated through the VIES system.
    /// </summary>
    /// <value>
    ///     A <see cref="string" /> representing the VAT number associated with the query.
    /// </value>
    /// <remarks>
    ///     The VAT number should conform to the format required by the respective country's VAT system.
    /// </remarks>
    /// <example>
    ///     Example usage:
    ///     <code>
    /// var query = new ViesQuery
    /// {
    ///     CountryCode = "DE",
    ///     VatNumber = "123456789"
    /// };
    /// </code>
    /// </example>
    public string VatNumber { get; set; } = "";
}