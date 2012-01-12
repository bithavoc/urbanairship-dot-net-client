== UrbanAirship .NET Client ==

=== Configuration ===

    <?xml version="1.0" encoding="utf-8" ?>
	<configuration>
	  <configSections>
		<section name="UrbanAirship" type="UrbanAirship.Configuration.UrbanAirshipSection,   
		  UrbanAirship" />
	  </configSections>
	  <UrbanAirship applicationKey="APP_KEY" applicationSecret="APP_SECRET"/>
	</configuration>

=== Usage ===

    Client client = new Client(); // Uses Application Configuration File
    client.iOS.RegisterDevice("Some Device Token");
    PushNotification notification = client.CreatePush();
    notification.iOS.Alert = "Hello World";
    notification.DeviceTokens.Add("Some Device Token");
    notification.Send();
