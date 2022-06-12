using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AbstractLibrary.FormBuilder
{
   

    public class ExampleForm
    {

        public int Id { get; set; }

        [File(Accept="application/pdf,application/zip,image/*")]
        [Text]
        public string Name { get; set; }
        
        [SelectFile]
        [Select]
        public string select { get; set; }
        
        
    }
    public class MyAbstractAttribute : Attribute
    {
        public string Help { get; set; } 

    }
    

    public class SelectFileAttribute : MyAbstractAttribute
    {
    }

    /// <summary>
    /// enctype="multipart/form-data"
    /// </summary>
    public class FileAttribute : MyAbstractAttribute
    {
        public string Accept { get; set; }

        public bool Multiple{ get; set; }
    
    }

    public class HiddenAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
    }
    
    
    public class ReadOnlyAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
    }
    
    public class SelectColorAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
    }
    
    
    public class TextAreaAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
    }
    public class DontPrintAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
    }

    public class SelectAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
    }  
    
    public class ImagesAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
    }
    
    public class MaxValueAttribute : ValidationAttribute
    {
        private readonly int _maxValue;

        public MaxValueAttribute(int maxValue)
        {
            _maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return (int) value <= _maxValue;
        }
    }
    
    
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int _maxValue;

        public MinValueAttribute(int maxValue)
        {
            _maxValue = maxValue;
        }

        public override bool IsValid(object value)
        {
            return (decimal) value >= _maxValue;
        }
    }
    
    public class SelectEnumAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
        public Type EnumType { get; set; }
    }


    public interface ISelectListProvider
    {
        SelectList GetSelectList(dynamic value);

        string GetSelectListSelectedValue(dynamic value);

    }

    public class TextAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
        public string Type { get; set; } = "text";
    }
      
    
    
    
    public class TranslateAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
    }
    
    
    public class RichTextAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
    }

    public class Factory
    {


        public static void Inject(IServiceProvider serviceProvider)
        {
            
        }
    }

   
    public class SelectByServiceAttribute : MyAbstractAttribute,IFormBuilderAttribute
    {
        public Type ServiceType { get; set; }
        public string SelectLabel { get; set; } = "از لیست انتخاب نمایید";
    }



}