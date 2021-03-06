// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Redis.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Parameter required for creating a linked server to redis cache.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class RedisLinkedServerCreateParameters
    {
        /// <summary>
        /// Initializes a new instance of the RedisLinkedServerCreateParameters
        /// class.
        /// </summary>
        public RedisLinkedServerCreateParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RedisLinkedServerCreateParameters
        /// class.
        /// </summary>
        /// <param name="linkedRedisCacheId">Fully qualified resourceId of the
        /// linked redis cache.</param>
        /// <param name="linkedRedisCacheLocation">Location of the linked redis
        /// cache.</param>
        /// <param name="serverRole">Role of the linked server. Possible values
        /// include: 'Primary', 'Secondary'</param>
        public RedisLinkedServerCreateParameters(string linkedRedisCacheId, string linkedRedisCacheLocation, ReplicationRole serverRole)
        {
            LinkedRedisCacheId = linkedRedisCacheId;
            LinkedRedisCacheLocation = linkedRedisCacheLocation;
            ServerRole = serverRole;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets fully qualified resourceId of the linked redis cache.
        /// </summary>
        [JsonProperty(PropertyName = "properties.linkedRedisCacheId")]
        public string LinkedRedisCacheId { get; set; }

        /// <summary>
        /// Gets or sets location of the linked redis cache.
        /// </summary>
        [JsonProperty(PropertyName = "properties.linkedRedisCacheLocation")]
        public string LinkedRedisCacheLocation { get; set; }

        /// <summary>
        /// Gets or sets role of the linked server. Possible values include:
        /// 'Primary', 'Secondary'
        /// </summary>
        [JsonProperty(PropertyName = "properties.serverRole")]
        public ReplicationRole ServerRole { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (LinkedRedisCacheId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "LinkedRedisCacheId");
            }
            if (LinkedRedisCacheLocation == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "LinkedRedisCacheLocation");
            }
        }
    }
}
