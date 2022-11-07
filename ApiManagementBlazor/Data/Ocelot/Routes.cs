namespace ApiManagementBlazor.Data.Ocelot
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AuthenticationOptions
    {
        public string AuthenticationProviderKey { get; set; }
    }

    public class DownstreamHostAndPort
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public class GlobalConfiguration
    {
        public string BaseUrl { get; set; }
    }

    public class Root
    {
        public List<Route> Routes { get; set; }
        public GlobalConfiguration GlobalConfiguration { get; set; }
    }

    public class Route
    {
        public string UpstreamPathTemplate { get; set; }
        public List<string> UpstreamHttpMethod { get; set; }
        public string DownstreamScheme { get; set; }
        public List<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }
        public string DownstreamPathTemplate { get; set; }
        public AuthenticationOptions AuthenticationOptions { get; set; }
    }


}
