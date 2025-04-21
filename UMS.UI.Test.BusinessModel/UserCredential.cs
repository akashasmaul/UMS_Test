using System.Net;
using System.Net.Sockets;

namespace UMS.UI.Test.BusinessModel
{
    public static class UserCredential
    {
        static (string?, string?, string?) credentials;
        static UserCredential()
        {
            credentials = (null, null, null);
        }


        private static IList<IPAddress> GetIpAddress()
        {
            return Dns.GetHostAddresses(Dns.GetHostName()).Where(ip =>
            ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString().StartsWith("192.168.")).ToList();
        }

        public static (string? Username, string? Password, string? Mobile) GetAdminInfo()
        {
            //var credentials = (null, null, null);
            var ipV4s = GetIpAddress();
            foreach (var ipV4 in ipV4s)
            {
                credentials = ipV4.ToString() switch
                {
                    "192.168.3.238" or "192.168.6.43" => ("riadarefin@onnorokom.com", "123456", "01781770073"),
                    "192.168.2.193" or "192.168.2.58" => ("rone@onnorokom.com", "Rone123#", "01708166045"),
                    _ => (null, null, null)
                };

                if (credentials is not (null, null, null))
                    break;
            }
            return credentials;
        }

        public static (string? Username, string? Password, string? Mobile) GetStudentInfo()
        {
            //(string?, string?, string?) credentials = (null, null, null);

            var ipV4s = GetIpAddress();
            foreach (var ipV4 in ipV4s)
            {
                credentials = ipV4.ToString() switch
                {
                    "192.168.2.210" or "192.168.6.43" => ("1659665", "012345", "01708166054"),
                    "192.168.2.193" or "192.168.2.58" => ("1607495", "123456", "01708166045"),
                    _ => (null, null, null)
                };

                if (credentials is not (null, null, null))
                    break;
            }
            return credentials;
        }

        public static (string? Username, string? Password, string? Mobile) GetTeacherInfo()
        {
            //(string?, string?, string?) credentials = (null, null, null);
            //var ipV4s = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => 
            //ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString()
            //.StartsWith("192.168.")).ToList();

            var ipV4s = GetIpAddress();
            foreach (var ipV4 in ipV4s)
            {
                credentials = ipV4.ToString() switch
                {
                    "192.168.2.210" or "192.168.6.43" => ("1713", "012345", "01708166054"),
                    "192.168.2.193" or "192.168.2.58" => ("0382", "123456", "01708166045"),
                    _ => (null, null, null)
                };

                if (credentials is not (null, null, null))
                    break;
            }
            return credentials;
        }
    }
}
