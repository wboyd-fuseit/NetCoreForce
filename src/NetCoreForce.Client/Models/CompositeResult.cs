using System.Collections.Generic;
using NetCoreForce.Client.Models;

namespace NetCoreForce.Client.Models
{
    /// <summary>
    /// Typed Wrapper class to map requst items to returned results
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CompositeResult<T> where T : SObject
    {
        public List<CompositeResultItem<T>> Items { get; }
            = new List<CompositeResultItem<T>>();
    }

    public class CompositeResultItem<T> where T : SObject
    {
        /// <summary>
        /// The original record passed into InsertMany/UpdateMany/UpsertMany.
        /// </summary>
        public T OriginalRecord { get; set; }

        /// <summary>
        /// The Salesforce response for this subrequest.
        /// </summary>
        public CompositeSubrequestResponse Response { get; set; }

        /// <summary>
        /// True if the subrequest succeeded (2xx status).
        /// </summary>
        public bool IsSuccess => Response.HttpStatusCode >= 200 && Response.HttpStatusCode < 300;

        /// <summary>
        /// Extracts the Salesforce Id from a successful insert/upsert.
        /// </summary>
        public string RecordId
        {
            get
            {
                if (!IsSuccess || Response.Body == null)
                    return null;

                // Salesforce returns { "id": "...", "success": true, "errors": [] }
                if (Response.Body.Success && !string.IsNullOrEmpty(Response.Body.Id))
                {
                    return Response.Body.Id;
                }

                return null;
            }
        }

        /// <summary>
        /// Returns the first error message if present.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                if (IsSuccess || Response.Body == null)
                    return null;

                // Salesforce error bodies are arrays: [ { "message": "...", "errorCode": "..." } ]
                if (!Response.Body.Success && Response.Body.Errors.Count > 0 && Response.Body.Errors[0].Message != null)
                {
                    return Response.Body.Errors[0].Message;
                }

                return Response.Body.ToString();
            }
        }
    }
}
