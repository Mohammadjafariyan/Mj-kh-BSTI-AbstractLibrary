using System.Collections.Generic;

namespace BigPardakht.Model
{


    public class MyResponse
    {
        
        public MyResponseStatus Status { get; set; }
        public string Message { get; set; }
    }
    public class MyDataTableResponse<T>:MyResponse
    {
        public string userType { get; set; }

        public List<T> EntityList { get; set; }
        public int Total { get; set; }
        public int? LastSkip { get; set; }
        public int LastTake { get; set; }
        public int First { get; set; }
        public int TotalPages { get; internal set; }
        public int Page { get; internal set; }
    }

    public class MyEntityResponse<T>:MyResponse
    {
        public T Single { get; set; }
        
             
    }

    public class MyRelateEntityResponse<T,T2>
    {
        public T MainEntity { get; set; }
        public List<T2> DependentList { get; set; }
        public int Total { get; set; }
        public int LastRecordsPosition { get; set; }
    }


    public enum MyResponseStatus
    {
        Success=1,Fail=2
    }
}