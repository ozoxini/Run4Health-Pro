public const string OPENWEATHERMAP_API_KEY = "253b69f48d254853f3ebd6329b7f12d3";
public const string BASE_URL = "https://api.openweathermap.org/data/2.5/onecall?lat={0}&lon={1}&units={2}&appid={3}";
public static async Task<OneCallAPI> GetOneCallAPIAsync(double lat, double lon, string units)
{
    OneCallAPI weather = new OneCallAPI();
    string url = String.Format(BASE_URL, lat, lon, units, OPENWEATHERMAP_API_KEY);
    HttpClient httpClient = new HttpClient();
    var response = await httpClient.GetAsync(url);
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        var posts = JsonConvert.DeserializeObject<OneCallAPI>(content);
        weather = posts;
    }
    return weather;
}