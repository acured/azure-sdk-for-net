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
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// LargeFaceListOperations operations.
    /// </summary>
    public partial interface ILargeFaceListOperations
    {
        /// <summary>
        /// Create an empty large face list with user-specified
        /// largeFaceListId, name, an optional userData and recognitionModel.
        /// &lt;br /&gt; Large face list is a list of faces, up to 1,000,000
        /// faces, and used by [Face - Find
        /// Similar](/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395237).
        /// &lt;br /&gt; After creation, user should use [LargeFaceList Face -
        /// Add](/docs/services/563879b61984550e40cbbe8d/operations/5a158c10d2de3616c086f2d3)
        /// to import the faces and [LargeFaceList -
        /// Train](/docs/services/563879b61984550e40cbbe8d/operations/5a158422d2de3616c086f2d1)
        /// to make it ready for [Face -
        /// FindSimilar](/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395237).
        /// Faces are stored on server until [LargeFaceList -
        /// Delete](/docs/services/563879b61984550e40cbbe8d/operations/5a1580d5d2de3616c086f2cd)
        /// is called.
        /// &lt;br /&gt; Find Similar is used for scenario like finding
        /// celebrity-like faces, similar face filtering, or as a light way
        /// face identification. But if the actual use is to identify person,
        /// please use
        /// [PersonGroup](/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395244)
        /// /
        /// [LargePersonGroup](/docs/services/563879b61984550e40cbbe8d/operations/599acdee6ac60f11b48b5a9d)
        /// and [Face -
        /// Identify](/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395239).
        /// &lt;br /&gt;
        /// * Free-tier subscription quota: 64 large face lists.
        /// * S0-tier subscription quota: 1,000,000 large face lists.
        /// &lt;br /&gt;
        /// 'recognitionModel' should be specified to associate with this large
        /// face list. The default value for 'recognitionModel' is
        /// 'recognition_01', if the latest model needed, please explicitly
        /// specify the model you need in this parameter. New faces that are
        /// added to an existing large face list will use the recognition model
        /// that's already associated with the collection. Existing face
        /// features in a large face list can't be updated to features
        /// extracted by another version of recognition model.
        ///
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
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
        Task<HttpOperationResponse> CreateWithHttpMessagesAsync(string largeFaceListId, string name = default(string), string userData = default(string), string recognitionModel = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieve a large face list’s largeFaceListId, name, userData and
        /// recognitionModel.
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
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
        Task<HttpOperationResponse<LargeFaceList>> GetWithHttpMessagesAsync(string largeFaceListId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update information of a large face list.
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
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
        Task<HttpOperationResponse> UpdateWithHttpMessagesAsync(string largeFaceListId, string name = default(string), string userData = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete an existing large face list according to faceListId.
        /// Persisted face images in the large face list will also be deleted.
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
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
        Task<HttpOperationResponse> DeleteWithHttpMessagesAsync(string largeFaceListId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieve the training status of a large face list (completed or
        /// ongoing).
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
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
        Task<HttpOperationResponse<TrainingStatus>> GetTrainingStatusWithHttpMessagesAsync(string largeFaceListId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List large face lists’ information of largeFaceListId, name,
        /// userData and recognitionModel. &lt;br /&gt;
        /// To get face information inside largeFaceList use [LargeFaceList
        /// Face -
        /// Get](/docs/services/563879b61984550e40cbbe8d/operations/5a158cf2d2de3616c086f2d5)&lt;br
        /// /&gt;
        /// * Large face lists are stored in alphabetical order of
        /// largeFaceListId.
        /// * "start" parameter (string, optional) is a user-provided
        /// largeFaceListId value that returned entries have larger ids by
        /// string comparison. "start" set to empty to indicate return from the
        /// first item.
        /// * "top" parameter (int, optional) specifies the number of entries
        /// to return. A maximal of 1000 entries can be returned in one call.
        /// To fetch more, you can specify "start" with the last retuned
        /// entry’s Id of the current call.
        /// &lt;br /&gt;
        /// For example, total 5 large person lists: "list1", ..., "list5".
        /// &lt;br /&gt; "start=&amp;top=" will return all 5 lists.
        /// &lt;br /&gt; "start=&amp;top=2" will return "list1", "list2".
        /// &lt;br /&gt; "start=list2&amp;top=3" will return "list3", "list4",
        /// "list5".
        ///
        /// </summary>
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
        Task<HttpOperationResponse<IList<LargeFaceList>>> ListWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Queue a large face list training task, the training task may not be
        /// started immediately.
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
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
        Task<HttpOperationResponse> TrainWithHttpMessagesAsync(string largeFaceListId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete an existing face from a large face list (given by a
        /// persistedFaceId and a largeFaceListId). Persisted image related to
        /// the face will also be deleted.
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
        /// </param>
        /// <param name='persistedFaceId'>
        /// Id referencing a particular persistedFaceId of an existing face.
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
        Task<HttpOperationResponse> DeleteFaceWithHttpMessagesAsync(string largeFaceListId, System.Guid persistedFaceId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieve information about a persisted face (specified by
        /// persistedFaceId and its belonging largeFaceListId).
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
        /// </param>
        /// <param name='persistedFaceId'>
        /// Id referencing a particular persistedFaceId of an existing face.
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
        Task<HttpOperationResponse<PersistedFace>> GetFaceWithHttpMessagesAsync(string largeFaceListId, System.Guid persistedFaceId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update a persisted face's userData field.
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
        /// </param>
        /// <param name='persistedFaceId'>
        /// Id referencing a particular persistedFaceId of an existing face.
        /// </param>
        /// <param name='userData'>
        /// User-provided data attached to the face. The size limit is 1KB.
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
        Task<HttpOperationResponse> UpdateFaceWithHttpMessagesAsync(string largeFaceListId, System.Guid persistedFaceId, string userData = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add a face to a large face list. The input face is specified as an
        /// image with a targetFace rectangle. It returns a persistedFaceId
        /// representing the added face, and persistedFaceId will not expire.
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
        /// </param>
        /// <param name='url'>
        /// Publicly reachable URL of an image
        /// </param>
        /// <param name='userData'>
        /// User-specified data about the face for any purpose. The maximum
        /// length is 1KB.
        /// </param>
        /// <param name='targetFace'>
        /// A face rectangle to specify the target face to be added to a person
        /// in the format of "targetFace=left,top,width,height". E.g.
        /// "targetFace=10,10,100,100". If there is more than one face in the
        /// image, targetFace is required to specify which face to add. No
        /// targetFace means there is only one face detected in the entire
        /// image.
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
        Task<HttpOperationResponse<PersistedFace>> AddFaceFromUrlWithHttpMessagesAsync(string largeFaceListId, string url, string userData = default(string), IList<int> targetFace = default(IList<int>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// List all faces in a large face list, and retrieve face information
        /// (including userData and persistedFaceIds of registered faces of the
        /// face).
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
        /// </param>
        /// <param name='start'>
        /// Starting face id to return (used to list a range of faces).
        /// </param>
        /// <param name='top'>
        /// Number of faces to return starting with the face id indicated by
        /// the 'start' parameter.
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
        Task<HttpOperationResponse<IList<PersistedFace>>> ListFacesWithHttpMessagesAsync(string largeFaceListId, string start = default(string), int? top = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Add a face to a large face list. The input face is specified as an
        /// image with a targetFace rectangle. It returns a persistedFaceId
        /// representing the added face, and persistedFaceId will not expire.
        /// </summary>
        /// <param name='largeFaceListId'>
        /// Id referencing a particular large face list.
        /// </param>
        /// <param name='image'>
        /// An image stream.
        /// </param>
        /// <param name='userData'>
        /// User-specified data about the face for any purpose. The maximum
        /// length is 1KB.
        /// </param>
        /// <param name='targetFace'>
        /// A face rectangle to specify the target face to be added to a person
        /// in the format of "targetFace=left,top,width,height". E.g.
        /// "targetFace=10,10,100,100". If there is more than one face in the
        /// image, targetFace is required to specify which face to add. No
        /// targetFace means there is only one face detected in the entire
        /// image.
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
        Task<HttpOperationResponse<PersistedFace>> AddFaceFromStreamWithHttpMessagesAsync(string largeFaceListId, Stream image, string userData = default(string), IList<int> targetFace = default(IList<int>), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
