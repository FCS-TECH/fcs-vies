# fcs-vies

Sample controller action

```
public async Task<IHttpActionResult> GetViesData([FromUri] ViesQuery query)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    if (!ViesQueryValidator.ValidateViesQuery(query))
        return BadRequest($"invalid request");

    // vies endpoint
    var viesLookupUrl = $"{Settings.ViesLookupUrl}";

    // execute request
    var viesReqest = new ViesHttpRequest();
    var viesResponseView = await viesReqest.GetResponseAsync(viesLookupUrl, query.CountryCode, query.vatNumber);

    // intermediate parser
    var viesParser = new ViesResponseParser();
    var viesEntity = viesParser.ParseViesResponse(viesResponseView.Message);

    // return result
    return Ok(viesEntity);
}
```