﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OneMFS.SharedResources.Utility
{
	public class ReportInfo
	{
		public int Id { get; set; }
		public string ReportName { get; set; }
		public string ReportType { get; set; }
		public string ReportPath { get; set; }
		public string ReportDescription { get; set; }
		public string Remarks { get; set; }
		public string InputParameter { get; set; }
		public string CallingApi { get; set; }
		public IEnumerable<int> _Roles { get; set; }
		public string Roles { get; set; }
	}
}
