using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HrApp.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "background-color")]
    public class HyperlinkTagHelper : TagHelper
    {
        public string BackgroundColor { get; set; } = "danger";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"btn btn-{BackgroundColor}");
        }
    }
}
