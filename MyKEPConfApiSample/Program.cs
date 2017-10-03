using RestSharp;
using RestSharp.Authenticators;
using System;

namespace MyKEPConf
{
    class Program
    {
        static string kepConfApiUrl = "http://192.168.1.22:57412";
        static HttpBasicAuthenticator kepAuth = new HttpBasicAuthenticator("Administrator", "");

        static void Main(string[] args)
        {

            Console.WriteLine("Ch:" + getChListJson());Console.ReadLine();
            Console.WriteLine("Devs:" + getDevListJson("13006")); Console.ReadLine();
            Console.WriteLine("Tags:" + getTagListJson("13006","1")); Console.ReadLine();

            var x = createCh("mych");//results:  201:created //400:alrady exists //200:ok/deleted
            createDev("mych", "mydev");
            createTags("mych", "mydev", new string[] { "mytag","mytag2" });

            deleteTag("mych", "mydev", "mytag");
            deleteDev("mych", "mydev");
            deleteCh("mych");
            Console.ReadLine();

        }


        static int createCh(string name)
        {
            var client = new RestClient(kepConfApiUrl + "/config/v1/project/channels/");
            client.Authenticator = kepAuth;
            var request = new RestRequest(Method.POST);

            request.AddHeader("cache-control", "no-cache");
            // request.AddHeader("authorization", "Basic QWRtaW5pc3RyYXRvcjo=");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{   \"common.ALLTYPES_NAME\": \"" + name + "\",       \"common.ALLTYPES_DESCRIPTION\": \"\",        \"servermain.MULTIPLE_TYPES_DEVICE_DRIVER\": \"Modbus TCP/IP Ethernet\",        \"servermain.CHANNEL_DIAGNOSTICS_CAPTURE\": true,        \"servermain.CHANNEL_ETHERNET_COMMUNICATIONS_NETWORK_ADAPTER_STRING\": \"Default\",       \"servermain.CHANNEL_WRITE_OPTIMIZATIONS_METHOD\": 2,        \"servermain.CHANNEL_WRITE_OPTIMIZATIONS_DUTY_CYCLE\": 10,       \"servermain.CHANNEL_NON_NORMALIZED_FLOATING_POINT_HANDLING\": 0,        \"servermain.CHANNEL_COMMUNICATIONS_SERIALIZATION_VIRTUAL_NETWORK\": 0,        \"servermain.CHANNEL_COMMUNICATIONS_SERIALIZATION_TRANSACTIONS_PER_CYCLE\": 1,        \"servermain.CHANNEL_COMMUNICATIONS_SERIALIZATION_NETWORK_MODE\": 0,        \"modbus_ethernet.CHANNEL_USE_ONE_OR_MORE_SOCKETS_PER_DEVICE\": 1,        \"modbus_ethernet.CHANNEL_MAXIMUM_SOCKETS_PER_DEVICE\": 1,        \"modbus_ethernet.CHANNEL_ETHERNET_PORT_NUMBER\": 5002,        \"modbus_ethernet.CHANNEL_ETHERNET_PROTOCOL\": 0}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return (int)response.StatusCode;

        }


        static int createDev(string chname, string name)
        {
            var client = new RestClient(kepConfApiUrl + "/config/v1/project/channels/" + chname + "/devices/");
            client.Authenticator = kepAuth;
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{    \"common.ALLTYPES_NAME\": \"" + name + "\",    \"common.ALLTYPES_DESCRIPTION\": \"\",    \"servermain.MULTIPLE_TYPES_DEVICE_DRIVER\": \"Modbus TCP/IP Ethernet\",    \"servermain.DEVICE_MODEL\": 0,    \"servermain.DEVICE_ID_FORMAT\": 0,    \"servermain.DEVICE_ID_STRING\": \"<5.26.130.81>.1\",    \"servermain.DEVICE_ID_HEXADECIMAL\": 0,    \"servermain.DEVICE_ID_DECIMAL\": 0,    \"servermain.DEVICE_ID_OCTAL\": 0,    \"servermain.DEVICE_DATA_COLLECTION\": true,    \"servermain.DEVICE_SIMULATED\": false,    \"servermain.DEVICE_SCAN_MODE\": 1,    \"servermain.DEVICE_SCAN_MODE_RATE_MS\": 8000,    \"servermain.DEVICE_SCAN_MODE_PROVIDE_INITIAL_UPDATES_FROM_CACHE\": false,    \"servermain.DEVICE_CONNECTION_TIMEOUT_SECONDS\": 7,    \"servermain.DEVICE_REQUEST_TIMEOUT_MILLISECONDS\": 5000,    \"servermain.DEVICE_RETRY_ATTEMPTS\": 3,    \"servermain.DEVICE_INTER_REQUEST_DELAY_MILLISECONDS\": 1000,    \"servermain.DEVICE_AUTO_DEMOTION_ENABLE_ON_COMMUNICATIONS_FAILURES\": false,    \"servermain.DEVICE_AUTO_DEMOTION_DEMOTE_AFTER_SUCCESSIVE_TIMEOUTS\": 3,    \"servermain.DEVICE_AUTO_DEMOTION_PERIOD_MS\": 10000,    \"servermain.DEVICE_AUTO_DEMOTION_DISCARD_WRITES\": false,    \"servermain.DEVICE_TAG_GENERATION_ON_STARTUP\": 0,    \"servermain.DEVICE_TAG_GENERATION_DUPLICATE_HANDLING\": 0,    \"servermain.DEVICE_TAG_GENERATION_GROUP\": \"\",    \"servermain.DEVICE_TAG_GENERATION_ALLOW_SUB_GROUPS\": false,    \"modbus_ethernet.DEVICE_VARIABLE_IMPORT_FILE\": \"*.txt\",    \"modbus_ethernet.DEVICE_VARIABLE_IMPORT_INCLUDE_DESCRIPTIONS\": 1,    \"modbus_ethernet.DEVICE_UNSOLICITED_OPC_QUALITY_BAD_UNTIL_WRITE\": false,    \"modbus_ethernet.DEVICE_UNSOLICITED_COMMUNICATIONS_TIMEOUT_SECONDS\": 0,    \"modbus_ethernet.DEVICE_DEACTIVATE_TAGS_ON_ILLEGAL_ADDRESS\": 1,    \"modbus_ethernet.DEVICE_SUB_MODEL\": 1,    \"modbus_ethernet.DEVICE_ETHERNET_PORT_NUMBER\": 35001,    \"modbus_ethernet.DEVICE_ETHERNET_IP_PROTOCOL\": 1,    \"modbus_ethernet.DEVICE_ETHERNET_CLOSE_TCP_SOCKET_ON_TIMEOUT\": true,    \"modbus_ethernet.DEVICE_ZERO_BASED_ADDRESSING\": true,    \"modbus_ethernet.DEVICE_ZERO_BASED_BIT_ADDRESSING\": true,    \"modbus_ethernet.DEVICE_HOLDING_REGISTER_BIT_MASK_WRITES\": true,    \"modbus_ethernet.DEVICE_MODBUS_FUNCTION_06\": true,    \"modbus_ethernet.DEVICE_MODBUS_FUNCTION_05\": true,    \"modbus_ethernet.DEVICE_CEG_EXTENSION\": true,    \"modbus_ethernet.DEVICE_MAILBOX_CLIENT_PRIVILEGES\": 0,    \"modbus_ethernet.DEVICE_MODBUS_BYTE_ORDER\": true,    \"modbus_ethernet.DEVICE_FIRST_WORD_LOW\": true,    \"modbus_ethernet.DEVICE_FIRST_DWORD_LOW\": true,    \"modbus_ethernet.DEVICE_MODICON_BIT_ORDER\": false,    \"modbus_ethernet.DEVICE_TREAT_LONGS_AS_DOUBLE_PRECISION_UNSIGNED_DECIMAL\": false,    \"modbus_ethernet.DEVICE_OUTPUT_COILS\": 32,    \"modbus_ethernet.DEVICE_INPUT_COILS\": 32,    \"modbus_ethernet.DEVICE_INTERNAL_REGISTERS\": 32,    \"modbus_ethernet.DEVICE_HOLDING_REGISTERS\": 32,    \"modbus_ethernet.DEVICE_PERFORM_BLOCK_READ_ON_STRINGS\": 0}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return (int)response.StatusCode;

        }

        static int createTags(string chname, string devname, string[] tnames)
        {


            var client = new RestClient(kepConfApiUrl + "/config/v1/project/channels/" + chname + "/devices/" + devname + "/tags");
            client.Authenticator = kepAuth;
            var request = new RestRequest(Method.POST);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            string tagsJson = "";
            foreach (var tname in tnames)
                tagsJson += ",{        \"common.ALLTYPES_NAME\": \"" + tname + "\",        \"common.ALLTYPES_DESCRIPTION\": \"\",        \"servermain.TAG_ADDRESS\": \"404031\",        \"servermain.TAG_DATA_TYPE\": 5,        \"servermain.TAG_READ_WRITE_ACCESS\": 0,        \"servermain.TAG_SCAN_RATE_MILLISECONDS\": 100,        \"servermain.TAG_AUTOGENERATED\": false,        \"servermain.TAG_SCALING_TYPE\": 0,        \"servermain.TAG_SCALING_RAW_LOW\": 0,        \"servermain.TAG_SCALING_RAW_HIGH\": 1000,        \"servermain.TAG_SCALING_SCALED_DATA_TYPE\": 9,        \"servermain.TAG_SCALING_SCALED_LOW\": 0,        \"servermain.TAG_SCALING_SCALED_HIGH\": 1000,        \"servermain.TAG_SCALING_CLAMP_LOW\": false,        \"servermain.TAG_SCALING_CLAMP_HIGH\": false,        \"servermain.TAG_SCALING_NEGATE_VALUE\": false,        \"servermain.TAG_SCALING_UNITS\": \"\"    }";

            tagsJson = '['+tagsJson.Substring(1) + ']';
            request.AddParameter("application/json", tagsJson, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return (int)response.StatusCode;

        }


        static int deleteTag(string chname, string devname, string tname)
        {
            var client = new RestClient(kepConfApiUrl + "/config/v1/project/channels/" + chname + "/devices/" + devname + "/tags/" + tname);
            client.Authenticator = kepAuth;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            IRestResponse response = client.Execute(request);
            return (int)response.StatusCode;

        }

        static int deleteDev(string chname, string devname)
        {
            var client = new RestClient(kepConfApiUrl + "/config/v1/project/channels/" + chname + "/devices/" + devname);
            client.Authenticator = kepAuth;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            IRestResponse response = client.Execute(request);
            return (int)response.StatusCode;

        }

        static int deleteCh(string chname)
        {
            var client = new RestClient(kepConfApiUrl + "/config/v1/project/channels/" + chname);
            client.Authenticator = kepAuth;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            IRestResponse response = client.Execute(request);
            return (int)response.StatusCode;

        }


        static string getChListJson()
        {
            var client = new RestClient(kepConfApiUrl + "/config/v1/project/channels/");
            client.Authenticator = kepAuth;
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);
            return response.Content;

        }
        static string getDevListJson(string chname)
        {
            var client = new RestClient(kepConfApiUrl + "/config/v1/project/channels/"+chname+"/devices");
            client.Authenticator = kepAuth;
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);
            return response.Content;

        }

        static string getTagListJson(string chname,string devname)
        {
            var client = new RestClient(kepConfApiUrl + "/config/v1/project/channels/" + chname + "/devices/"+ devname+"/tags");
            client.Authenticator = kepAuth;
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);
            return response.Content;

        }

    }
}
