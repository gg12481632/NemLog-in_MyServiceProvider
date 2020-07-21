using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IdentityProviderSimpleSourceLib
{
    public sealed class IdpConfig
    {
        private static readonly IdpConfig _instance = new IdpConfig();
        private static Dictionary<string, SPMetadata> _spMetadataDict = new Dictionary<string, SPMetadata>();

        public static IdpConfig Instance { 
            get {
                return _instance; 
            } 
        }

        private IdpConfig()
        {
        }

        static IdpConfig()
        {
            // read the configuration parameters from desk
            string dirName = "spmetadata";
            _spMetadataDict = new Dictionary<string, SPMetadata>();
            if(!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            string[] spMetadataFiles = Directory.GetFiles("spmetadata", "*.xml");
            foreach(string spMetaDataFilePath in spMetadataFiles)
            {
                SPMetadata spMetadata = GetSPMetadataByFileName(spMetaDataFilePath);
                _spMetadataDict.Add(spMetadata.Id, spMetadata);
            }
        }

        public SPMetadata GetSPMetadataById(string spId)
        {
            SPMetadata spMetadata;
            bool found = _spMetadataDict.TryGetValue(spId, out spMetadata);
            if (!found) 
                throw new Exception($"service provider spId={spId} not found,");
            return spMetadata;
        }

        private static SPMetadata GetSPMetadataByFileName(string spMetaDataFilePath)
        {
            if(!File.Exists(spMetaDataFilePath))
            {
                throw new Exception($"spMetaDataFilePath={spMetaDataFilePath} does not exist");
            }

            {
                //const string METADATA = "urn:oasis:names:tc:SAML:2.0:metadata";
                const string XMLDSIG = "http://www.w3.org/2000/09/xmldsig#";
                const string METADATA = "urn:oasis:names:tc:SAML:2.0:metadata";

                XmlDocument doc = new XmlDocument();
                // load document
                {
                    doc.PreserveWhitespace = true;
                    doc.Load(spMetaDataFilePath);
                    if (!doc.PreserveWhitespace)
                        throw new InvalidOperationException(
                            "The XmlDocument must have its \"PreserveWhitespace\" property set to true when a signed document is loaded.");
                }

                // get service provider id
                string spId;
                {
                    XmlNodeList nodeList =
                        doc.GetElementsByTagName("EntityDescriptor", METADATA);
                    if (nodeList.Count == 0)
                        throw new Exception($"EntityDescriptor in ${spMetaDataFilePath} not found");

                    XmlNode entityDescriptorNode = nodeList[0];
                    spId = entityDescriptorNode.Attributes["entityID"]?.InnerText;
                    //spId = BusinessLogicUtil.GetMd5HashedSPEntityId(spId);
                }


                // Get the signedXml
                SignedXml signedXml;
                {
                    signedXml = new SignedXml(doc.DocumentElement);
                    XmlNodeList nodeList = doc.GetElementsByTagName("Signature", XMLDSIG);
                    if (nodeList.Count == 0)
                        throw new InvalidOperationException("The XmlDocument does not contain a signature.");
                    signedXml.LoadXml((XmlElement)nodeList[0]);
                }

                // Get the public key required to verify the signing
                X509Certificate2 x509Certificate;
                {
                    XmlNodeList nodeList =
                        doc.GetElementsByTagName("X509Certificate");
                    if (nodeList.Count == 0)
                        throw new Exception($"X509Certificate in ${spMetaDataFilePath} not found");
                    XmlNode x509CertificateNode = nodeList[0];
                    string encodedX509Certificate = x509CertificateNode.InnerText;
                    byte[] bytes = Convert.FromBase64String(encodedX509Certificate);
                    x509Certificate = new X509Certificate2(bytes);
                }

                // verify signatury
                AsymmetricAlgorithm key = x509Certificate.PublicKey.Key;
                if (!signedXml.CheckSignature(key))
                    throw new Exception("Signing verification failed");

                return new SPMetadata(spId, x509Certificate);
            }
        }
    }
}
/*
<?xml version="1.0"?>
<FileConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <BaseUrl>https://oiosaml-demoidp.dk:20001/</BaseUrl>
  <certThumbPrint>7AD6A798E0D0A14B1746137CD86A5930356D97EF</certThumbPrint>
  <certLocation>LocalMachine</certLocation>
  <certStore>My</certStore>
</FileConfig>
*/
