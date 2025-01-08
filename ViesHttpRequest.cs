// // ***********************************************************************
// // Solution         : Inno.Api.v2
// // Assembly         : FCS.Lib.Vies
// // Filename         : ViesHttpRequest.cs
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

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FCS.Lib.Common;

namespace FCS.Lib.Vies;

/// <summary>
///     Represents an HTTP request handler for interacting with the VIES (VAT Information Exchange System) service.
///     This class provides functionality to send requests and retrieve responses for validating VAT numbers
///     across European Union member states.
/// </summary>
public class ViesHttpRequest
{
    /// <summary>
    ///     Sends an asynchronous HTTP request to the VIES (VAT Information Exchange System) service to validate a VAT number.
    /// </summary>
    /// <param name="endpoint">
    ///     The URL of the VIES service endpoint to which the request will be sent.
    /// </param>
    /// <param name="countryCode">
    ///     The country code associated with the VAT number, in ISO 3166-1 alpha-2 format.
    /// </param>
    /// <param name="vatNumber">
    ///     The VAT number to be validated.
    /// </param>
    /// <param name="userAgent">
    ///     The User-Agent string to include in the HTTP request headers.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains an <see cref="HttpResponseView" />
    ///     object
    ///     with details of the HTTP response, including the status code, success status, and response message.
    /// </returns>
    /// <remarks>
    ///     This method constructs a SOAP request to the VIES service and sends it using an HTTP POST request. The response
    ///     from the service is parsed and returned as an <see cref="HttpResponseView" /> object.
    /// </remarks>
    /// <exception cref="HttpRequestException">
    ///     Thrown if there is an error while sending the HTTP request or receiving the response.
    /// </exception>
    public async Task<HttpResponseView> GetResponseAsync(string endpoint, string countryCode, string vatNumber,
        string userAgent)
    {
        // <remarks>Service http://ec.europa.eu/taxation_customs/vies/services/checkVatService</remarks>
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