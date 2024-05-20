using MediatR;
using News.Application.Common.Defines;
using News.Domain;
using System.Net;
using System.Text.Json;

namespace News.Application.News.Queries.GetNews
{
    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, New>
    {
        public async Task<New> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            var news = new New();

            var url = "https://newsapi.org/v2/top-headlines?";

            if (request.Language != null)
            {
                url += $"country={request.Language}&";

                news.Language = request.Language;
            }
                
            if (request.Keyword != null)
            {
                url += $"q={request.Keyword}&";

                news.Keyword = request.Keyword;
            }
                
            url += $"apiKey={request.ApiKey}";

            try
            {
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;

                webRequest.UserAgent = "NewsApplication";

                string json;

                using (HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(webResponse.GetResponseStream());

                    json = reader.ReadToEnd();
                }

                using (var jsonDocument = JsonDocument.Parse(json))
                {
                    news.Title = jsonDocument
                        .RootElement
                        .GetProperty("articles")[request.NewsNumber]
                        .GetProperty(NewsAnalysysKeysDefine.Title)
                        .ToString();

                    news.Description = jsonDocument
                        .RootElement
                        .GetProperty("articles")[request.NewsNumber]
                        .GetProperty(NewsAnalysysKeysDefine.Description)
                        .ToString();

                    news.Content = jsonDocument
                        .RootElement
                        .GetProperty("articles")[request.NewsNumber]
                        .GetProperty(NewsAnalysysKeysDefine.Content)
                        .ToString();
                }

                return news;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return null;
            }
        }
    }
}
