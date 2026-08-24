Imports Microsoft.SPOT
Imports Microsoft.SPOT.Hardware
Imports SecretLabs.NETMF.Hardware
Imports SecretLabs.NETMF.Hardware.NetduinoPlus
Imports Toolbox.NETMF.NET

'  Copyright 2011-2012 Stefan Thoolen (http://netmftoolbox.codeplex.com/)
'
'  Licensed under the Apache License, Version 2.0 (the "License");
'  you may not use this file except in compliance with the License.
'  You may obtain a copy of the License at
'
'      http://www.apache.org/licenses/LICENSE-2.0
'
'  Unless required by applicable law or agreed to in writing, software
'  distributed under the License is distributed on an "AS IS" BASIS,
'  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'  See the License for the specific language governing permissions and
'  limitations under the License.
Module Module1

    Sub Main()
        ' Creates a new web session
        Dim WebSession As HTTP_Client = New HTTP_Client("rss.cnn.com")

        ' Requests the latest source
        Dim Response As HTTP_Client.HTTP_Response = WebSession.Get("/rss/edition.rss")

        ' Did we get the expected response? (a "200 OK")
        If Response.ResponseCode <> 200 Then
            Throw New ApplicationException("Unexpected HTTP response code: " + Response.ResponseCode.ToString())
        End If

        ' Fetches a response header
        Debug.Print("Current date according to rss.cnn.com: " + Response.ResponseHeader("date"))

        ' Gets the response as a string
        Dim Feed As String = Response.ToString()

        ' Does some memory cleanup
        Response = Nothing

        ' Looks for all items
        Dim ItemPosition As Integer = 0
        Do

            ItemPosition = Feed.IndexOf("<item>", ItemPosition + 1)
            If ItemPosition = -1 Then Exit Do

            ' Searches the title
            Dim TitleStart As Integer = Feed.IndexOf("<title>", ItemPosition) + 7
            Dim TitleEnd As Integer = Feed.IndexOf("</title>", ItemPosition)
            Dim Title As String = Feed.Substring(TitleStart, TitleEnd - TitleStart)

            ' Searches the link
            Dim LinkStart As Integer = Feed.IndexOf("<link>", ItemPosition) + 6
            Dim LinkEnd As Integer = Feed.IndexOf("</link>", ItemPosition)
            Dim Link As String = Feed.Substring(LinkStart, LinkEnd - LinkStart)

            Debug.Print("Newsitem: " + Title + " (" + Link + ")")
        Loop

    End Sub

End Module
