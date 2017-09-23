# aws-lex-net-chatbot
The ChatBot .NET application featured here allows you to order flowers using Amazon Lex. The application is an ASP.NET Core MVC web application using AWS .NET SDK and the [AWS Toolkit for Visual Studio][1]


----------


<img src="https://s3.us-east-2.amazonaws.com/aws-blog-tew-posts/ChatBot-Pic2-small.png"/>


----------


###The **AWS services** used to implement this web ChatBot application are: 

 - [Amazon Lex][2]: Text based conversational chatbots 
 - [Amazon Cognito][3]: Amazon Cognito Federated Identities feature 
 - [AWS Lambda][4]: AWS Lambda function for serverless validation of
   chatbot responses
 - [Amazon EC2][5]: Virtual compute instances for
   running Linux and Windows instances

The repo is organized as follows:

**Code folder:** Contains the ASP.NET Core MVC Web Application solution and corresponding code files

**Documentation folder:** Contains documentation of the .NET ChatBot including a detail walkthrough of how to build the Order Flowers chatbot using the .NET code and the deployment resources in this repo

**Linux Deployment:** Scripts needed to create an EC2 Instance running the Linux OS and to deploy the ASP.NET Core web application 

 **Windows Deployment:** Scripts needed to create an EC2 Instance running the Windows OS and to deploy the ASP.NET Core web application 


  [1]: https://aws.amazon.com/visualstudio/
  [2]: https://aws.amazon.com/lex/
  [3]: https://aws.amazon.com/cognito/
  [4]: https://aws.amazon.com/lambda/
  [5]: http://aws.amazon.com/ec2