// // ***********************************************************************
// // Solution         : Inno.Api.v2
// // Assembly         : FCS.Lib.Vies
// // Filename         : ViesResponseParser.cs
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
using System.Linq;
using System.Xml.Linq;

namespace FCS.Lib.Vies;

/// <summary>
///     Provides functionality to parse responses from the VAT Information Exchange System (VIES).
/// </summary>
/// <remarks>
///     This class is responsible for extracting and mapping data from the raw XML response provided by the VIES service.
///     It transforms the response into a structured format represented by the <see cref="ViesEntityModel" /> class.
/// </remarks>
public class ViesResponseParser
{
    /// <summary>
    ///     Parses the VIES (VAT Information Exchange System) response data and maps it to a <see cref="ViesEntityModel" />.
    /// </summary>
    /// <param name="responseData">
    ///     The raw XML response data received from the VIES service.
    /// </param>
    /// <returns>
    ///     A <see cref="ViesEntityModel" /> instance containing the parsed data, or <c>null</c> if the response is invalid or
    ///     cannot be parsed.
    /// </returns>
    /// <exception cref="System.Xml.XmlException">
    ///     Thrown when the provided <paramref name="responseData" /> is not a valid XML.
    /// </exception>
    /// <remarks>
    ///     This method extracts key information such as country code, VAT number, validity status, name, and address
    ///     from the VIES response and encapsulates it into a <see cref="ViesEntityModel" /> object.
    /// </remarks>
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