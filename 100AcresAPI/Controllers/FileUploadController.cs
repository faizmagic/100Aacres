﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Net.Http.Formatting;

namespace _100AcresAPI.Controllers
{
    public class FileDesc
    {        
        public string name { get; set; }

        public string url { get; set; }

        public long size { get; set; }

        
        public string UniqueFileName { get; set; }

        
        public int id { get; set; }

        
        public DateTime modifiedon { get; set; }

        
        public string description { get; set; }


        public FileDesc(string rootUrl, FileInfo f, int pId, string aFileName)
        {
            id = pId;
            name = aFileName;
            UniqueFileName = f.Name;
            url = rootUrl + "/Files/" + f.Name;
            size = f.Length / 1024;
            modifiedon = f.LastWriteTime;
            description = aFileName;
        }
    }

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        //string uniqueFileName = string.Empty;

        public string UniqueFileName
        {
            get;
            set;
        }
        public string ActualFileName
        {
            get;
            set;
        }

        public int TaskID { get; set; }
        private int UserID { get; set; }
        public CustomMultipartFormDataStreamProvider(string path, int ptaskID, int pUserID)
            : base(path)
        {
            TaskID = ptaskID;
            UserID = pUserID;
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";

            ActualFileName = name.Replace("\"", string.Empty);

            ActualFileName = Path.GetFileName(ActualFileName);

            UniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ActualFileName);

            //int id = SaveFileInfoIntoDatabase(ActualFileName, TaskID, UniqueFileName, UserID);

            headers.Add("ActualFileName", ActualFileName);
            //headers.Add("id", id.ToString());

            return UniqueFileName;

        }
    }

    public class FileUploadController : ApiController
    {
        public Task<HttpResponseMessage> PostUploadFile()
        {
            // Verify that this is an HTML Form file upload request
            if (!Request.Content.IsMimeMultipartContent("form-data")) 
            {    
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType); 
            }

            List<string> files = new List<string>();
            List<string> formData = new List<string>();

            // Create a stream provider for setting up output streams that saves the output under c:\tmp\uploads   
            // If you want full control over how the stream is saved then derive from MultipartFormDataStreamProvider 
            // and override what you need.
            MultipartFormDataStreamProvider streamProvider = new MultipartFormDataStreamProvider(@"d:\tmp");
            
            // Read the MIME multipart content using the stream provider we just created.
            //Task<MultipartFormDataStreamProvider> task = Request.Content.ReadAsMultipartAsync(streamProvider);
            //MultipartFormDataStreamProvider provider = task.Result;
            string rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
            var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<HttpResponseMessage>(t =>
            {

                if (t.IsFaulted || t.IsCanceled)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in streamProvider.FileData)
                {
                    files.Add(file.Headers.ContentDisposition.FileName);
                    files.Add("Server file path: " + file.LocalFileName);
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }

                // Show all the key-value pairs.
                foreach (var key in streamProvider.FormData.AllKeys)
                {
                    foreach (var val in streamProvider.FormData.GetValues(key))
                    {
                        formData.Add(string.Format("{0}: {1}", key, val));
                        Trace.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }


                return Request.CreateResponse(HttpStatusCode.OK, files, new JsonMediaTypeFormatter(), new MediaTypeHeaderValue("text/html"));
            });



            //IEnumerable<HttpContent> bodyparts = task.Result.Contents;

            //IEnumerable<HttpContent> bodyparts = Request.Content.ReadAsMultipartAsync(streamProvider);  
            // The submitter field is the entity with a Content-Disposition header field with a "name" parameter with value "submitter" 
            
            //string submitter;  
            //if (!bodyparts.TryGetFormFieldValue("submitter", out submitter))   22:         {   23:             submitter = "unknown";   24:         }   25:     26:         // Get a dictionary of local file names from stream provider.   27:         // The filename parameters provided in Content-Disposition header fields are the keys.   28:         // The local file names where the files are stored are the values.   29:         IDictionary<string, string> bodyPartFileNames = streamProvider.BodyPartFileNames;   30:     31:         // Create response containing information about the stored files.   32:         List<string> result = new List<string>();   33:         result.Add(submitter);   34:     35:         IEnumerable<string> localFiles = bodyPartFileNames.Select(kv => kv.Value);   36:         result.AddRange(localFiles);

            //var response = Request.CreateResponse(HttpStatusCode.OK, "File Uploaded", new MediaTypeHeaderValue("text/html"));
            //response.Content = new Object();
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            //return response;
            return task;
        }
    }
}