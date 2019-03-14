// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Vision.Face
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// LargePersonGroupOperations operations.
    /// </summary>
    public partial interface ILargePersonGroupOperations
    {
        /// <summary>
        /// Create a new large person group with user-specified
        /// largePersonGroupId, name, an optional userData and
        /// recognitionModel.
        /// &lt;br /&gt; A large person group is the container of the uploaded
        /// person data, including face images and face recognition feature,
        /// and up to 1,000,000 people.
        /// &lt;br /&gt; After creation, use [LargePersonGroup Person -
        /// Create](/docs/services/563879b61984550e40cbbe8d/operations/599adcba3a7b9412a4d53f40)
        /// to add person into the group, and call [LargePersonGroup -
        /// Train](/docs/services/563879b61984550e40cbbe8d/operations/599ae2d16ac60f11b48b5aa4)
        /// to get this group ready for [Face -
        /// Identify](/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395239).
        /// &lt;br /&gt; The person face, image, and userData will be stored on
        /// server until [LargePersonGroup Person -
        /// Delete](/docs/services/563879b61984550e40cbbe8d/operations/599ade5c6ac60f11b48b5aa2)
        /// or [LargePersonGroup -
        /// Delete](/docs/services/563879b61984550e40cbbe8d/operations/599adc216ac60f11b48b5a9f)
        /// is called.
        /// &lt;br /&gt;
        /// * Free-tier subscription quota: 1,000 large person groups.
        /// * S0-tier subscription quota: 1,000,000 large person groups.
        /// &lt;br /&gt;
        /// 'recognitionModel' should be specified to associate with this large
        /// person group. The default value for 'recognitionModel' is
        /// 'recognition_01', if the latest model needed, please explicitly
        /// specify the model you need in this parameter. New faces that are
        /// added to an existing large person group will use the recognition
        /// model that's already associated with the collection. Existing face
        /// features in a large person group can't be updated to features
        /// extracted by another version of recognition model.
        ///
        /// </summary>
        /// <param name='largePersonGroupId'>
        /// Id referencing a particular large person group.
        /// </param>
        /// <param name='name'>
        /// User defined name, maximum length is 128.
        /// </param>
        /// <param name='userData'>
        /// User specified data. Length should not exceed 16KB.
        /// </param>
        /// <param name='recognitionModel'>
        /// Possible values include: 'recognition_01', 'recognition_02'
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> CreateWithHttpMessagesAsync(string largePersonGroupId, string name = default(string), string userData = default(string), string recognitionModel = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete an existing large person group. Persisted face features of
        /// all people in the large person group will also be deleted.
        /// </summary>
        /// <param name='largePersonGroupId'>
        /// Id referencing a particular large person group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> DeleteWithHttpMessagesAsync(string largePersonGroupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieve the information of a large person group, including its
        /// name, userData and recognitionModel. This API returns large person
        /// group information only, use [LargePersonGroup Person -
        /// List](/docs/services/563879b61984550e40cbbe8d/operations/599adda06ac60f11b48b5aa1)
        /// instead to retrieve person information under the large person
        /// group.
        ///
        /// </summary>
        /// <param name='largePersonGroupId'>
        /// Id referencing a particular large person group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<LargePersonGroup>> GetWithHttpMessagesAsync(string largePersonGroupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update an existing large person group's display name and userData.
        /// The properties which does not appear in request body will not be
        /// updated.
        /// </summary>
        /// <param name='largePersonGroupId'>
        /// Id referencing a particular large person group.
        /// </param>
        /// <param name='name'>
        /// User defined name, maximum length is 128.
        /// </param>
        /// <param name='userData'>
        /// User specified data. Length should not exceed 16KB.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> UpdateWithHttpMessagesAsync(string largePersonGroupId, string name = default(string), string userData = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieve the training status of a large person group (completed or
        /// ongoing).
        /// </summary>
        /// <param name='largePersonGroupId'>
        /// Id referencing a particular large person group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<TrainingStatus>> GetTrainingStatusWithHttpMessagesAsync(string largePersonGroupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List all existing large person groups’s largePesonGroupId, name,
        /// userData and recognitionModel.&lt;br /&gt;
        /// * Large person groups are stored in alphabetical order of
        /// largePersonGroupId.
        /// * "start" parameter (string, optional) is a user-provided
        /// largePersonGroupId value that returned entries have larger ids by
        /// string comparison. "start" set to empty to indicate return from the
        /// first item.
        /// * "top" parameter (int, optional) specifies the number of entries
        /// to return. A maximal of 1000 entries can be returned in one call.
        /// To fetch more, you can specify "start" with the last retuned
        /// entry’s Id of the current call.
        /// &lt;br /&gt;
        /// For example, total 5 large person groups: "group1", ..., "group5".
        /// &lt;br /&gt; "start=&amp;top=" will return all 5 groups.
        /// &lt;br /&gt; "start=&amp;top=2" will return "group1", "group2".
        /// &lt;br /&gt; "start=group2&amp;top=3" will return "group3",
        /// "group4", "group5".
        ///
        /// </summary>
        /// <param name='start'>
        /// List large person groups from the least largePersonGroupId greater
        /// than the "start".
        /// </param>
        /// <param name='top'>
        /// The number of large person groups to list.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse<IList<LargePersonGroup>>> ListWithHttpMessagesAsync(string start = default(string), int? top = 1000, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Queue a large person group training task, the training task may not
        /// be started immediately.
        /// </summary>
        /// <param name='largePersonGroupId'>
        /// Id referencing a particular large person group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="APIErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<HttpOperationResponse> TrainWithHttpMessagesAsync(string largePersonGroupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
