# TAL
Coding Exercise
---------------

// Design Architecture

a) Backend

        + WebAPI (.NET, C#)
		
		+ Design Patterns/Architectural Style
		
		    - MVC (Model-View-Controller)
			
			- Traditioanl N-Layer Architecture [ Legacy ]
			- Monolithic Architecture          [ Legacy ] 

			- Microservices Architecture

            - Logging (log4net) // NLog // elmah

        + Unit Tests
		
		+ Useful comments
		
		+ Coding Style (e.g. using ReSharper)
		
		+ Naming conventions (e.g. camel case)
		
       + Exception Handling

       + Security : JWT Token based Authentication

		
b) Frontend

        + Angular


**<ins>Development Environment</ins>**

* .Net Core 3.1 SDK
* Visual Studio .Net 2019


**<ins>Technologies</ins>**

* C#.NET
* ASP.NET Core Web API
* MS SQL Server

**<ins>Opensource Tools Used</ins>**

* Entity Framework Core (For Data Access)
* Swashbucke (For API Documentation)
* NUnit (For Unit test cases)
* Ocelot (For API Gateway Aggregation)
* NLog (For Logging)

**<ins>How to run the application</ins>**

    1. Open the solution (.sln) in Visual Studio 2019 or later version
    2. Build the solution
    3. Run solution

**<ins>Screenshots</ins>**

![image](https://user-images.githubusercontent.com/70483213/167023756-0ba343bd-aaae-4ac1-b750-9bec120c3e38.png)

![image](https://user-images.githubusercontent.com/70483213/167121113-f323e1ce-7bcd-4afe-a0ce-47fd41835eb5.png)

![image](https://user-images.githubusercontent.com/70483213/167121142-7c0993e3-62c3-4f63-b8b5-7aefe9e2d997.png)

Fetching data from MS SQL Server Database
![image](https://user-images.githubusercontent.com/70483213/167121275-a16a0f34-6fe5-4177-b12b-6b81be8407cc.png)

MS SQL Server Management Studio

![image](https://user-images.githubusercontent.com/70483213/167122286-1cb729c3-8bd2-4963-a0f6-15b5e86f2b20.png)

**Exception Handling**

![image](https://user-images.githubusercontent.com/70483213/167240645-935909b0-9d02-44eb-8ed8-db19055eb1e7.png)

**Securing Controller Actions**

![image](https://user-images.githubusercontent.com/70483213/167240669-e09aa1ba-e13c-4ed4-a1c9-bb61009d4dff.png)

![image](https://user-images.githubusercontent.com/70483213/167240675-a399c495-4de3-4081-8421-1435784c43af.png)


**<ins>FRONTEND</ins>**

Login screen
![image](https://user-images.githubusercontent.com/70483213/167284889-2f11bbe1-3dcb-4009-93a2-4107df4caae8.png)

Premium Calculation
![image](https://user-images.githubusercontent.com/70483213/167284900-09a2d3bc-7ff4-433e-b6f5-7051d791c4c4.png)


**<ins>WebAPI Unit Tests (xUnit)</ins>**

![image](https://user-images.githubusercontent.com/70483213/167315994-3a3fde0e-613e-4df3-83e7-e9b713771e79.png)

**<ins>Deployment</ins>**

    1. IIS
    2. nginx
