Administrator Setup Instructions
The application is designed to accommodate an administrator role for enhanced management capabilities.
Follow the steps below to add an administrator:

1 - Create an Account: 
Begin by registering an account through the web application. 
Access the registration page via the "User/login" or "User/register".

2 - Elevate Account to Journalist: 
Once the account is created, navigate to the "/Journalist/Become" endpoint to elevate the account to a journalist status.

3 - Configure Administrator Email: 
In the "MoonGameRev.Common.GeneralApplicationConstants" file, 
locate the "public const string DevAdminEmail" field. Set the email address of the desired account to be assigned as an administrator.

Upon completion of these steps, the designated administrator will have access to additional functionalities, 
including the ability to assign moderator roles to other users through the "/User/AddToModerator" endpoint.