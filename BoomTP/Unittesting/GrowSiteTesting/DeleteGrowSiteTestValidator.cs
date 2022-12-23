using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.GrowSiteTesting
{
    [TestClass]
    public class DeleteGrowSiteTestValidator
    {
        private DeleteGrowSiteValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new DeleteGrowSiteValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Id_is_null()
        {
            DeleteGrowSiteCommand deleteGrowSiteCommand = new DeleteGrowSiteCommand
            {
                Id = null
            };
            var result = validator.TestValidate(deleteGrowSiteCommand);
            result.ShouldHaveValidationErrorFor(gs => gs.Id);
        }

        [TestMethod]
        public void Should_not_have_error_when_Id_is_specified()
        {
            DeleteGrowSiteCommand deleteGrowSiteCommand = new DeleteGrowSiteCommand
            {
                Id = 1
            };
            var result = validator.TestValidate(deleteGrowSiteCommand);
            result.ShouldNotHaveValidationErrorFor(gs => gs.Id);
        }
    }
}