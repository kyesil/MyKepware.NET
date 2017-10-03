using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKEPConfApiHelper
{
    static class KepTemplates
    {
        public static string getModbusChJson(string name,string port)
        {
            string result = "{   \"common.ALLTYPES_NAME\": \"" + name + "\",       \"common.ALLTYPES_DESCRIPTION\": \"\",        \"servermain.MULTIPLE_TYPES_DEVICE_DRIVER\": \"Modbus TCP/IP Ethernet\",        \"servermain.CHANNEL_DIAGNOSTICS_CAPTURE\": true,        \"servermain.CHANNEL_ETHERNET_COMMUNICATIONS_NETWORK_ADAPTER_STRING\": \"Default\",       \"servermain.CHANNEL_WRITE_OPTIMIZATIONS_METHOD\": 2,        \"servermain.CHANNEL_WRITE_OPTIMIZATIONS_DUTY_CYCLE\": 10,       \"servermain.CHANNEL_NON_NORMALIZED_FLOATING_POINT_HANDLING\": 0,        \"servermain.CHANNEL_COMMUNICATIONS_SERIALIZATION_VIRTUAL_NETWORK\": 0,        \"servermain.CHANNEL_COMMUNICATIONS_SERIALIZATION_TRANSACTIONS_PER_CYCLE\": 1,        \"servermain.CHANNEL_COMMUNICATIONS_SERIALIZATION_NETWORK_MODE\": 0,        \"modbus_ethernet.CHANNEL_USE_ONE_OR_MORE_SOCKETS_PER_DEVICE\": 1,        \"modbus_ethernet.CHANNEL_MAXIMUM_SOCKETS_PER_DEVICE\": 1,        \"modbus_ethernet.CHANNEL_ETHERNET_PORT_NUMBER\": "+port+",        \"modbus_ethernet.CHANNEL_ETHERNET_PROTOCOL\": 0}";
            return result;
        }

        public static string getModbusDevJson(string name,string host, string port)
        {
            string result = "{    \"common.ALLTYPES_NAME\": \"" + name + "\",    \"common.ALLTYPES_DESCRIPTION\": \"\",    \"servermain.MULTIPLE_TYPES_DEVICE_DRIVER\": \"Modbus TCP/IP Ethernet\",    \"servermain.DEVICE_MODEL\": 0,    \"servermain.DEVICE_ID_FORMAT\": 0,    \"servermain.DEVICE_ID_STRING\": \""+host+"\",    \"servermain.DEVICE_ID_HEXADECIMAL\": 0,    \"servermain.DEVICE_ID_DECIMAL\": 0,    \"servermain.DEVICE_ID_OCTAL\": 0,    \"servermain.DEVICE_DATA_COLLECTION\": true,    \"servermain.DEVICE_SIMULATED\": false,    \"servermain.DEVICE_SCAN_MODE\": 1,    \"servermain.DEVICE_SCAN_MODE_RATE_MS\": 8000,    \"servermain.DEVICE_SCAN_MODE_PROVIDE_INITIAL_UPDATES_FROM_CACHE\": false,    \"servermain.DEVICE_CONNECTION_TIMEOUT_SECONDS\": 7,    \"servermain.DEVICE_REQUEST_TIMEOUT_MILLISECONDS\": 5000,    \"servermain.DEVICE_RETRY_ATTEMPTS\": 3,    \"servermain.DEVICE_INTER_REQUEST_DELAY_MILLISECONDS\": 1000,    \"servermain.DEVICE_AUTO_DEMOTION_ENABLE_ON_COMMUNICATIONS_FAILURES\": false,    \"servermain.DEVICE_AUTO_DEMOTION_DEMOTE_AFTER_SUCCESSIVE_TIMEOUTS\": 3,    \"servermain.DEVICE_AUTO_DEMOTION_PERIOD_MS\": 10000,    \"servermain.DEVICE_AUTO_DEMOTION_DISCARD_WRITES\": false,    \"servermain.DEVICE_TAG_GENERATION_ON_STARTUP\": 0,    \"servermain.DEVICE_TAG_GENERATION_DUPLICATE_HANDLING\": 0,    \"servermain.DEVICE_TAG_GENERATION_GROUP\": \"\",    \"servermain.DEVICE_TAG_GENERATION_ALLOW_SUB_GROUPS\": false,    \"modbus_ethernet.DEVICE_VARIABLE_IMPORT_FILE\": \"*.txt\",    \"modbus_ethernet.DEVICE_VARIABLE_IMPORT_INCLUDE_DESCRIPTIONS\": 1,    \"modbus_ethernet.DEVICE_UNSOLICITED_OPC_QUALITY_BAD_UNTIL_WRITE\": false,    \"modbus_ethernet.DEVICE_UNSOLICITED_COMMUNICATIONS_TIMEOUT_SECONDS\": 0,    \"modbus_ethernet.DEVICE_DEACTIVATE_TAGS_ON_ILLEGAL_ADDRESS\": 1,    \"modbus_ethernet.DEVICE_SUB_MODEL\": 1,    \"modbus_ethernet.DEVICE_ETHERNET_PORT_NUMBER\": "+port+",    \"modbus_ethernet.DEVICE_ETHERNET_IP_PROTOCOL\": 1,    \"modbus_ethernet.DEVICE_ETHERNET_CLOSE_TCP_SOCKET_ON_TIMEOUT\": true,    \"modbus_ethernet.DEVICE_ZERO_BASED_ADDRESSING\": true,    \"modbus_ethernet.DEVICE_ZERO_BASED_BIT_ADDRESSING\": true,    \"modbus_ethernet.DEVICE_HOLDING_REGISTER_BIT_MASK_WRITES\": true,    \"modbus_ethernet.DEVICE_MODBUS_FUNCTION_06\": true,    \"modbus_ethernet.DEVICE_MODBUS_FUNCTION_05\": true,    \"modbus_ethernet.DEVICE_CEG_EXTENSION\": true,    \"modbus_ethernet.DEVICE_MAILBOX_CLIENT_PRIVILEGES\": 0,    \"modbus_ethernet.DEVICE_MODBUS_BYTE_ORDER\": true,    \"modbus_ethernet.DEVICE_FIRST_WORD_LOW\": true,    \"modbus_ethernet.DEVICE_FIRST_DWORD_LOW\": true,    \"modbus_ethernet.DEVICE_MODICON_BIT_ORDER\": false,    \"modbus_ethernet.DEVICE_TREAT_LONGS_AS_DOUBLE_PRECISION_UNSIGNED_DECIMAL\": false,    \"modbus_ethernet.DEVICE_OUTPUT_COILS\": 32,    \"modbus_ethernet.DEVICE_INPUT_COILS\": 32,    \"modbus_ethernet.DEVICE_INTERNAL_REGISTERS\": 32,    \"modbus_ethernet.DEVICE_HOLDING_REGISTERS\": 32,    \"modbus_ethernet.DEVICE_PERFORM_BLOCK_READ_ON_STRINGS\": 0}";
            return result;
        }

        public static string getModbusTagJson(List<Tuple<string,string,int>> tags)
        {
            string result = "";
            foreach (var t in tags)
                result += ",{        \"common.ALLTYPES_NAME\": \"" + t.Item1 + "\",        \"common.ALLTYPES_DESCRIPTION\": \"\",        \"servermain.TAG_ADDRESS\": \""+t.Item2+"\",        \"servermain.TAG_DATA_TYPE\": "+t.Item3+",        \"servermain.TAG_READ_WRITE_ACCESS\": 0,        \"servermain.TAG_SCAN_RATE_MILLISECONDS\": 100,        \"servermain.TAG_AUTOGENERATED\": false,        \"servermain.TAG_SCALING_TYPE\": 0,        \"servermain.TAG_SCALING_RAW_LOW\": 0,        \"servermain.TAG_SCALING_RAW_HIGH\": 1000,        \"servermain.TAG_SCALING_SCALED_DATA_TYPE\": 9,        \"servermain.TAG_SCALING_SCALED_LOW\": 0,        \"servermain.TAG_SCALING_SCALED_HIGH\": 1000,        \"servermain.TAG_SCALING_CLAMP_LOW\": false,        \"servermain.TAG_SCALING_CLAMP_HIGH\": false,        \"servermain.TAG_SCALING_NEGATE_VALUE\": false,        \"servermain.TAG_SCALING_UNITS\": \"\"    }";

            result = '[' + result.Substring(1) + ']';
            return result;
        }

    }
}
