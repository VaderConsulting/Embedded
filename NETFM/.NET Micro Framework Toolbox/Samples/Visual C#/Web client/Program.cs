using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using Toolbox.NETMF.NET;

/*
 * Copyright 2011-2012 Stefan Thoolen (http://netmftoolbox.codeplex.com/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Web_client
{
    public class Program
    {
        public static void Main()
        {
            // Creates a new web session
            HTTP_Client WebSession = new HTTP_Client("rss.cnn.com");

            // Requests the latest source
            HTTP_Client.HTTP_Response Response = WebSession.Get("/rss/edition.rss");

            // Did we get the expected response? (a "200 OK")
            if (Response.ResponseCode != 200)
                throw new ApplicationException("Unexpected HTTP response code: " + Response.ResponseCode.ToString());

            // Fetches a response header
            Debug.Print("Current date according to rss.cnn.com: " + Response.ResponseHeader("date"));

            // Gets the response as a string
            string Feed = Response.ToString();

            // Does some memory cleanup
            Response = null;

            // Looks for all items
            int ItemPosition = 0;
            while (true)
            {
                ItemPosition = Feed.IndexOf("<item>", ItemPosition + 1);
                if (ItemPosition == -1) break;

                // Searches the title
                int TitleStart = Feed.IndexOf("<title>", ItemPosition) + 7;
                int TitleEnd = Feed.IndexOf("</title>", ItemPosition);
                string Title = Feed.Substring(TitleStart, TitleEnd - TitleStart);

                // Searches the link
                int LinkStart = Feed.IndexOf("<link>", ItemPosition) + 6;
                int LinkEnd = Feed.IndexOf("</link>", ItemPosition);
                string Link = Feed.Substring(LinkStart, LinkEnd - LinkStart);

                Debug.Print("Newsitem: " + Title + " (" + Link + ")");
            }
        }

    }
}
