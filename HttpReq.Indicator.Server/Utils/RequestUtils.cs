// Utils/RequestUtils.cs
using System;

namespace HttpReq.Indicator.Server.Utils
{
    public static class RequestUtils
    {
        // Method to validate a request and return a response message
        public static bool ValidateRequest(string data, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrEmpty(data))
            {
                errorMessage = "Invalid data.";
                return false;
            }
            return true;
        }

        // Method to create a response object based on request method and data
        public static object CreateResponse(string method, string data, DateTime serverReceivedTime)
        {
            var responseMessage = $"{method} request received with data: {data}";
            var serverResponseTime = DateTime.UtcNow;
            var serverProcessingDuration = (serverResponseTime - serverReceivedTime).TotalMilliseconds;

            return new
            {
                message = responseMessage,
                serverReceivedTime = serverReceivedTime.ToString("o"),
                serverResponseTime = serverResponseTime.ToString("o"),
                serverProcessingDuration = serverProcessingDuration
            };
        }
    }
}
