// ***********************************************************************
// Assembly         : FCS.Lib.Vies
// Author           : FH
// Created          : 04-01-2022
//
// Last Modified By : FH
// Last Modified On : 04-01-2022
// ***********************************************************************
// <copyright file="ViesEntityModel.cs" company="">
//    Copyright (C) 2022 FCS Frede's Computer Services.
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Affero General Public License as
//    published by the Free Software Foundation, either version 3 of the
//    License, or (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Affero General Public License for more details.
//
//    You should have received a copy of the GNU Affero General Public License
//    along with this program.  If not, see [https://www.gnu.org/licenses]
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace FCS.Lib.Vies;

/// <summary>
/// Vies Entity Model
/// </summary>
public class ViesEntityModel
{
    /// <summary>
    /// Business entity's country code of origin
    /// </summary>
    public string CountryCode { get; set; } = "";
    /// <summary>
    /// Business entity vat number
    /// </summary>
    public string VatNumber { get; set; } = "";
    /// <summary>
    /// Request date
    /// </summary>
    public DateTime RequestDate { get; set; }
    /// <summary>
    /// Valid flag
    /// </summary>
    public bool Valid { get; set; }
    /// <summary>
    /// Business entity name
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// Business entity address
    /// </summary>
    public string Address { get; set; } = "";
}