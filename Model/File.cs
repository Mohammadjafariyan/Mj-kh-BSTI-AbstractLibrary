using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using BigPardakht.Model;
using Microsoft.AspNetCore.Http;

namespace FileModule.Model
{
    public class File:SafeDeleteEntity
    {


        [NotMapped]
        [File(Accept="application/pdf,application/zip,image/*",Multiple=true)]
        public List<IFormFile> FormFile { get; set; }
        
        [Hidden]
        public FileContent FileContent { get; set; }
      
        [Hidden]
        public string UserId { get; set; }
    }
    
    public class FileContent:SafeDeleteEntity
    {

        public byte[] Content { get; set; }

        public string Extention { get; set; }
        
        public long FileId { get; set; }
        public File File { get; set; }
    }
}