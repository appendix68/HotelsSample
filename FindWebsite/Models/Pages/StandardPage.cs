using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace FindWebsite.Models.Pages
{
	[ContentType(DisplayName = "StandardPage", GUID = "11d362ef-f30b-4558-b1f5-d0911e38adbe", Description = "")]
	public class StandardPage : PageData
	{
		[CultureSpecific]
		[Display(
			Name = "Main body",
			Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
			GroupName = SystemTabNames.Content,
			Order = 1)]
		public virtual XhtmlString MainBody { get; set; }
	}
}