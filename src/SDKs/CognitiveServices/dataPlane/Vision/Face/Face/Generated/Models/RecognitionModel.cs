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
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for RecognitionModel.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecognitionModel
    {
        [EnumMember(Value = "recognition_v01")]
        RecognitionV01,
        [EnumMember(Value = "recognition_v02")]
        RecognitionV02
    }
    internal static class RecognitionModelEnumExtension
    {
        internal static string ToSerializedValue(this RecognitionModel? value)
        {
            return value == null ? null : ((RecognitionModel)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this RecognitionModel value)
        {
            switch( value )
            {
                case RecognitionModel.RecognitionV01:
                    return "recognition_v01";
                case RecognitionModel.RecognitionV02:
                    return "recognition_v02";
            }
            return null;
        }

        internal static RecognitionModel? ParseRecognitionModel(this string value)
        {
            switch( value )
            {
                case "recognition_v01":
                    return RecognitionModel.RecognitionV01;
                case "recognition_v02":
                    return RecognitionModel.RecognitionV02;
            }
            return null;
        }
    }
}
