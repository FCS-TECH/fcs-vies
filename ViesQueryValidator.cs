// // ***********************************************************************
// // Solution         : Inno.Api.v2
// // Assembly         : FCS.Lib.Vies
// // Filename         : ViesQueryValidator.cs
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
///     Provides validation utilities for VIES (VAT Information Exchange System) queries.
/// </summary>
/// <remarks>
///     This static class contains methods to validate the essential fields of a VIES query,
///     ensuring that the VAT number and country code are properly populated before processing.
/// </remarks>
/// <example>
///     Example usage:
///     <code>
/// var query = new ViesQuery
/// {
///     CountryCode = "IT",
///     VatNumber = "123456789"
/// };
/// bool isValid = ViesQueryValidator.ValidateViesQuery(query);
/// </code>
/// </example>
public static class ViesQueryValidator
{
    /// <summary>
    ///     Validates the specified VIES query by checking if the VAT number and country code are not null, empty, or
    ///     whitespace.
    /// </summary>
    /// <param name="query">The <see cref="ViesQuery" /> object containing the VAT number and country code to validate.</param>
    /// <returns>
    ///     <c>true</c> if both the VAT number and country code are valid (not null, empty, or whitespace); otherwise,
    ///     <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if the <paramref name="query" /> parameter is <c>null</c>.
    /// </exception>
    /// <remarks>
    ///     This method ensures that the essential fields required for a VIES query are properly populated.
    /// </remarks>
    /// <example>
    ///     Example usage:
    ///     <code>
    /// var query = new ViesQuery
    /// {
    ///     CountryCode = "FR",
    ///     VatNumber = "987654321"
    /// };
    /// bool isValid = ViesQueryValidator.ValidateViesQuery(query);
    /// </code>
    /// </example>
    public static bool ValidateViesQuery(ViesQuery query)
    {
        return !string.IsNullOrWhiteSpace(query.VatNumber) && !string.IsNullOrWhiteSpace(query.CountryCode);
    }
}