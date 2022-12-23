using AP.BoomTP.Application.CQRS.UserCQRS;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittesting.UserTesting
{
    [TestClass]
    public class DeleteUserTestValidator
    {
        private DeleteUserValidator validator;

        [TestInitialize]
        public void Setup()
        {
            validator = new DeleteUserValidator();
        }

        [TestMethod]
        public void Should_have_error_when_Id_is_null()
        {
            DeleteUserCommand deleteUserCommand = new DeleteUserCommand
            {
                Id = null
            };
            var result = validator.TestValidate(deleteUserCommand);
            result.ShouldHaveValidationErrorFor(u => u.Id);
        }

        [TestMethod]
        public void Should_not_have_error_when_Id_is_specified()
        {
            DeleteUserCommand deleteUserCommand = new DeleteUserCommand
            {
                Id = 1
            };
            var result = validator.TestValidate(deleteUserCommand);
            result.ShouldNotHaveValidationErrorFor(u => u.Id);
        }
    }
}