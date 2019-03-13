// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Vision.Face.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Person group object.
    /// </summary>
    public partial class PersonGroup : MetaDataContract
    {
        /// <summary>
        /// Initializes a new instance of the PersonGroup class.
        /// </summary>
        public PersonGroup()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PersonGroup class.
        /// </summary>
        /// <param name="personGroupId">PersonGroupId of the target person
        /// group.</param>
        /// <param name="name">User defined name, maximum length is
        /// 128.</param>
        /// <param name="userData">User specified data. Length should not
        /// exceed 16KB.</param>
        /// <param name="recognitionModel">Possible values include:
        /// 'recognition_v01', 'recognition_v02'</param>
        public PersonGroup(string personGroupId, string name = default(string), string userData = default(string), string recognitionModel = default(string))
            : base(name, userData, recognitionModel)
        {
            PersonGroupId = personGroupId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets personGroupId of the target person group.
        /// </summary>
        [JsonProperty(PropertyName = "personGroupId")]
        public string PersonGroupId { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (PersonGroupId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PersonGroupId");
            }
            if (PersonGroupId != null)
            {
                if (PersonGroupId.Length > 64)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "PersonGroupId", 64);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(PersonGroupId, "^[a-z0-9-_]+$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "PersonGroupId", "^[a-z0-9-_]+$");
                }
            }
        }
    }
}
