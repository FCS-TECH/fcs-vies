// ***********************************************************************
//  Solution         : Inno.Api.v2
//  Assembly         : FCS.Lib.Vies
//  Filename         : ViesVatInfoMapper.cs
//  Created          : 2025-01-03 14:01
//  Last Modified By : dev
//  Last Modified On : 2025-01-08 13:01
//  ***********************************************************************
//  <copyright company="Frede Hundewadt">
//      Copyright (C) 2010-2025 Frede Hundewadt
//      This program is free software: you can redistribute it and/or modify
//      it under the terms of the GNU Affero General Public License as
//      published by the Free Software Foundation, either version 3 of the
//      License, or (at your option) any later version.
// 
//      This program is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//      GNU Affero General Public License for more details.
// 
//      You should have received a copy of the GNU Affero General Public License
//      along with this program.  If not, see [https://www.gnu.org/licenses]
//  </copyright>
//  <summary></summary>
//  ***********************************************************************

using System;
using System.Globalization;
using FCS.Lib.Common;

namespace FCS.Lib.Vies;

/// <summary>
///     Provides functionality to map VAT information from a <see cref="ViesEntityModel" /> to a <see cref="VatInfoDto" />.
/// </summary>
/// <remarks>
///     This class is responsible for transforming VAT-related data from the VIES system into a structured format
///     suitable for further processing or consumption by other components.
/// </remarks>
public class ViesVatInfoMapper
{
    /// <summary>
    ///     Maps a <see cref="ViesEntityModel" /> to a <see cref="VatInfoDto" /> object.
    /// </summary>
    /// <param name="viesEntity">The source entity containing VAT information to be mapped.</param>
    /// <returns>
    ///     A <see cref="VatInfoDto" /> object populated with the mapped data from the provided
    ///     <see cref="ViesEntityModel" />.
    /// </returns>
    public VatInfoDto MapViesVatInfoDto(ViesEntityModel viesEntity)
    {
        var addressBlock = viesEntity.Address.Split('\n');
        string address;
        var zip = "";
        var city = "";
        var i = 0;
        if (viesEntity.CountryCode == "SE" && addressBlock.Length > 0)
        {
            if (addressBlock.Length > 1) i++;

            try
            {
                address = addressBlock[i].Normalize();
            }
            catch
            {
                address = "fejl";
            }

            if (addressBlock.Length > 2)
            {
                i++;
                zip = addressBlock[i].Normalize().Substring(0, 6).Replace(" ", "");
                city = addressBlock[i].Normalize().Substring(7).Trim();
            }
        }
        else
        {
            if (addressBlock.Length > 1)
            {
                addressBlock[i].Normalize();
                i++;
            }

            try
            {
                address = addressBlock[i].Normalize();
            }
            catch
            {
                address = "fejl";
            }

            if (addressBlock.Length > 1)
            {
                i++;
                zip = addressBlock[i].Substring(0, 5).Replace(" ", "");
                city = addressBlock[i].Substring(5).Trim();
            }
        }

        // generate return object
        var c = new VatInfoDto
        {
            Name = viesEntity.Name.Normalize(),
            Address = address,
            VatNumber = viesEntity.VatNumber,
            City = city,
            ZipCode = zip,
            RequestDate = DateTime.Now.ToString(CultureInfo.InvariantCulture)
        };

        c.States.Add(new VatState
        {
            State = viesEntity.Valid ? "NORMAL" : "LUKKET",
            LastUpdate = $"{viesEntity.RequestDate:yyyy-MM-dd}",
            TimeFrame = new TimeFrame
            {
                EndDate = "NA",
                StartDate = "NA"
            }
        });
        c.LifeCycles.Add(new LifeCycle
        {
            LastUpdate = $"{viesEntity.RequestDate:yyyy-MM-dd}",
            TimeFrame = new TimeFrame
            {
                StartDate = "NN",
                EndDate = "NN"
            }
        });
        return c;
    }
}