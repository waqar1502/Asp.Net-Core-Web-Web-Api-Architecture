using App.Models.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.AppModels
{
   public class GetSampleDataAppModel :SuccessViewModel
    {
        public GetSampleDataAppModel()
        {
            Content = new SampleDataAppModel();
        }
        public new SampleDataAppModel Content { get; set; }
    }

    public class SampleDataAppModel
    {
        public SampleDataAppModel()
        {
            AllData = new HashSet<SampleViewModel>();
        }
        public IEnumerable<SampleViewModel> AllData { get; set; }
        public int Total { get; set; }
    }

    //public class SampleDataValidator : AbstractValidator<SampleViewModel>
    //{
    //    public SampleDataValidator()
    //    {
    //         RuleFor(x => x.Name).Length(0, 50);
    //    }
    //}
}
