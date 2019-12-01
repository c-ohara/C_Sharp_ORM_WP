# C_Sharp_ORM_WP
# Create a root file called "appsettings.json" and add the following:

{
  "DBInfo":
  {
      "Name": "MySQLconnect",
      "ConnectionString": "server=localhost;userid=<YOUR_DATABASE_ID>;password=<YOUR_DATABASE_PASSWORD;port=<DESIRED_PORT>;database=<YOUR_DATABASE>;SslMode=None"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*"
}
