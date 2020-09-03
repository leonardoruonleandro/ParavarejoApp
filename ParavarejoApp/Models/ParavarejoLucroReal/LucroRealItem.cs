using System;
using System.Collections.Generic;
using System.Text;

namespace ParavarejoApp.Models.ParavarejoLucroReal
{
    public class LucroRealItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public double Value { get; set; }

        public bool IsEditable { get; set; }

    }
}
