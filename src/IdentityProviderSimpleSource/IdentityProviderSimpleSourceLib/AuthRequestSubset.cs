using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProviderSimpleSourceLib
{
    public class AuthRequestSubset
    {
        public AuthRequestSubset(string entityId, X509Certificate2 x509Certificate2)
        {
            _entityId = entityId;
            _x509Certificate2 = x509Certificate2;
        }

        public bool? ForceAuth { get {return _forceAuth; } }

        private string _entityId;
        private bool? _forceAuth;
        private X509Certificate2 _x509Certificate2 = null;

        public string EntityId { get { return _entityId; } }

        public X509Certificate2 GetCertificate()
        {
            return _x509Certificate2;
        }
    }
}
