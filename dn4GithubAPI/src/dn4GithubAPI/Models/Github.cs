using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dn4GithubAPI.Models
{
    public class Github
    {
        public int stargazers_count { get; set; }


        public static JObject GetStarredRepos()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/search/repositories?q=user:aglines-epicodus&sort=stars&order=desc", Method.GET);
            request.AddHeader("User-Agent", "aglines-epicodus");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);

            return jsonResponse;
        }




        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}
