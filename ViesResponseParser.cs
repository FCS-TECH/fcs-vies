// ***********************************************************************
// Assembly         : FCS.Lib.Vies
// Author          : fhdk
// Created          : 2023 01 19 10:41
// 
// Last Modified By: fhdk
// Last Modified On : 2023 03 14 09:16
// ***********************************************************************
// <copyright file="ViesResponseParser.cs" company="FCS">
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

using System;
using System.Linq;
using System.Xml.Linq;

namespace FCS.Lib.Vies;

/// <summary>
/// Vies http response parser
/// </summary>
public class ViesResponseParser
{
    /// <summary>
    /// Parser
    /// </summary>
    /// <param name="responseData"></param>
    /// <returns>Vies Entity Model parsed from XML data</returns>
    /// <see cref="ViesEntityModel"/>
    public ViesEntityModel ParseViesResponse(string responseData)
    {
        var xml = XDocument.Parse(responseData);

        var x = xml.Descendants().Where(c => c.Name.LocalName == "checkVatResponse")
            .Select(x => new ViesEntityModel
            {
                CountryCode = (string)x.Element(x.Name.Namespace + "countryCode"),
                VatNumber = (string)x.Element(x.Name.Namespace + "vatNumber"),
                RequestDate = DateTime.Now,
                Valid = (bool)x.Element(x.Name.Namespace + "valid"),
                Name = (string)x.Element(x.Name.Namespace + "name") ?? "",
                Address = (string)x.Element(x.Name.Namespace + "address") ?? ""
            }).FirstOrDefault();
        return x;
    }
}