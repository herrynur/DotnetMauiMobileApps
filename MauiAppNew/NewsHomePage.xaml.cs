using MauiAppNew.Model;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace MauiAppNew
{
	public partial class NewsHomePage : ContentPage
	{
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;

        public NewsHomePage()
		{
            InitializeComponent();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.All
            };
            _client = new HttpClient(handler);
        }

        private async void OnImageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewsDetailPage());
        }

        public async Task<NewsModel> GetNewsData()
		{
			NewsModel model = new NewsModel();

			var Uri = "https://newsapi.org/v2/top-headlines?country=us&page=1&pageSize=10&apiKey=786badd122df4f7682e025cb08d12862";

			try
			{
                var response = await _client.GetAsync(Uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    model = JsonSerializer.Deserialize<NewsModel>(content, _serializerOptions);
                }
            }
			catch (Exception ex)
			{
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                throw;
			}

            return model;
		}
	}
}
