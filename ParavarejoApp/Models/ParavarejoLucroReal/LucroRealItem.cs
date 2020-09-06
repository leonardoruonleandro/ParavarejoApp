using ParavarejoApp.Models.Extensions.ParavarejoApp.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ParavarejoApp.Models.ParavarejoLucroReal
{
    public class LucroRealItem
    {

        public LucroRealItem(string id, LucroRealVariable variable, bool isEditable, bool hasPercentual)
        {
            Id = id;
            Variable = variable;
            IsEditable = false;
            HasPercentual = hasPercentual;
        }

        public string Id { get; set; }

        public LucroRealVariable Variable { get; set; }

        public string Description { get { return Variable.GetDescription(); } }

        public double PercentualValue { get; set; }

        public double CurrenceValue { get; set; }

        public bool IsEditable { get; set; }

        public bool HasPercentual { get; set; }

        public override string ToString()
        {
            return $"Variable: {Variable}, Value: {PercentualValue}, Calculated: {CurrenceValue}";
        }
    }
}
