using System;
using System.Collections.Generic;

namespace Redkik.Classes
{
    public class Offer
    {
        public string? id { get; set; }
        public double? insurerPremium { get; set; }
        public double? techPremium { get; set; }
        public double? distributionPremium { get; set; }
        public double? insurerPremiumTax { get; set; }
        public double? techPremiumTax { get; set; }
        public double? distributionPremiumTax { get; set; }
        public double? tax { get; set; }
        public bool? accepted { get; set; }
        public List<string>? amendments { get; set; }
        public DateTimeOffset? createdAt { get; set; }
    }
}