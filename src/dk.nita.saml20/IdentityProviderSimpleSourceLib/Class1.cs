using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProviderSimpleSourceLib
{
    public class Class1
    {
    }
}
/* web/app.config
 * 
  <configSections>
    <section name="demoIdp" type="IdentityProviderDemo.Logic.DemoIdPConfigurationSection"/>
  </configSections>
  <demoIdp>
    <users>
      <add userName="Lene" password="Test1234" ppid="PPID-FDFFE8F1-D92C-4838-B46D-B3DD558E700E">
        <attributes>
          <add name="urn:FirstName" value="Lene"/>
          <add name="urn:LastName" value="Hansen"/>
          <add name="urn:Age" value="32"/>
          <add name="urn:oid:0.9.2342.19200300.100.1.3" value="lene@company.dk"/>
          <add name="urn:dk:company:attribute:Role" value="Medarbejder"/>
          <add name="urn:dk:company:attribute:Role" value="Udvikler"/>
          <add name="dk:gov:saml:attribute:AssuranceLevel" value="3"/>
        </attributes>
      </add>
      <add userName="Åge" password="Test1234" ppid="PPID-7CDE9A20-8A40-429a-A390-FFAB7DF84DF3">
        <attributes>
          <add name="urn:FirstName" value="Åge"/>
          <add name="urn:LastName" value="Børgesen"/>
          <add name="urn:Age" value="23"/>
          <add name="urn:oid:0.9.2342.19200300.100.1.3" value="Åge@company.dk"/>
          <add name="urn:dk:company:attribute:Role" value="Øverste Chef"/>
          <add name="dk:gov:saml:attribute:AssuranceLevel" value="3"/>
        </attributes>
      </add>
    </users>
  </demoIdp>
  <appSettings>
    <add key="IDPDataDirectory" value="idp-metadata"/>
  </appSettings>
 * 
 */
