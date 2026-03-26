using Newtonsoft.Json;
using System.Collections.Generic;

namespace NetCoreForce.Client.Models
{
    public class CompositeResponse
    {
        [JsonProperty(PropertyName = "compositeResponse")]
        public List<CompositeSubrequestResponse> CompositeResponseItems { get; set; }
    }

    public class CompositeSubrequestResponse
    {
        [JsonProperty(PropertyName = "body")]
        public CompositeSubrequestBodyResponse Body { get; set; }

        [JsonProperty(PropertyName = "httpStatusCode")]
        public int HttpStatusCode { get; set; }

        [JsonProperty(PropertyName = "referenceId")]
        public string ReferenceId { get; set; }
    }

    public class CompositeSubrequestBodyResponse
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public List<CompositeSubrequestError> Errors { get; set; }
    }

    public class CompositeSubrequestError
    {
        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public List<string> Fields { get; set; }
    }
}
