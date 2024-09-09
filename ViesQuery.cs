// ***********************************************************************
// Assembly         : FCS.Lib.Vies
// Filename         : ViesQuery.cs
// Author           : Frede Hundewadt
// Created          : 2024 03 29 12:36
// 
// Last Modified By : root
// Last Modified On : 2024 04 11 13:02
// ***********************************************************************
// <copyright company="FCS">
//     Copyright (C) 2024-2024 FCS Frede's Computer Service.
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
///     Vies Query model
/// </summary>
public class ViesQuery
{
    /// <summary>
    ///     Country code for country to query
    /// </summary>
    public string CountryCode { get; set; } = "";

    /// <summary>
    ///     Vat number to query
    /// </summary>
    public string VatNumber { get; set; } = "";
}