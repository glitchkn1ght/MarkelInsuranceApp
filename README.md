# MarkelInsuranceApp

## From James

### TO Do
- Check swagger pages for all controllers.
- Make sure usings are all inside namespace and unused ones are removed. sdfgsdfgsdfgsdfg

### Custom Error Codes
- 10x Validation  Errors
- 11x Database Retrieval Errors
- 12x Database update Errors

### On the spec
- As the original spec was open to interpretation i did email asking for clarity on a number of points. As i have not received a reply as of time of writing so i made some assumptions which i normally would not.

### Considerations

- To test the api you can select the 'try it out' option on the swagger page or use the postman collection i was using. 
- The DAL: I know the original spec mentioned generating the claim/company data in the code but i built a real database and DAL to help work out exactly how to send/receive responses from the database.
  E.g there seemed no need to return the updated claim from the DB and building it for real made me realize it could just be an int. 
- I have included the SQL scripts to create the required tables/sprocs if you would like to test the API with a real db. You will also need to change repository binding in the DI. 
- The ClaimType: This table was included in the original spec but didn't actually link the Claim table via a key or similar. Therefore i wasn't sure what to do with it and didn't include it as part of the design.
  If i were to, i would have returned a joined result set in the appropriate stored procedure and map it from there. 
- The original spec mentions needing a property that will tell if a company has an active policy or not. I wasn't sure if this meant i should rename the 'Active' column to be more explicit, or to calculate if the 
  'InsuranceEndDate' was less than the current date. In the end i chose the former but again would seek clarification from client in a real situation. 
- Response types: I've included custom response codes as well as the HTTP Status codes in order to differentiate HTTP errors from those at the code/database level. E.g. there may have been no matching rows in the database but
  the request returned without any issues. 
- Although the rest of the API is from scratch the PollySqlConnection files are more or less copied from a source i found online (modified by me to include IOptions pattern). I've included a link to the original source. 
- The update claim endpoint: It was hard to determine the best approach for this. From a business/fraud prevention point of view it would seem sensible to only allow the update of the 'Closed' and possibly 'AssuredName'
  coluns to prevent updates the were not genuine. However I thought this may have been overthinking the problem so implemented the endpoint as to update all fields subject to some simple validation. 

### Points For Improvment

- Exhausting Unit/Integration. Very important considering tests always find bugs and edge cases no matter how well you design something. What i have included is meant to be illustrative of general understanding
  but it's the first thing i would improve given more time. 
- Validation: Both of the incoming requests and the responses from the databases. On the request side it's hard to know exactly how to improve it without knowing the exact formats of the inputs
  (e.g. if companyId's only beging at 1001 or what a real UCR looks like). 
- Also i would modify the validators to return a more complex type, containing the error details rather than just a bool in order to keep the controllers skinny. 
- Response types: I've tried to keep responses consistent overall but if there is a 404 due to a mistake in the URL or a string for the companyId it will give the default response type defined by microsoft. 
  It's not a hard thing to change but didn't want to delay my submission any further. 


## OriginalSpec
API Tech Test
Background
We are creating a new front end to an existing SQL Server database, and need a restful DotNetCore
API to be created to allow us to access the Claims and Company data.
For the purpose of this exercise, the data can be generated in code rather than coming from SQL
server.
While this is a test exercise, the level of detail and quality should represent something that is fit for
production.

Requirements
- The output must be in json format
- We need an endpoint that will give me a single company. We need a property to be returned that will tell us if the company has an active insurance policy
- We need an endpoint that will give me a list of claims for one company
- We need an endpoint that will give me the details of one claim. We need a property to be returned that tells us how old the claim is in days
- We need an endpoint that will allow us to update a claim
- We need at least one unit test to be created

Database Structure
CREATE TABLE Claims
(
UCR VARCHAR(20),
CompanyId INT,
ClaimDate DATETIME,
LossDate DATETIME,
[Assured Name] VARCHAR(100),
[Incurred Loss] DECIMAL(15,2),
Closed BIT
)
CREATE TABLE ClaimType
(
Id INT,
Name VARCHAR(20)
)
CREATE TABLE Company
(
Id INT,
Name VARCHAR(200),
Address1 VARCHAR(100),
Address2 VARCHAR(100),
Address3 VARCHAR(100),
Postcode VARCHAR(20),
Country VARCHAR(50),
Active BIT,
InsuranceEndDate DATETIME
)
