using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HrApp.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "login-type")]
    public class HyperlinkTagHelper : TagHelper
    {
        public LoginType LoginType { get; set; } = LoginType.Username;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            switch(LoginType)
            {
                case LoginType.Username:
                    output.Content.SetContent("<i class=\"fa-solid fa-user\"></i>"
                                            + "<h4>Username</h4>");
                    break;
                case LoginType.Email:
                    output.Content.SetContent("<i class=\"fa-solid fa-at\"></i>"
                                            + "<h4>Email</h4>");
                    break;
                case LoginType.Facebook:
                    output.Content.SetContent("<i class=\"fa-brands fa-facebook\"></i>"
                                            + "<h4>Facebook</h4>");
                    break;
                case LoginType.Google:
                    output.Content.SetContent("<i class=\"fa-brands fa-google\"></i>"
                                            + "<h4>Google</h4>");
                    break;
                case LoginType.External:
                    output.Content.SetContent("<i class=\"fa-solid fa-fingerprint\"></i>"
                                            + "<h4>Open Id</h4>");
                    break;
            }

        }
    }

    public enum LoginType
    {
        Username,
        Email,
        Facebook,
        Google,
        External
    }
}
