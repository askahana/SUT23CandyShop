﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Test0912.TagHelpers
{
    public class EmailTagHelper: TagHelper
    {
        public string Address { get; set; }
        public string LinkText { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(LinkText);
        }
    }
}
