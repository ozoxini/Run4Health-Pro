public class WeatherViewModel
{
    private IList<OneCallAPI> _weatherList;
    public IList<OneCallAPI> WeatherList
    {
        get
        {
            if (_weatherList == null)
                _weatherList = new ObservableCollection<OneCallAPI>();
            return _weatherList;
        }
        set
        {
            _weatherList = value;
        }
    }

    private async Task APIAsync()
    {
        var weather = await WeatherAPI.GetOneCallAPIAsync(41.008240, 28.978359, "metric");
        //    var weather = await WeatherAPI.GetFiveDaysAsync("Istanbul");
        WeatherList.Add(weather);
    }

    public WeatherViewModel()
    {
        Task.Run(APIAsync);
    }
}