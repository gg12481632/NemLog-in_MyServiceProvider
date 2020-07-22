namespace IdentityProviderSimpleSourceLib
{
    public class AuthnRequest
    {
		private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

		private string _issuerValue;// path = issuer/value

        public string IssuerValue
        {
            get { return _issuerValue; }
            set { _issuerValue = value; }
        }

		private bool? _forceAuth;// path = issuer/value

        public bool? ForceAuthn
        {
            get { return _forceAuth; }
            set { _forceAuth = value; }
        }

		// and a lot of other stuff not being used
    }
}