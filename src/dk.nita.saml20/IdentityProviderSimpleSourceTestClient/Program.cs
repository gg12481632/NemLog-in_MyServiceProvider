﻿using IdentityProviderSimpleSourceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProviderSimpleSourceTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //string SAMLRequest = "lZJfa8IwFMXfB%2FsOIe82SVuthlaR%2BSJsMHTsYW%2BxSWdYvdHeVNy3X%2BqfTQYT9pqTc87vXm4%2BOWxqsjcNWgcFFRGnk%2FH9Xb4Tctr6NSzMrjXoyXxWUKuzbJD2k1KLUWxSnfKhHqh0IBK10pqvTEXJ6yUpDklkjtiaOaBX4MMTj3mPZz0xeom57CcyzqJhykciyd4omYUaC8of3WvvtygZs3obKfhEV%2FlIf8iYcy7Y0r6Dg0jh%2BtBVPCtEuzcFrVSNhpIwEKDciYK2DUin0KIEtTEofSmX06dHGdjktnHela6mYVpC8iNpc%2FLeNoY203SUdHyhRLWpe3hNmrNT4Cn8wYG2nQX%2FWdC5g3%2FaamugNIuwosaWnXaWrsSbNN%2Bfzonsr8ic%2FcB2d8B%2BHcL4Cw%3D%3D";
            //string SigAlg = "http%3A%2F%2Fwww.w3.org%2F2001%2F04%2Fxmldsig-more%23rsa-sha512";
            //string Signature = "QTvU7noJJ%2bSXMo5fnaoWJoa5prFG%2bzXgHhAz7h6YW3WJ1XmQWKgdYSVA1l9MdFc6thhQjcdqx5jAwYU6wjUF6OC8b%2bE0JKuU9DCR4%2ft9CMl8z7GP1VB6Rzprv6BX98AHS5LtK2HygF4ccqzkxojZA9%2bgvh6l1wHfnsmumyVsXVJ8G1YYrQZ7%2b69uAq%2fe%2bGaroFgjrOjkJGUwJObwLnvcsytQlFNZro7tRoMzVl7UGOuOGSI2jhJTjLUZfbL0Lirog3QH%2bjvh%2fT7DnPwPoGxxo7VyaQL8BAx7jmYx3ucJCJGNiECO9FTTWwvWNyzmznhu7JyGm5eJIhaZlVJcOj5unQ%3d%3d";

            //location: https://oiosaml-demoidp.dk:20001/Signon.ashx
            //? SAMLRequest = lZJLSwMxFIX3gv8hZN % 2FJo6POhJmWYjcFBWnFhbuYZGxwJmnnZkp % 2FvkkfKoIFtzk553z3cqvpvmvRzvRgvasxyyieTq6vqi0TsyGs3dJsBwMBLeY1tlqropBjlY % 2FfTJk3XJVlww1TTN4UvFHNLUYv5yQek9ACYDALB0G6EJ8opyN6N % 2BLsmVPBc0FpxvKCleP8FaN5rLFOhoN7HcIGBCHeepBdO9Km81ZvMv0hOKWUkZV9d95lEtb7VPMkAezO1LiRLRiM4lAOxJbVeOid8BIsCCc7AyIosZo9PojIJza9D175FseJEaoOtP3Re9kY20yfSPHkTJowszOuMyGiVuSYeEy % 2F907b5IF % 2FNiR39M8GbY1TZhn31FuVtJP0Q7yM8 % 2FXrFEn % 2ByqzIN226BvLrHCaf
            //& SigAlg = http % 3A % 2F % 2Fwww.w3.org % 2F2001 % 2F04 % 2Fxmldsig - more % 23rsa - sha512
            //& Signature = aW7ekFoWrsAlabx3JseTSWPnZki % 2fKhatXsOWRZXAqNH8VTFWv % 2bxaq % 2bO44OWAwAK8gMVa9SHrdPzkIfwqit8xBAIU6anm4YbCpjOEgqIAP41aw3qaC09hbJIvBsRh3N5gAVyY % 2fZWDO9sREWAIuILXDS2Pd % 2fh7WZlXGxXVk6z5xo5zn4cpkq0CL9bEVEzF4uaZ2y7qlYvAaPEpLA2A3uSouMtG % 2fNvWBGKMaL3u3aaRAed % 2fbRRlEfi7LvHNv5zAXh5PcS9v7golSIFhYoLd4w48pTYrOm7tJUDyAg54CUBhm3OriST4KBrrb3MOHFFB0G % 2fNDg % 2b7BavaauIczGTYRw20Pg % 3d % 3d

            //string SAMLRequest = "lZJLSwMxFIX3gv8hZN%2FJo6POhJmWYjcFBWnFhbuYZGxwJmnnZkp%2FvkkfKoIFtzk553z3cqvpvmvRzvRgvasxyyieTq6vqi0TsyGs3dJsBwMBLeY1tlqropBjlY%2FfTJk3XJVlww1TTN4UvFHNLUYv5yQek9ACYDALB0G6EJ8opyN6N%2BLsmVPBc0FpxvKCleP8FaN5rLFOhoN7HcIGBCHeepBdO9Km81ZvMv0hOKWUkZV9d95lEtb7VPMkAezO1LiRLRiM4lAOxJbVeOid8BIsCCc7AyIosZo9PojIJza9D175FseJEaoOtP3Re9kY20yfSPHkTJowszOuMyGiVuSYeEy%2F907b5IF%2FNiR39M8GbY1TZhn31FuVtJP0Q7yM8%2FXrFEn%2ByqzIN226BvLrHCaf";
            //string SigAlg = "http%3A%2F%2Fwww.w3.org%2F2001%2F04%2Fxmldsig-more%23rsa-sha512";
            //string Signature = "aW7ekFoWrsAlabx3JseTSWPnZki%2fKhatXsOWRZXAqNH8VTFWv%2bxaq%2bO44OWAwAK8gMVa9SHrdPzkIfwqit8xBAIU6anm4YbCpjOEgqIAP41aw3qaC09hbJIvBsRh3N5gAVyY%2fZWDO9sREWAIuILXDS2Pd%2fh7WZlXGxXVk6z5xo5zn4cpkq0CL9bEVEzF4uaZ2y7qlYvAaPEpLA2A3uSouMtG%2fNvWBGKMaL3u3aaRAed%2fbRRlEfi7LvHNv5zAXh5PcS9v7golSIFhYoLd4w48pTYrOm7tJUDyAg54CUBhm3OriST4KBrrb3MOHFFB0G%2fNDg%2b7BavaauIczGTYRw20Pg%3d%3d";


            // work
            string SAMLRequest = "lZJfa8IwFMXfB%2FsOIe82aax%2FGlpF5ouwwdCxh72F5jrD2kR7U%2FHjL1G7jcGEvebknPO7l1vMT01NjtCicbakacLpfHZ%2FVxxSuej8zq7h0AF6slqW1OjRMNfjVEyHW8gykXGl9VBDrkZ8O%2BHTfEzJa58kQhJZIXawsuiV9eGJCz7gk4EQL3wqMy6zcZJOuMhy8UbJMtQYq%2FzZvfN%2Bj5IxZxyqph5oaJzR%2B0R%2FSME5T9nGvFtnE4W7U6x5VojmCCXdqhqBkjCURXlIS9q1VjqFBqVVDaD0ldwsnh5l4JP71nlXuZqGiQkpzrTtxXvbGNqgjaR01pNGzKTHteADasEuiZf0B2e1iR78Z0N0B%2F%2Bi0wZsBeuwp9ZUUbtKP8TbOF%2B%2FrpHsr8yCfdPGa2C%2FzmH2CQ%3D%3D";
            string SigAlg = "http%3A%2F%2Fwww.w3.org%2F2001%2F04%2Fxmldsig-more%23rsa-sha512";
            string Signature = "J3iUDsHdwR1t0HjI7i57zx04gEz6R6XtHuus%2f45LE%2f1BqLNZqJInueXAWHP7JiOlQPdtg%2b09WRp3lU5XLo5OHbeYx003yGywV3JTeQ7eosyxZoZ7LDfW9WRQtytZitljzLbdBIccH4iLvtOTW9v5ZzI7ohMG6OHWj9cs%2fzJ%2f3I1jsCw2vnJE2TUZ0riy15FsopK9toho7z7mwksl1lChE%2bDGa7SJF49NJl68Za4FUNA2u2sqfxCDVsott0N3ZVzKiZ52NJ%2fP%2bKrXsN7bpLgeyL9CfT4Pe7dZzAFdYxPikq3P31UJmbRGtAVzCKXmQ2S3zFZp8R2DnI6p4N00cjeloQ%3d%3d";

            SAMLRequest = DecodeUrlString(SAMLRequest);
            SigAlg = DecodeUrlString(SigAlg);
            bool result = BusinessLogic.SignIn(SAMLRequest, SigAlg, Signature);
        }

        private static string DecodeUrlString(string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }
    }
}
