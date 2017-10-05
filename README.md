# **Amazon Lex .NET Core Chatbot**
The .NET Core ChatBot application code featured here allows you to order flowers using a ChatBot powered by the **[Amazon Lex][1]**, an AWS AI service. The application is an **ASP.NET Core MVC web application** using **[AWS .NET SDK][2]** and the **[AWS Toolkit for Visual Studio][3]** and deployed on **[Amazon EC2][4]** with **[Amazon Code Services][5]** using AWS **[Continuous Integration][6]** and **[Continuous Delivery][7]** toolchains.


When you are ready to explore building your own Amazon Lex ChatBot, the code provided can be easily used to connect to any ChatBot created with Amazon Lex and deploy this bot to web by only **changing three (3)** configuration options.


----------
## **Try it, Before you Code It** 

Go to the  Amazon Lex .NET ChatBot Demo Site and play with this bot live: [Order Flowers ChatBot][8]


<img src="https://s3.us-east-2.amazonaws.com/aws-blog-tew-posts/ChatBot-Pic2-small.png"/>


----------

## **AWS Services**

The **AWS services** used to implement this web ChatBot application are: 

 - [Amazon Lex][9]: Text based conversational chatbots 
 - [Amazon Cognito][10]: Amazon Cognito Federated Identities feature 
 - [AWS Lambda][11]: AWS Lambda function for serverless validation of
   chatbot responses
 - [Amazon EC2][12]: Virtual compute instances for
   running Linux and Windows instances

The **AWS services** to be used for options to deploy the ChatBot are: 

 - [AWS CodePipeline][13]: Continuous integration and continuous delivery service for automatic bot build and deployment  
 - [AWS CodeBuild][14]: Managed build service to compile chatbot source code and produces software package for deployment
 - [AWS CodeDeploy][15]: Automates chatbot code deployment to Amazon EC2 instances for Windows or Linux 
 - [AWS CloudFormation][16]: Service that helps you model and set up your AWS resources for the bot deployment; Templates provided
 - [AWS CodeStar][17]: set up the entire continuous delivery toolchain for the chatbot with unified user interface and easily setup up team collaboration and project tracking as you enhance this sample with your own custom bot. 

----------
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
  [4]: https://aws.amazon.com/ec2 "Amazon EC2"
  [5]: https://aws.amazon.com/products/developer-tools/ "AWS Developer Tools/Code Services"
  [6]: https://aws.amazon.com/devops/continuous-integration/ "Continuous Integration with AWS"
  [7]: https://aws.amazon.com/devops/continuous-delivery/ "Continuous Delivery with AWS"
  [8]: http://aws-dotnet-chatbot-windows-356320664.us-east-1.elb.amazonaws.com/HelloChatBot/ "Amazon Lex .NET Chatbot Demo"
  [9]: https://aws.amazon.com/lex/
  [10]: https://aws.amazon.com/cognito/
  [11]: https://aws.amazon.com/lambda/
  [12]: http://aws.amazon.com/ec2
  [13]: https://aws.amazon.com/codepipeline/ "AWS CodePipeline"
  [14]: https://aws.amazon.com/codebuild/ "AWS CodeBuild"
  [15]: https://aws.amazon.com/codedeploy/ "AWS CodeDeploy"
  [16]: https://aws.amazon.com/cloudformation/ "AWS CloudFormation"
  [17]: https://aws.amazon.com/codestar/ "AWS CodeStar"