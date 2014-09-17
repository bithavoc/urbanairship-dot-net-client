# UrbanAirship .NET Client

This is an un-official [CLI](http://en.wikipedia.org/wiki/Common_Language_Infrastructure) client for the [UrbanAirship](http://urbanairship.com/) platform.

## Supported API
UrbanAirship supports many platforms including iOS, Android and RIM. However, this library only supports iOS at this time.

Contributions are welcome.

## Usage

### Configuration

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="UrbanAirship" type="UrbanAirship.Configuration.UrbanAirshipSection, UrbanAirship" />
      </configSections>
      <UrbanAirship applicationKey="APP_KEY" applicationSecret="APP_SECRET"/>
    </configuration>

### Sending a Push Notification iOS

    Client client = new Client(); // Uses Application Configuration File
    client.iOS.RegisterDevice("Some Device Token");
    PushNotification notification = client.CreatePush();
    notification.iOS.Alert = "Hello World";
    notification.DeviceTokens.Add("Some Device Token");
    notification.Send();

### Sending a Push Notification android

    Client client = new Client(); // Uses Application Configuration File
    client.GCM.RegisterDevice("Some Apid");
    PushNotification notification = client.CreatePush();
    notification.GCMPushDetails.Alert = "Hello World";
    notification.GoogleApids.Add("Some Device Token");
    notification.Send();

### Sending a Push Notification cross plaftorm using alias

    Client client = new Client(); // Uses Application Configuration File
    client.GCM.RegisterDevice("Some google Apid", "someAlias@urbanAirshipClient.com");
	client.iOS.RegisterDevice("Some iOS Device Token", "AnotherAlias@urbanAirshipClient.com");
    PushNotification notification = client.CreatePush();
    notification.GoogleGCMDetails.Alert = "Hello World";
	notification.iOS.Alert = "Hello World";
    notification.Aliases.Add("someAlias@urbanAirshipClient.com");
	notification.Aliases.Add("AnotherAlias@urbanAirshipClient.com");
    notification.Send();

### Sending Custom Values


In order to send custom values as part of the notification, you need to create a sub class of PushNotification and decorate it with DataContract and DataMember attributes.

    [DataContract]
    class helloPush : PushNotification
    {
        [DataMember]
        public string myCustomMessage
        {
            get;
            set;
        }
    }

Create an instance of the notification:

    helloPush notification = client.CreatePush<helloPush>();
    notification.myCustomMessage = "Hello There"

## Contributors

* [Bithavoc (author)](im@bithavoc.io)
* [Justin Hyland ](hylander0@hotmail.com)

## MIT License

Copyright (c) 2012, 2014 Bithavoc and Contributors - http://bithavoc.io

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.