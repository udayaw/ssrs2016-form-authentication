# SSRS 2016 Forms Authentication

This is a custom security extension for forms authentication in SSRS 2016.

Deployment Instructions
--------------
- Setup the database using Setup/CreateDatabase.txt
- Set DB_HOST, DB_NAME in AuthenticationUtilities.cs 
- Initialize m_adminUserName in Authorization.cs file to the admin user name

More information on deploying this extension in ssrs 2016 can be found in the following blog post.
https://codeliteral.wordpress.com/2016/10/05/ssrs-2016-form-authentication/.
