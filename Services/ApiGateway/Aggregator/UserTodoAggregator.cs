using ApiGateway.Entities;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;

namespace ApiGateway.Aggregator;

public class UserTodoAggregator : IDefinedAggregator
{
    public async Task<DownstreamResponse> Aggregate(List<HttpContext> responseHttpContexts)
    {
        var responses = responseHttpContexts.Select(x => x.Items.DownstreamResponse()).ToArray();

        var userResponse = responses[0];
        var todoResponse = responses[1];

        var userContent = await userResponse.Content.ReadAsStringAsync();
        var users = JsonConvert.DeserializeObject<List<User>>(userContent);

        var todoContent = await todoResponse.Content.ReadAsStringAsync();
        var todos = JsonConvert.DeserializeObject<List<Todo>>(todoContent);

        if (users != null && todos != null)
        {
            foreach (var user in users)
            {
                user.Todos.AddRange(todos.Where(t => t.UserId == user.Id));
            }
        }

        return new DownstreamResponse(
            new StringContent(JsonConvert.SerializeObject(users), System.Text.Encoding.UTF8, "application/json"),
            HttpStatusCode.OK,
            responses.SelectMany(x => x.Headers).ToList(),
            "reason");
    }
}
