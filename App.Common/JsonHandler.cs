using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common
{
    public class JsonHandler
    {
        public static JsonMessage CreateMessage(int pType,string pMessage,string pValue)
        {
            JsonMessage json = new JsonMessage
            {
                Type = pType,
                Message = pMessage,
                Value = pValue
            };
            return json;
        }

        public static JsonMessage CreateMessage(int pType, string pMessage)
        {
            JsonMessage json = new JsonMessage()
            {
                Type = pType,
                Message = pMessage,
            };
            return json;
        }
        public class JsonMessage
        {
            public int Type { get; set; }
            public string Message { get; set; }
            public string Value { get; set; }
        }
    }
}
