# SecureMVCAppTemplate
Secure MVC 5 web app template with login, email confirmation and password reset using Microsoft.AspNet.Identity with SendGrid

# Setup
A SendGrid account is required for this template, once created you can add the credentials into the ```web.config``` file.
``` XML
<appSettings>
    <add key="mailAccount" value="Account" />
    <add key="mailPassword" value="Password" />
  </appSettings>
```
This is for testing purposes only, confidential information should be tokenized.
