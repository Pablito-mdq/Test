using System;
using System.Collections.Generic;
using System.Net;

namespace ServiceTestingFramework
{
    public abstract partial class AbstractServiceTest
    {
        private WebClient client = new WebClient();
        private Dictionary<string, string> headers = new Dictionary<string, string>();

        protected abstract string GetTargetAddress();

        protected void AddHeader(string name, string value)
        {
            headers.Add(name, value);
        }

        private Object DoRequest(string resource, string method, string content)
        {
            
            if (!client.BaseAddress.EndsWith("/") && !resource.StartsWith("/"))
            {
                resource = "/" + resource;
            }

            foreach (KeyValuePair<string, string> entry in headers)
            {
                client.Headers.Add(entry.Key, entry.Value);
            }

            LOG.Info(String.Format("Performing {0} request to {1}...", method, client.BaseAddress + resource));

            return client.UploadString(resource, "POST", content);
        }

        protected Object DoPostRequest(string resource, string content)
        {
            return DoRequest(resource, "POST", content);
        }

        protected Object DoGetRequest(string resource, string content)
        {
            return DoRequest(resource, "GET", content);
        }


    }
}
