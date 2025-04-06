using System.Text.Json;
using EBookStore.DTOs;

namespace EBookStore.Services
{
    public class ExternalBookService
    {
        private readonly HttpClient _httpClient;

        public ExternalBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExternalBookDto>> SearchBooks(string searchTerm)
        {
            var response = await _httpClient.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={searchTerm}");
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GoogleBooksResponse>(json);

            return result?.Items?.Select(book => new ExternalBookDto
            {
                Title = book.VolumeInfo?.Title ?? "Ingen titel",
                Author = book.VolumeInfo?.Authors?.FirstOrDefault() ?? "Okänd",
                CoverUrl = book.VolumeInfo?.ImageLinks?.Thumbnail
            }).ToList() ?? new List<ExternalBookDto>();
        }

        private class GoogleBooksResponse
        {
            public List<GoogleBook> Items { get; set; }
        }

        private class GoogleBook
        {
            public VolumeInfo VolumeInfo { get; set; }
        }

        private class VolumeInfo
        {
            public string Title { get; set; }
            public List<string> Authors { get; set; }
            public ImageLinks ImageLinks { get; set; }
        }

        private class ImageLinks
        {
            public string Thumbnail { get; set; }
        }
    }
}