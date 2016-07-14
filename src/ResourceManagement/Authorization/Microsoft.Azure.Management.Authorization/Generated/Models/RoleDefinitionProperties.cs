// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.14.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Authorization.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Role definition properties.
    /// </summary>
    public partial class RoleDefinitionProperties
    {
        /// <summary>
        /// Initializes a new instance of the RoleDefinitionProperties class.
        /// </summary>
        public RoleDefinitionProperties() { }

        /// <summary>
        /// Initializes a new instance of the RoleDefinitionProperties class.
        /// </summary>
        public RoleDefinitionProperties(string roleName = default(string), string description = default(string), string type = default(string), IList<Permission> permissions = default(IList<Permission>), IList<string> assignableScopes = default(IList<string>))
        {
            RoleName = roleName;
            Description = description;
            Type = type;
            Permissions = permissions;
            AssignableScopes = assignableScopes;
        }

        /// <summary>
        /// Gets or sets role name.
        /// </summary>
        [JsonProperty(PropertyName = "roleName")]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets role definition description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets role type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets role definition permissions.
        /// </summary>
        [JsonProperty(PropertyName = "permissions")]
        public IList<Permission> Permissions { get; set; }

        /// <summary>
        /// Gets or sets role definition assignable scopes.
        /// </summary>
        [JsonProperty(PropertyName = "assignableScopes")]
        public IList<string> AssignableScopes { get; set; }

    }
}