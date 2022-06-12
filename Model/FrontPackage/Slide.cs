using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AbstractLibrary.FormBuilder;
using BigPardakht.Model;

namespace AbstractLibrary.Model.FrontModel
{
    public class Slide:Entity
    {
        
        [Text]
        public override string Name { get; set; }


        [Display(Name = "نام یکتا")][Text]
        public string Unique { get; set; }

        [DontPrint]
        public List<SlideShow> SlideShows { get; set; }
    }



}