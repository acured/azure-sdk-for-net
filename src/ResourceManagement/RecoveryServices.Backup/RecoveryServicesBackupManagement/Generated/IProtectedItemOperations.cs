// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Management.RecoveryServices.Backup
{
    /// <summary>
    /// The Resource Manager API includes operations for managing the items
    /// protected by your Recovery Services Vault.
    /// </summary>
    public partial interface IProtectedItemOperations
    {
        /// <summary>
        /// The Create Or Update Protected Item Operation is used to enable
        /// protection of an item within a container or to modify the
        /// protection of an already protected item. In the case of enable
        /// protection, this operation creates a new protected item entity in
        /// the backend service. In the case of modify protection, this
        /// operation updates the already created entity in the backend
        /// service. This is an asynchronous operation. To determine whether
        /// the backend service has finished processing the request, call the
        /// Get Item Operation Result API.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Resource group name of your recovery services vault.
        /// </param>
        /// <param name='resourceName'>
        /// Name of your recovery services vault.
        /// </param>
        /// <param name='fabricName'>
        /// Fabric name of the protected item.
        /// </param>
        /// <param name='containerName'>
        /// Name of the container where the protected item belongs to.
        /// </param>
        /// <param name='protectedItemName'>
        /// Name of the protected item which has to be backed up.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Base recovery job response for all the asynchronous operations.
        /// </returns>
        Task<BaseRecoveryServicesJobResponse> CreateOrUpdateProtectedItemAsync(string resourceGroupName, string resourceName, string fabricName, string containerName, string protectedItemName, ProtectedItemCreateOrUpdateRequest request, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken);
        
        /// <summary>
        /// The Delete Protected Item Operation is used to disable protection
        /// of an item within a container. This operation marks the already
        /// existing protected item entity as not protected in the backend
        /// service. This is an asynchronous operation. To determine whether
        /// the backend service has finished processing the request, call the
        /// Get Item Operation Result API.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Resource group name of your recovery services vault.
        /// </param>
        /// <param name='resourceName'>
        /// Name of your recovery services vault.
        /// </param>
        /// <param name='fabricName'>
        /// Fabric name of the protected item.
        /// </param>
        /// <param name='containerName'>
        /// Name of the container where the protected item belongs to.
        /// </param>
        /// <param name='protectedItemName'>
        /// Name of the protected item which has to be backed up.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Base recovery job response for all the asynchronous operations.
        /// </returns>
        Task<BaseRecoveryServicesJobResponse> DeleteProtectedItemAsync(string resourceGroupName, string resourceName, string fabricName, string containerName, string protectedItemName, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken);
        
        /// <summary>
        /// Gets Info for the given item present in the given container
        /// specified by the names passed in the arguments. When the query
        /// parameter is used to pass the expand flag, this operation would
        /// return the extended info as well for the given item.This is an
        /// asynchronous operation. To determine whether the backend service
        /// has finished processing the request, call the Get Item Operation
        /// Result API.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Resource group name of your recovery services vault.
        /// </param>
        /// <param name='resourceName'>
        /// Name of your recovery services vault.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A single instance of a protected item response.
        /// </returns>
        Task<ProtectedItemResponse> GetAsync(string resourceGroupName, string resourceName, string fabricName, string containerName, string protectedItemName, GetProtectedItemQueryParam queryFilter, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken);
        
        /// <summary>
        /// Fetches the result of any operation on the protected item given the
        /// ID of operation.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Resource group name of your recovery services vault.
        /// </param>
        /// <param name='resourceName'>
        /// Name of your recovery services vault.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A single instance of a protected item response.
        /// </returns>
        Task<ProtectedItemResponse> GetOperationResultAsync(string resourceGroupName, string resourceName, string fabricName, string containerName, string protectedItemName, string operationId, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken);
        
        /// <summary>
        /// Fetches the result of any operation on the protected item given the
        /// URL for tracking the operation as returned by APIs such as Create
        /// Or Update, Delete etc.
        /// </summary>
        /// <param name='operationResultLink'>
        /// Location value returned by operation.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A single instance of a protected item response.
        /// </returns>
        Task<ProtectedItemResponse> GetProtectedItemOperationResultByURLAsync(string operationResultLink, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken);
        
        /// <summary>
        /// Lists all the items protected by your Recovery Services Vault
        /// according to the query and pagination parameters supplied in the
        /// arguments.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Resource group name of your recovery services vault.
        /// </param>
        /// <param name='resourceName'>
        /// Name of your recovery services vault.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// List of protected items returned as a response by the list
        /// protected item API.
        /// </returns>
        Task<ProtectedItemListResponse> ListAsync(string resourceGroupName, string resourceName, ProtectedItemListQueryParam queryFilter, PaginationRequest paginationParams, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken);
    }
}