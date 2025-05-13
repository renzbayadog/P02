using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdigitalCafe.ViewModels; 
using IdigitalCafe.Data.Entities; 
using IdigitalCafe.Data; 
using codegen.Helpers; 


namespace IdigitalCafe.ViewModels
{
   public class CategoryVM
   {
		[Display(Name = "Category Id")]
		public int CategoryId { get; set; }

		[Display(Name = "Category Name")]
		[MaxLength(25)]
		public string CategoryName { get; set; }
   }

   public class CategorySearch
   {
        public string Keyword { get; set; }
		public string SortOrder { get; set; }
		
   }
}