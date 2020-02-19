using System;
using System.Linq;
using Nancy;
using Nancy.ModelBinding;

namespace CoreNancySelfHostedNet.Modules
{
    public class Auth : NancyModule
    {
        public Auth() : base("auth")
        {
            // post route with custom headers
            Post("/custom", (args) => {
                Console.WriteLine(args);
                Console.WriteLine(this.Request.Headers.Authorization);

                string xToken = this.Request.Headers["x-token"].FirstOrDefault();
                string xKey = this.Request.Headers["x-key"].FirstOrDefault();

                var xAuth = this.BindTo(
                    new
                    {
                        XToken = xToken,
                        XKey = xKey
                    }
                );

                return Response.AsJson(xAuth)
                    .WithHeader("Foo", "Bar");
            });

            // The Post["/login"] method is used mainly to fetch the api key for subsequent calls
            Post("/login", args =>
            {
                var apiKey = UserDatabase.ValidateUser(
                    (string)this.Request.Form.Username,
                    (string)this.Request.Form.Password);

                return string.IsNullOrEmpty(apiKey)
                    ? new Response { StatusCode = HttpStatusCode.Unauthorized }
                    : this.Response.AsJson(new { ApiKey = apiKey });
            });
        }
    }
}
