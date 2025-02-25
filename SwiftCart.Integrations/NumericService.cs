using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCart.Integrations
{
    public class NumericService {
        public static string NumberToWords(decimal number) {
            var binding = new BasicHttpsBinding();
            var endpoint = new EndpointAddress("https://www.dataaccess.com/webservicesserver/NumberConversion.wso");
            var factory = new ChannelFactory<INumberConversion>(binding, endpoint);
            var client = factory.CreateChannel();

            string words = client.NumberToDollars(number);
            return words;
        }
    }

    [ServiceContract(Namespace = "http://www.dataaccess.com/webservicesserver/")]
    public interface INumberConversion {
        [OperationContract]
        string NumberToWords(int ubiNum);

        [OperationContract]
        string NumberToDollars(decimal dNum);
    }
}
