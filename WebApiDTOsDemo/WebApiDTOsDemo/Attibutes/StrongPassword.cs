using System.ComponentModel.DataAnnotations;

namespace WebApiDTOsDemo.Attibutes;

    public class StrongPasswordAttribute : ValidationAttribute
    {
        public int MinimumLength { get; set; } = 8;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Password is required.");
            }

            var password = value.ToString();

            if (password.Length < MinimumLength)
            {
                return new ValidationResult($"Password must be at least {MinimumLength} characters long.");
            }

            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasDigit = false;
            bool hasSpecialCharacter = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowercase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else
                {
                    hasSpecialCharacter = true;
                }
            }

            if (!hasUppercase)
            {
                return new ValidationResult("Password must contain at least one uppercase letter.");
            }

            if (!hasLowercase)
            {
                return new ValidationResult("Password must contain at least one lowercase letter.");
            }

            if (!hasDigit)
            {
                return new ValidationResult("Password must contain at least one digit.");
            }

            if (!hasSpecialCharacter)
            {
                return new ValidationResult("Password must contain at least one special character.");
            }

            return ValidationResult.Success;
        }
    }
