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
namespace FCS.Lib.Vies.Models;

public class ViesEntityModel
{
    public string CountryCode { get; set; }
    public string VatNumber { get; set; }
    public string RequestDate { get; set; }
    public bool Valid { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}