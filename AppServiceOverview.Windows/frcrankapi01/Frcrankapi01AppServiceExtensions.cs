using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace AppServiceOverview.Windows.FrcRank
{
    public static class Frcrankapi01AppServiceExtensions
    {
        public static Frcrankapi01 CreateFrcrankapi01(this IAppServiceClient client)
        {
            return new Frcrankapi01(client.CreateHandler());
        }

        public static Frcrankapi01 CreateFrcrankapi01(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new Frcrankapi01(client.CreateHandler(handlers));
        }

        public static Frcrankapi01 CreateFrcrankapi01(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new Frcrankapi01(uri, client.CreateHandler(handlers));
        }

        public static Frcrankapi01 CreateFrcrankapi01(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new Frcrankapi01(rootHandler, client.CreateHandler(handlers));
        }
    }
}
