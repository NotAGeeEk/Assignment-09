using System;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("User Registration System");

        try
        {
            RegisterUser();
            Console.WriteLine("User registration is successful!");
        }
        catch (ValidationException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }

    static void RegisterUser()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrEmpty(name) || name.Length < 6)
        {
            throw new ValidationException("Your Name must have at least 6 characters.");
        }

        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        // Basic email format validation
        if (!IsValidEmail(email))
        {
            throw new ValidationException("This email format is Invalid.");
        }

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (string.IsNullOrEmpty(password) || password.Length < 8)
        {
            throw new ValidationException("Password must have at least 8 characters.");
        }
    }

    static bool IsValidEmail(string email)
    {
        // Basic email format validation
        return email.Contains("@") && email.Contains(".");
    }
}