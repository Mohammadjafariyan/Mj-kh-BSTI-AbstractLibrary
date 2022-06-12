using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using BigPardakht.Model;
using Newtonsoft.Json;

namespace AbstractLibrary.Model.File
{

    public interface IFileSupport
    {
        [Hidden]
        public string FilesJson { get; set; }
        
        
        [NotMapped]
        [SelectFile]
        public string FilesBind { get; set; }

        
        [DontPrintAttribute]
        [NotMapped]
        public int[] Files
        {
            get;
            set;
        }
    }
}