using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using WebApi_Common.Models;

namespace WebApi_Common.Tests
{
[TestClass]
    public class BorrowerNameValidationUnitTests : BorrowerNameValidation
    {
        [DataRow("John Doe")]
        [DataRow("Jonh Smith")]
        [DataRow("Joanna Roe")]
        [DataTestMethod]
        public void IsValid_WithValidName_ValidationSuccess(string name)
        {
            // Arrange
            var validationContext = new ValidationContext(name);
            var attribute = new BorrowerNameValidation();

            // Act
            ValidationResult validationResult = attribute.GetValidationResult(name, validationContext);

            // Assert
            Assert.AreEqual(validationResult, ValidationResult.Success);
        }

        [DataRow("John $Simth")]
        [DataRow("John\tSmith")]
        [DataRow("John\nSmith")]
        [DataRow("J@hn Smith")]
        [DataRow("J\u00AEhn Smith")]
        [DataRow("John Shmith?")]
        [DataRow("John Smit#")]
        [DataTestMethod]
        public void IsValid_WithSpecialCharacter_ReturnsError(string name)
        {
            // Arrange
            var validationContext = new ValidationContext(name);
            var attribute = new BorrowerNameValidation();

            // Act
            ValidationResult validationResult = attribute.GetValidationResult(name, validationContext);

            // Assert
            Assert.AreEqual(validationResult.ErrorMessage, "The name cannot contain any special character(s)!");
        }
    }
}
