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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

/**Created to use Best Practices of Serializing any Object type
 * Into ASP.NET Core HTTPContext.Session Object for Storage
 * and Retrieve of Objects without casting type 
 **/

public static class SessionExtensions
{
    public static void Set<T>(this ISession currentSession, string objKey, T objValue)
    {
        currentSession.SetString(objKey, JsonConvert.SerializeObject(objValue));
    }

    public static T Get<T>(this ISession currentSession, string objKey)
    {
        var objValue = currentSession.GetString(objKey);
        return objValue == null ? default(T) :
                              JsonConvert.DeserializeObject<T>(objValue);
    }
}