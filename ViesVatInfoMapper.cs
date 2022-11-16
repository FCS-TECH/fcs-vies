// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="VrCvrMapper.cs" company="FCS">
//    Copyright (C) 2022 FCS Frede's Computer Services.
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the Affero GNU General Public License as
//    published by the Free Software Foundation, either version 3 of the
//    License, or (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    Affero GNU General Public License for more details.
//
//    You should have received a copy of the Affero GNU General Public License
//    along with this program.  If not, see [https://www.gnu.org/licenses/agpl-3.0.en.html]
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Globalization;
using FCS.Lib.Common;

namespace FCS.Lib.Vies
{
    /// <summary>
    /// Vies vat info mapper
    /// </summary>
    public class ViesVatInfoMapper
    {
        /// <summary>
        /// map vies response to Crm
        /// </summary>
        /// <param name="viesEntity"></param>
        /// <returns>Vat Info Data Transfer Object</returns>
        /// <see cref="VatInfoDto"/>
        /// <see cref="ViesEntityModel"/>
        /// <see cref="VatState"/>
        /// <see cref="TimeFrame"/>
        public VatInfoDto MapViesToCrm(ViesEntityModel viesEntity)
        {
            var addressBlock = viesEntity.Address.Split('\n');
            string coName;
            string address;
            string zip;
            string city;
            var i = 1;
            if (viesEntity.CountryCode == "SE" && addressBlock.Length > 0)
            {
                if (addressBlock.Length > 1)
                {
                    coName = addressBlock[i];
                    i++;
                }
                address = addressBlock[i];
                i++;
                zip = addressBlock[i].Substring(0, 6).Replace(" ", "");
                city = addressBlock[i].Substring(7).Trim();
            }
            else
            {
                if (addressBlock.Length > 1)
                {
                    coName = addressBlock[i];
                    i++;
                }
                address = addressBlock[i];
                i++;
                zip = addressBlock[i].Substring(0, 5).Replace(" ", "");
                city = addressBlock[i].Substring(5).Trim();
            }
            var c = new VatInfoDto
            {
                Name = viesEntity.Name,
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
}