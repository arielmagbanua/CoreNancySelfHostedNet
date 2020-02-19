using System;
using CoreNancySelfHostedNet.Models;
using Nancy;
using Nancy.Security;

namespace CoreNancySelfHostedNet.Modules
{
    class SecureModule : NancyModule
    {
        //by this time, the api key should have already been pulled out of our querystring
        //and, using the api key, an identity assigned to our NancyContext
        public SecureModule() : base("secure")
        {
            this.RequiresAuthentication();

            Get("/", args =>
            {
                //Context.CurrentUser was set by StatelessAuthentication earlier in the pipeline
                var identity = this.Context.CurrentUser;

                //return the secure information in a json response
                var userModel = new User(identity.Identity.Name);
                return this.Response.AsJson(new
                {
                    SecureContent = "here's some secure content that you can only see if you provide a correct apiKey",
                    User = userModel
                });
            });

            Post("/create_user", args =>
            {
                Tuple<string, string> user = UserDatabase.CreateUser(this.Context.Request.Form["username"],
                    this.Context.Request.Form["password"]);
                return this.Response.AsJson(new {username = user.Item1});
            });
        }
    }
}
