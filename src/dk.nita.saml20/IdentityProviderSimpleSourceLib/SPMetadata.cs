using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProviderSimpleSourceLib
{
    public class SPMetadata
    {
        public SPMetadata(string id, X509Certificate2 x509Certificate2)
        {
            _id = id;
            _x509Certificate2 = x509Certificate2;
        }

        private string _id;
        private X509Certificate2 _x509Certificate2 = null;

        public string Id { get { return _id; } }

        public X509Certificate2 GetCertificate()
        {
            return _x509Certificate2;
        }
    }
}
