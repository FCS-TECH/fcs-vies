# fcs-vies

Sample controller action

```
public async Task<IHttpActionResult> GetViesData([FromUri] ViesQuery query)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    if (!ViesQueryValidator.ValidateViesQuery(query))
        return BadRequest($"invalid request");

    var endpoint = $"{Settings.ViesLookupUrl}"
    var userAgent = $"{Settings.UserAgent}"
    
    // execute request
    var viesReqest = new ViesHttpRequest();
    var viesResponseView = await viesReqest.GetResponseAsync(endpoint, query.CountryCode, query.vatNumber, userAgent);

    // intermediate parser
    var viesParser = new ViesResponseParser();
    var viesEntity = viesParser.ParseViesResponse(viesResponseView.Message);

    // return result
    return Ok(viesEntity);
}
```