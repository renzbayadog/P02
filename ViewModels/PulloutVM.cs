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
   public class PulloutVM
   {
		[Display(Name = "Pullout Id")]
		public int PulloutId { get; set; }

		[Display(Name = "Pullout Name")]
		[MaxLength(25)]
		public string PulloutName { get; set; }

		[Display(Name = "Pullout Description")]
		[MaxLength(25)]
		public string PulloutDescription { get; set; }

		[Display(Name = "Pullout Date")]
		public DateTime? PulloutDate { get; set; }

		[Display(Name = "Sales Id")]
		public int? SalesId { get; set; }

		[Display(Name = "Receipt Image")]
		public string ReceiptImage { get; set; }

		[Display(Name = "business Value")]
		public decimal? businessValue { get; set; }

		[Display(Name = "Sales Name")]
		[MaxLength(25)]
		public string SalesName { get; set; }
   }

   public class PulloutSearch
   {
        public string Keyword { get; set; }
		public string SortOrder { get; set; }
		
   }
}