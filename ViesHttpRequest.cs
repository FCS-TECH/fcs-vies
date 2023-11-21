// ***********************************************************************
// Assembly         : FCS.Lib.Vies
// Author           : 
// Created          : 2023-10-02
// 
// Last Modified By : root
// Last Modified On : 2023-10-13 07:33
// ***********************************************************************
// <copyright file="ViesHttpRequest.cs" company="FCS">
//     Copyright (C) 2015 - 2023 FCS Fredes Computer Service.
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

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FCS.Lib.Common;

namespace FCS.Lib.Vies;

/// <summary>
///     http request to vies registrar
/// </summary>
public class ViesHttpRequest
{
    /// <summary>
    ///     Async http request to vies registrar
    /// </summary>
    /// <param name="endpoint"></param>
    /// <param name="countryCode"></param>
    /// <param name="vatNumber"></param>
    /// <param name="userAgent"></param>
    /// <returns>Vies Response View model</returns>
    /// <see cref="HttpResponseView" />
    /// <remarks>Service http://ec.europa.eu/taxation_customs/vies/services/checkVatService</remarks>
    public async Task<HttpResponseView> GetResponseAsync(string endpoint, string countryCode, string vatNumber,
        string userAgent)
    {
        var xml = new StringBuilder();
        xml.Append(
            "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:ec.europa.eu:taxud:vies:services:checkVat:types\">");
        xml.Append("<soapenv:Header/>");
        xml.Append("<soapenv:Body>");
        xml.Append("<urn:checkVat>");
        xml.Append($"<urn:countryCode>{countryCode.ToUpperInvariant()}</urn:countryCode>");
        xml.Append($"<urn:vatNumber>{vatNumber}</urn:vatNumber>");
        xml.Append("</urn:checkVat>");
        xml.Append("</soapenv:Body>");
        xml.Append("</soapenv:Envelope>");

        using var content = new StringContent(xml.ToString(), Encoding.UTF8, "text/xml");

        using var client = new HttpClient();
        using var viesRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);
        viesRequest.Headers.Add("SOAPAction", "");
        viesRequest.Headers.Add("User-Agent", userAgent);
        viesRequest.Content = content;
        var response = await client.SendAsync(viesRequest).ConfigureAwait(true);
        var xmlResult = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

        return new HttpResponseView
        {
            Code = response.StatusCode,
            IsSuccessStatusCode = response.IsSuccessStatusCode,
            Message = xmlResult
        };
    }
}