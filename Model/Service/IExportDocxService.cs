using System.Collections.Generic;
using AbstractLibrary.Model;

namespace BigPardakht.Model.Service
{
    public interface IExportDocxService
    {
        string ExportDocx<T>(Dictionary<string, string> replaceWords,
            TableVCModel Model, string templateName, T sampleEntity);
        
         string basePath { get; set; }
    }
}