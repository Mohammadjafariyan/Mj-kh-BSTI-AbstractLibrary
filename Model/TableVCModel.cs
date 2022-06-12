using System;
using System.Collections.Generic;

namespace AbstractLibrary.Model
{
    public class TableVCModel
    {
        public dynamic entity { get; set; }
        public dynamic table { get; set; }
        public Func<dynamic,string> actionPart { get; set; }
        public string newRecordUrl { get; set; }
        public string returnUrl { get; set; }
        public string deleteUrl { get; set; }

        public Dictionary<string,Func<dynamic, string>> FirstColumns { get; set; }
        public Dictionary<string,Func<dynamic, string>> Pipe { get; set; }
        public bool HasExportDocx { get; set; }
    }
}