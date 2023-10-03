// ***********************************************************************
// Assembly         : FCS.Lib.Vies
// Author           : 
// Created          : 2023 10 01 11:03
// 
// Last Modified By : root
// Last Modified On : 2023 10 02 15:23
// ***********************************************************************
// <copyright file="ViesQueryValidator.cs" company="FCS">
//     Copyright (C) 2023-2023 FCS Frede's Computer Services.
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Affero General Public License as
//     published by the Free Software Foundation, either version 3 of the
//     License, or (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Affero General Public License for more details.
// 
//     You should have received a copy of the GNU Affero General Public License
//     along with this program.  If not, see [https://www.gnu.org/licenses]
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace FCS.Lib.Vies;

/// <summary>
///     Vies Query Validator
/// </summary>
public static class ViesQueryValidator
{
    /// <summary>
    ///     Validate Vies query
    /// </summary>
    /// <param name="query"></param>
    /// <returns>bool indicating valid query</returns>
    /// <see cref="ViesQuery" />
    public static bool ValidateViesQuery(ViesQuery query)
    {
        return !string.IsNullOrWhiteSpace(query.VatNumber) && !string.IsNullOrWhiteSpace(query.CountryCode);
    }
}