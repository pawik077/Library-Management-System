using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models {
	public class LendModel {
		public FindBook book { get; set; }
		public Klient klient { get; set; }
		public virtual SelectList clientList { get; set; }
	}
}
