﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolFootballApp.Models
{
	public class Message
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Signature { get; set; }
		public DateTime PostTime { get; set; }
		public string UserId { get; set; }
	}
}
