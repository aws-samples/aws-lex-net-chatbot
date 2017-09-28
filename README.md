# aws-lex-net-chatbot
The .NET ChatBot application code featured here allows you to order flowers using a ChatBot powered by the [Amazon Lex][1], AWS AI service. The application is an ASP.NET Core MVC web application using [AWS .NET SDK][2] and the [AWS Toolkit for Visual Studio][3].  

**Try it, Before you Code It** at the Amazon Lex .NET ChatBot Demo Site: [Order Flowers ChatBot][4]

When you are ready to explore building your own Amazon Lex ChatBot. The code provided can be easily used to connect to any ChatBot created with Amazon Lex and deploy this bot to web.


----------


<img src="https://s3.us-east-2.amazonaws.com/aws-blog-tew-posts/ChatBot-Pic2-small.png"/>


----------

## **AWS Services**

The **AWS services** used to implement this web ChatBot application are: 

 - [Amazon Lex][5]: Text based conversational chatbots 
 - [Amazon Cognito][6]: Amazon Cognito Federated Identities feature 
 - [AWS Lambda][7]: AWS Lambda function for serverless validation of
   chatbot responses
 - [Amazon EC2][8]: Virtual compute instances for
   running Linux and Windows instances

## **Repo Structure**
The repo is organized as follows:

**Code folder:** Contains the ASP.NET Core MVC Web Application solution and corresponding code files

**Documentation folder:** Contains documentation of the .NET ChatBot including a detail walkthrough of how to build the Order Flowers chatbot using the .NET code and the deployment resources in this repo

**Linux Deployment:** Scripts needed to create an EC2 Instance running the Linux OS and to deploy the ASP.NET Core web application 

**Windows Deployment:** Scripts needed to create an EC2 Instance running the Windows OS and to deploy the ASP.NET Core web application 

**CloudFormation Template:** CloudFormation template provided to assist with setup of ChatBot on AWS including the configuration of the AWS Services needed.


  [1]: http://aws.amazon.com/lex "Amazon Lex"
  [2]: https://aws.amazon.com/sdk-for-net/ "AWS .NET SDK"
  [3]: https://aws.amazon.com/visualstudio/
  [4]: http://aws-dotnet-chatbot-windows-356320664.us-east-1.elb.amazonaws.com/HelloChatBot/ "Amazon Lex .NET Chatbot Demo"
  [5]: https://aws.amazon.com/lex/
  [6]: https://aws.amazon.com/cognito/
  [7]: https://aws.amazon.com/lambda/
  [8]: http://aws.amazon.com/ec2