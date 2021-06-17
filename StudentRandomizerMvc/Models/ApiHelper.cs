using System.Threading.Tasks;
using RestSharp;

namespace StudentRandomizerMvc.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll(string route)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{route}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(string route, int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{route}/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Post(string route, string newObject)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{route}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newObject);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Put(string route, int id, string newObject)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{route}/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newObject);
      await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(string route, int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{route}/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> GetJoin(string route, int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{route}/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostJoin(string route, int id, string joinObject)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{route}/{id}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(joinObject);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteJoin(string route, int id, string otherRoute, int otherId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{route}/{id}/{otherRoute}/{otherId}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> GetAllByForeignKey(string route, int otherId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{route}/{otherId}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}