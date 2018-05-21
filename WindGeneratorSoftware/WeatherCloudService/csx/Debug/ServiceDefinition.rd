<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WeatherCloudService" generation="1" functional="0" release="0" Id="804ba3d8-9166-4d06-957c-476f39257586" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WeatherCloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WeatherWebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/LB:WeatherWebRole:Endpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="WeatherWorkerRole:InputRequest" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/LB:WeatherWorkerRole:InputRequest" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WeatherReplicatorWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/MapWeatherReplicatorWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WeatherReplicatorWorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/MapWeatherReplicatorWorkerRoleInstances" />
          </maps>
        </aCS>
        <aCS name="WeatherWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/MapWeatherWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WeatherWebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/MapWeatherWebRoleInstances" />
          </maps>
        </aCS>
        <aCS name="WeatherWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/MapWeatherWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WeatherWorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/MapWeatherWorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WeatherWebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:WeatherWorkerRole:InputRequest">
          <toPorts>
            <inPortMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWorkerRole/InputRequest" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:WeatherWorkerRole:InternalRequest">
          <toPorts>
            <inPortMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWorkerRole/InternalRequest" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapWeatherReplicatorWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherReplicatorWorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWeatherReplicatorWorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherReplicatorWorkerRoleInstances" />
          </setting>
        </map>
        <map name="MapWeatherWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWeatherWebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWebRoleInstances" />
          </setting>
        </map>
        <map name="MapWeatherWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWeatherWorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WeatherReplicatorWorkerRole" generation="1" functional="0" release="0" software="D:\GitHub\III Godina\VI Semestar\REES_Project\WindGeneratorSoftware\WeatherCloudService\csx\Debug\roles\WeatherReplicatorWorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="-1" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <componentports>
              <outPort name="WeatherWorkerRole:InternalRequest" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/SW:WeatherWorkerRole:InternalRequest" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WeatherReplicatorWorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WeatherReplicatorWorkerRole&quot; /&gt;&lt;r name=&quot;WeatherWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;WeatherWorkerRole&quot;&gt;&lt;e name=&quot;InputRequest&quot; /&gt;&lt;e name=&quot;InternalRequest&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherReplicatorWorkerRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherReplicatorWorkerRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherReplicatorWorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="WeatherWebRole" generation="1" functional="0" release="0" software="D:\GitHub\III Godina\VI Semestar\REES_Project\WindGeneratorSoftware\WeatherCloudService\csx\Debug\roles\WeatherWebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
              <outPort name="WeatherWorkerRole:InternalRequest" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/SW:WeatherWorkerRole:InternalRequest" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WeatherWebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WeatherReplicatorWorkerRole&quot; /&gt;&lt;r name=&quot;WeatherWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;WeatherWorkerRole&quot;&gt;&lt;e name=&quot;InputRequest&quot; /&gt;&lt;e name=&quot;InternalRequest&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="WeatherWorkerRole" generation="1" functional="0" release="0" software="D:\GitHub\III Godina\VI Semestar\REES_Project\WindGeneratorSoftware\WeatherCloudService\csx\Debug\roles\WeatherWorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="-1" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="InputRequest" protocol="tcp" portRanges="11000" />
              <inPort name="InternalRequest" protocol="tcp" />
              <outPort name="WeatherWorkerRole:InternalRequest" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/SW:WeatherWorkerRole:InternalRequest" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WeatherWorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WeatherReplicatorWorkerRole&quot; /&gt;&lt;r name=&quot;WeatherWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;WeatherWorkerRole&quot;&gt;&lt;e name=&quot;InputRequest&quot; /&gt;&lt;e name=&quot;InternalRequest&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWorkerRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWorkerRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WeatherWebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyUpdateDomain name="WeatherWorkerRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyUpdateDomain name="WeatherReplicatorWorkerRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WeatherReplicatorWorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyFaultDomain name="WeatherWebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyFaultDomain name="WeatherWorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WeatherReplicatorWorkerRoleInstances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="WeatherWebRoleInstances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="WeatherWorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="91cdc630-a727-4295-90d7-f74394ba1783" ref="Microsoft.RedDog.Contract\ServiceContract\WeatherCloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="3837da51-0cdf-4225-bdfa-3d8b9721de0f" ref="Microsoft.RedDog.Contract\Interface\WeatherWebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="9df108f3-bc02-4cb9-ae95-bcbcabf34ef8" ref="Microsoft.RedDog.Contract\Interface\WeatherWorkerRole:InputRequest@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/WeatherCloudService/WeatherCloudServiceGroup/WeatherWorkerRole:InputRequest" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>