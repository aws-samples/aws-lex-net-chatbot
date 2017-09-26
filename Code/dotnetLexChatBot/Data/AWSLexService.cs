/*******************************************************************************
* Copyright 2009-2017 Amazon.com, Inc. or its affiliates. All Rights Reserved.
* 
* Licensed under the Apache License, Version 2.0 (the "License"). You may
* not use this file except in compliance with the License. A copy of the
* License is located at
* 
* http://aws.amazon.com/apache2.0/
* 
* or in the "license" file accompanying this file. This file is
* distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
* KIND, either express or implied. See the License for the specific
* language governing permissions and limitations under the License.
*******************************************************************************/
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.Lex;
using Amazon.Lex.Model;
using System.IO;


namespace dotnetLexChatBot.Data
{
    public class AWSLexService : IAWSLexService
    {
        private readonly AWSOptions _awsOptions;
        private Dictionary<string, string> _lexSessionAttribs;
        //private static GetIdResponse _cognitoID;
        //private AnonymousAWSCredentials awsCreds = new AnonymousAWSCredentials();
        //private AmazonCognitoIdentityClient cognitoClient;
        //private GetOpenIdTokenResponse _openIDToken;
        //private readonly Amazon.SecurityToken.Model.Credentials _awsCredentials;
        
        private CognitoAWSCredentials awsCredentials;
        private AmazonLexClient awsLexClient;
        
        //private static CognitoAWSCredentials awsCredentials;
        public AWSLexService(IOptions<AWSOptions> awsOptions)
        {
            _awsOptions = awsOptions.Value;
            
            InitLexService();
            /*
             * Use CognitoID as the Identifying User ID if you have the User Authenticate with Cognito
             * If using UnAuth, CognitoID changes and will affect bot response
             */
            //LexUserID += awsCredentials.GetIdentityId().Split(':')[1].Substring(0,7);

            #region CognitoSTS
            /*
             * This if for using initializing Cognito with STS, not needed
             */
            /*cognitoClient = new AmazonCognitoIdentityClient(
                    awsCreds, // the anonymous credentials
                    RegionEndpoint.USEast1); //Region 
            
            _awsCredentials = Task.Run(async () =>
                {try
                    {   return await GetAWSCredentialsFromSTS(
                            await GetCognitoIDToken(
                                await GetCognitoID()
                            ));
                    }
                 catch (Exception ex)
                    { return null; }
                }).Result.Credentials;*/
            #endregion

        }

        protected void InitLexService()
        {
            Amazon.RegionEndpoint svcRegionEndpoint;

            //Grab region for Lex Bot services
            svcRegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(_awsOptions.BotRegion);

            //Get credentials from Cognito
            awsCredentials = new CognitoAWSCredentials(
                                _awsOptions.CognitoPoolID, // Identity pool ID
                                svcRegionEndpoint); // Region

            //Instantiate Lex Client with Region
            awsLexClient = new AmazonLexClient(awsCredentials,svcRegionEndpoint);
        } 

        public async Task<string> PostToLex(string messageToSend)
        {
            throw new NotImplementedException();
        }

        public async Task<PostTextResponse> SendTextMsgToLex(string messageToSend, Dictionary<string, string> lexSessionAttributes, string sessionId)
        {
            _lexSessionAttribs = lexSessionAttributes;
            return await SendTextMsgToLex(messageToSend, sessionId);

        }
        public async Task<PostTextResponse> SendTextMsgToLex(string messageToSend, string sessionId)
        {   
            PostTextResponse lexTextResponse;
            PostTextRequest lexTextRequest = new PostTextRequest()
            {
                BotAlias = _awsOptions.LexBotAlias,
                BotName = _awsOptions.LexBotName,
                UserId = sessionId,
                InputText = messageToSend,
                SessionAttributes = _lexSessionAttribs
            };

            try
            {
                lexTextResponse = await awsLexClient.PostTextAsync(lexTextRequest);
            }
            catch(Exception ex)
            {
                throw new BadRequestException(ex);
            }

            return lexTextResponse;
        }

        /**
         * Later to Implement receiving Voice input for the Lex Bot
         * with Amazon Lex PostContent and Streams
         * **/
        public Task<Stream> SendAudioMsgToLex(Stream audioToSend)
        {
            throw new NotImplementedException();
        }

        public string PostContentToLex(string messageToSend)
        {
            throw new NotImplementedException();
        }
        
        #region Cognito STS Code
        /**
         * Cognito STS Workaround not needed anymore since Cognito fix
         **/
        /*
        private async Task<GetIdResponse> GetCognitoID()
        {
            GetIdRequest cognitoIDRequest = new GetIdRequest();

            cognitoIDRequest.AccountId = _awsOptions.IDAWS;
            cognitoIDRequest.IdentityPoolId = _awsOptions.CognitoPoolID;

            // Get identity id is in the IdentityId parameter of the response object
            return await cognitoClient.GetIdAsync(cognitoIDRequest); // GetId(idRequest);          
        }

        private async Task<GetOpenIdTokenResponse> GetCognitoIDToken(GetIdResponse idResponse)
        {
            //saving ID for possible future use;
            _cognitoID = idResponse;

            // create a new request object
            GetOpenIdTokenRequest openIdReq = new GetOpenIdTokenRequest();
            openIdReq.IdentityId = _cognitoID.IdentityId;

            return await cognitoClient.GetOpenIdTokenAsync(openIdReq);
        }

        private async Task<AssumeRoleWithWebIdentityResponse> GetAWSCredentialsFromSTS(GetOpenIdTokenResponse idTokenResponse)
        {
            //_openIDToken = idTokenResponse;

            // create a new security token service client with the 
            // anonymous credentials we initialized in the first step
            AmazonSecurityTokenServiceClient amazonSTSClient = new AmazonSecurityTokenServiceClient
                (awsCreds, RegionEndpoint.USEast1);

            // create a new AssumeRoleWithWebIdentityRequest object and set
            // the parameters we need
            AssumeRoleWithWebIdentityRequest amazonSTSRequest = new AssumeRoleWithWebIdentityRequest();
            amazonSTSRequest.RoleArn = _awsOptions.LexRole;
            amazonSTSRequest.RoleSessionName = "LexChatBotSession"; // you need to give the session a name
            amazonSTSRequest.WebIdentityToken = idTokenResponse.Token; // the Token from the previous API call

            // execute the request and retrieve the credentials			
            return await amazonSTSClient.AssumeRoleWithWebIdentityAsync(amazonSTSRequest);
            
        }
        */
        
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    awsLexClient.Dispose();
                    awsCredentials.ClearCredentials();
                }

                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        
        #endregion
    }
}
