using System.ComponentModel.DataAnnotations;
using AbstractLibrary.FormBuilder;

namespace BigPardakht.Model
{
    public class Entity:IEntity
    {
        
        [Key]
        [Hidden	]
        public virtual long Id { get; set; }
        
        
        [Hidden]
        public virtual string Name { get; set; }
        
        
        
    }
    
    public class SafeDeleteEntity:Entity
    {
        
        [Hidden]
        public bool? IsDeleted { get; set; }
        [Hidden]
        public bool? IsModified { get; set; }
        [Hidden]
        public long? NextId { get; set; }

    }
}