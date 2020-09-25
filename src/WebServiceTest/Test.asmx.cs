using System.Net;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WebServiceTest
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Test : System.Web.Services.WebService
    {
        public TokenHeader TokenHeader { get; set; }

        [WebMethod]
        [SoapHeader("TokenHeader")]
        public string Get()
        {
            if (TokenHeader == null || TokenHeader.Token != "123")
            {
                return "Error";
            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    var data = client.DownloadData("https://api.lovelive.tools/api/SweetNothings");
                    return Encoding.UTF8.GetString(data);
                }
            }
        }
    }

    public class TokenHeader : SoapHeader
    {
        public string Token { get; set; }
    }
}
