using ibsgateway831;
using Nancy;

namespace CoreNancySelfHostedNet.Modules
{
    public class Home : NancyModule
    {
        public Home()
        {
            GatewayClass gw = new GatewayClass();

            Get("/", (p) =>
            {
                gw.setpath("D:\\Apps\\Infusion\\--DEMO--");
                gw.login("Test Program");

                return View["index.html"];
            });

            Get("/customers", (p) =>
            {
                gw.setpath("D:\\Apps\\Infusion\\--DEMO--");
                gw.login("Test Program");

                gw.Open("Customer", "all_customers");
                gw.Select("all_customers");
                var count = gw.Reccount();

                return Response.AsJson(new
                {
                    totalCount = count
                });
            });
        }
    }
}
