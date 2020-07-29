using IdentityProviderDemo.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyTestConsoleApp
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Debug("log is working");

            X509Certificate2 cert = IDPConfig.IDPCertificate;
            if(cert==null)
            {
                log.Debug("failure, IDPConfig.IDPCertificate returns null");
                return;
            }
            log.Debug($"success, cert loaded, Thumbprint={cert.Thumbprint}");

            try
            {
                log.Debug($"before call to cert.PrivateKey, Thumbprint={cert.Thumbprint}");
                var pkey = cert.PrivateKey;
                if(pkey != null) {
                    log.Debug($"success, private key is not null");
                }
                else
                {
                    log.Debug($"failure, private key is null");
                }

                //log.Debug($"before call to SignMetaData, Thumbprint={cert.Thumbprint}");
                //signatureProvider.SignMetaData(doc, id, cert);
                log.Debug($"done");
            }
            catch (Exception e)
            {
                log.Error($"failure, exception:" + e);
                throw;
            }


        }
    }
}
