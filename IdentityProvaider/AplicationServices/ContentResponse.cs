namespace IdentityProvaider.API.AplicationServices
{
    public class ContentResponse
    {
        public string state { get; set; }
        public object data { get; set; }
        public string message { get; set; }

        public static ContentResponse createResponse(Boolean isSucess, string messsage, object? data)
        {
            ContentResponse response = new ContentResponse();
            response.state = isSucess ? "SUCCESS" : "ERROR";
            response.message = messsage;
            response.data = data;
            return response;
        }
    }
}