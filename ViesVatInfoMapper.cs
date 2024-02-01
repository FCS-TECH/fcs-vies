// ***********************************************************************
// Assembly         : FCS.Lib.Vies
// Author           : 
// Created          : 2023-10-02
// 
// Last Modified By : root
// Last Modified On : 2023-10-13 07:33
// ***********************************************************************
// <copyright file="ViesVatInfoMapper.cs" company="FCS">
//     Copyright (C) 2015 - 2023 FCS Frede's Computer Service.
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
using System.Globalization;
using FCS.Lib.Common;

namespace FCS.Lib.Vies;

/// <summary>
///     Vies vat info mapper
/// </summary>
public class ViesVatInfoMapper
{
    /// <summary>
    ///     map vies response to Crm
    /// </summary>
    /// <param name="viesEntity"></param>
    /// <returns>Vat Info Data Transfer Object</returns>
    /// <see cref="VatInfoDto" />
    /// <see cref="ViesEntityModel" />
    /// <see cref="VatState" />
    /// <see cref="TimeFrame" />
    public VatInfoDto MapViesVatInfoDto(ViesEntityModel viesEntity)
    {
        var addressBlock = viesEntity.Address.Split('\n');
        var coName = "";
        var address = "";
        var zip = "";
        var city = "";
        var i = 0;
        if (viesEntity.CountryCode == "SE" && addressBlock.Length > 0)
        {
            if (addressBlock.Length > 1)
            {
                coName = addressBlock[i];
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
                coName = addressBlock[i].Normalize();
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