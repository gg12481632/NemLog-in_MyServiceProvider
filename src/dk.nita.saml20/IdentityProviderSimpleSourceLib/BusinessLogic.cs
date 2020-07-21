using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IdentityProviderSimpleSourceLib
{
    public class BusinessLogic
    {
        public static bool SignIn(string SAMLRequest,string SigAlg, string Signature)
        {
            string deflatedMessage = BusinessLogicUtil.DeflateDecompress(SAMLRequest);

            //string SAMLRequest_issuerValue;
            string SAMLRequest_serviceProviderID;
            {
                XmlDocument xmlDoc_SAMLRequest = new XmlDocument();
                xmlDoc_SAMLRequest.LoadXml(deflatedMessage);
                XmlElement root = xmlDoc_SAMLRequest.DocumentElement;
                //SAMLRequest_serviceProviderID = root.Attributes["ID"]?.InnerText;

                XmlNodeList nodeList =
                    xmlDoc_SAMLRequest.GetElementsByTagName("Issuer", "urn:oasis:names:tc:SAML:2.0:assertion");
                if (nodeList.Count == 0)
                    throw new Exception($"Issuer not found in SAMLRequest");
                SAMLRequest_serviceProviderID = nodeList[0]?.InnerText;
            }
            //IdpConfig.Instance
            SPMetadata spMetaData = IdpConfig.Instance.GetSPMetadataById(SAMLRequest_serviceProviderID);
            return false;
        }
    }
}
