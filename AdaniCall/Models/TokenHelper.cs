using Azure;
using Azure.Communication;
using Azure.Communication.Identity;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace AdaniCall.Models
{
    public class TokenHelper
    {
        string endpoint = "https://callingdemo.communication.azure.com";
        string accessKey = "GRbNMjPMNqrjrLyMYJrmO4H8dlqwGvea9POVVRubbWuuMTahZ8aWK7eRSHK2v+7HFPokLk9RFZcOiZMPjlqtIg==";
        public AccessToken RefreshTokenAsync(string userCallID)
        {
            var client = new CommunicationIdentityClient(new Uri(endpoint), new AzureKeyCredential(accessKey));

            ////To refresh an access token, pass an instance of the CommunicationUserIdentifier object into GetTokenAsync. If you've stored this Id and need to create a new CommunicationUserIdentifier, you can do so by passing your stored Id into the CommunicationUserIdentifier constructor as follows:
            var identityToRefresh = new CommunicationUserIdentifier(userCallID);
            return client.GetToken(identityToRefresh, scopes: new[] { CommunicationTokenScope.VoIP });
        }
    }
}