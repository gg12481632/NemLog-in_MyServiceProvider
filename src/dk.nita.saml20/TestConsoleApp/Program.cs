using System;
using System.Buffers.Text;
using System.Security.Cryptography.X509Certificates;

namespace TestConsoleApp
{
    class Program
    {
        static byte[] B64Decode(string encoded)
        {
            byte[] bytes = Convert.FromBase64String(encoded);
            return bytes;
        }

        static X509Certificate2 GetCertificate(string thumbPrint)
        {
            X509Certificate2 certificate = null;
            using (X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadOnly);
                certificate =
                    store.Certificates.Find(
                        X509FindType.FindByThumbprint,
                        findValue: thumbPrint,
                        validOnly: true)[0];
            }
            return certificate;
        }

        static void DecodeX509Certificate()
        {
            Console.WriteLine("Hello World!");
            string encoded = "MIIDGDCCAgCgAwIBAgIQYGHojnAZgq5BNkH4XckFdjANBgkqhkiG9w0BAQUFADAfMR0wGwYDVQQDDBRvaW9zYW1sIHRlc3QgZGVtb2lkcDAeFw0xNzA4MDIwOTEzMzhaFw0yOTEyMzEyMjAwMDBaMB8xHTAbBgNVBAMMFG9pb3NhbWwgdGVzdCBkZW1vaWRwMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAr9tL9VNsfnRX6GYRwKqt0ZxN66kLwy3YEsz5bKRoLpPdXmdvYh+4rC4U4JvgOhHuVbQUabuaWUqAraaW3DlgjgD5OLMNUZRCRh7DnJDEaw08FxpCP95L1TLTNZLxiu2azky24rxqCpxSxhmN/Om/aSXQkoUv+TM2O3/r4S98C738Cq/APNeEYrc591IwuywYLbWQJyGRftzUNPsSfFJr1Et/DVB8U6o6E2/lpV6CsGhnErJoZf3rj4C5ForoWph5s/FfAC0LrgPIGhRPxHrRI4DbtQj1Z/A82H4X+9xR1oPgWcEBqNbXhn/6oNOkASaVE6xxNL95YD4o82wXascXJQIDAQABo1AwTjAOBgNVHQ8BAf8EBAMCBaAwHQYDVR0lBBYwFAYIKwYBBQUHAwIGCCsGAQUFBwMBMB0GA1UdDgQWBBSIuT1t3XqMSIvJkFDJBPUH2VZl5TANBgkqhkiG9w0BAQUFAAOCAQEAmedwWGcq08Tr8IvQT4d5934pEAbG89dTdZPzHq4pBsIkxAlZQpq2FpKwhxI2j770z5roRK2kROEaavTXwF/U7LdUGQMoQFHu15/biNtwVuiCvJkzUoIpbKanCGSskYwhvQ0JWxKrnSqIl3zJvVWeBLRrvbIVCxI1X37ACkjW5J9ijOh3Ma/xg7/vFgpvs1WbZxDOLj5h2aH66qg/feOflOJDtE+SsAymFP8sJKT+rkU4Kpznl8bsd6KorptxKL+Uwr3NPVbHhS1dfACfuizEhYy7Ja61Z6YC3CTa/pFk5Wtpwo21WMFOu7d3XSdY5XJE8umPg6ZZf6/folz53M7UFg==";
            byte[] bytes = Convert.FromBase64String(encoded);
            int byteCount = bytes.Length;
            for (int i = 0; i < byteCount; i++)
            {
                if (i % 40 == 0)
                {
                    Console.WriteLine("");
                }
                byte b = bytes[i];
                Console.Write($"{b:X2}:");
                /*
                30:82:03:18:30:82:02:00:A0:03:02:01:02:02:10:60:61:E8:8E:70:19:82:AE:41:36:41:F8:5D:C9:05:76:30:0D:06:09:2A:86:48:86:F7:
                0D:01:01:05:05:00:30:1F:31:1D:30:1B:06:03:55:04:03:0C:14:6F:69:6F:73:61:6D:6C:20:74:65:73:74:20:64:65:6D:6F:69:64:70:30:
                1E:17:0D:31:37:30:38:30:32:30:39:31:33:33:38:5A:17:0D:32:39:31:32:33:31:32:32:30:30:30:30:5A:30:1F:31:1D:30:1B:06:03:55:
                04:03:0C:14:6F:69:6F:73:61:6D:6C:20:74:65:73:74:20:64:65:6D:6F:69:64:70:30:82:01:22:30:0D:06:09:2A:86:48:86:F7:0D:01:01:
                01:05:00:03:82:01:0F:00:30:82:01:0A:02:82:01:01:00:AF:DB:4B:F5:53:6C:7E:74:57:E8:66:11:C0:AA:AD:D1:9C:4D:EB:A9:0B:C3:2D:
                D8:12:CC:F9:6C:A4:68:2E:93:DD:5E:67:6F:62:1F:B8:AC:2E:14:E0:9B:E0:3A:11:EE:55:B4:14:69:BB:9A:59:4A:80:AD:A6:96:DC:39:60:
                8E:00:F9:38:B3:0D:51:94:42:46:1E:C3:9C:90:C4:6B:0D:3C:17:1A:42:3F:DE:4B:D5:32:D3:35:92:F1:8A:ED:9A:CE:4C:B6:E2:BC:6A:0A:
                9C:52:C6:19:8D:FC:E9:BF:69:25:D0:92:85:2F:F9:33:36:3B:7F:EB:E1:2F:7C:0B:BD:FC:0A:AF:C0:3C:D7:84:62:B7:39:F7:52:30:BB:2C:
                18:2D:B5:90:27:21:91:7E:DC:D4:34:FB:12:7C:52:6B:D4:4B:7F:0D:50:7C:53:AA:3A:13:6F:E5:A5:5E:82:B0:68:67:12:B2:68:65:FD:EB:
                8F:80:B9:16:8A:E8:5A:98:79:B3:F1:5F:00:2D:0B:AE:03:C8:1A:14:4F:C4:7A:D1:23:80:DB:B5:08:F5:67:F0:3C:D8:7E:17:FB:DC:51:D6:
                83:E0:59:C1:01:A8:D6:D7:86:7F:FA:A0:D3:A4:01:26:95:13:AC:71:34:BF:79:60:3E:28:F3:6C:17:6A:C7:17:25:02:03:01:00:01:A3:50:
                30:4E:30:0E:06:03:55:1D:0F:01:01:FF:04:04:03:02:05:A0:30:1D:06:03:55:1D:25:04:16:30:14:06:08:2B:06:01:05:05:07:03:02:06:
                08:2B:06:01:05:05:07:03:01:30:1D:06:03:55:1D:0E:04:16:04:14:88:B9:3D:6D:DD:7A:8C:48:8B:C9:90:50:C9:04:F5:07:D9:56:65:E5:
                30:0D:06:09:2A:86:48:86:F7:0D:01:01:05:05:00:03:82:01:01:00:99:E7:70:58:67:2A:D3:C4:EB:F0:8B:D0:4F:87:79:F7:7E:29:10:06:
                C6:F3:D7:53:75:93:F3:1E:AE:29:06:C2:24:C4:09:59:42:9A:B6:16:92:B0:87:12:36:8F:BE:F4:CF:9A:E8:44:AD:A4:44:E1:1A:6A:F4:D7:
                C0:5F:D4:EC:B7:54:19:03:28:40:51:EE:D7:9F:DB:88:DB:70:56:E8:82:BC:99:33:52:82:29:6C:A6:A7:08:64:AC:91:8C:21:BD:0D:09:5B:
                12:AB:9D:2A:88:97:7C:C9:BD:55:9E:04:B4:6B:BD:B2:15:0B:12:35:5F:7E:C0:0A:48:D6:E4:9F:62:8C:E8:77:31:AF:F1:83:BF:EF:16:0A:
                6F:B3:55:9B:67:10:CE:2E:3E:61:D9:A1:FA:EA:A8:3F:7D:E3:9F:94:E2:43:B4:4F:92:B0:0C:A6:14:FF:2C:24:A4:FE:AE:45:38:2A:9C:E7:
                97:C6:EC:77:A2:A8:AE:9B:71:28:BF:94:C2:BD:CD:3D:56:C7:85:2D:5D:7C:00:9F:BA:2C:C4:85:8C:BB:25:AE:B5:67:A6:02:DC:24:DA:FE:
                91:64:E5:6B:69:C2:8D:B5:58:C1:4E:BB:B7:77:5D:27:58:E5:72:44:F2:E9:8F:83:A6:59:7F:AF:DF:A2:5C:F9:DC:CE:D4:16:
                */
            }
        }


        static void Main(string[] args)
        {
            string thumbPrint = "30d56bda8ef722aae9eb5b7b9425d62382d65091";
            X509Certificate2 certificate = GetCertificate(thumbPrint);

        }
    }
}
