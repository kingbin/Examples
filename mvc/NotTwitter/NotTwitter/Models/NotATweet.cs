using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotTwitter.Models
{
	public class NotATweet
	{
		public int ID { get; set; }
		public string Username { get; set; }
		public string Text { get; set; }
		public DateTime Published { get; set; }
	}
}