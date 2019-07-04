
namespace ArticleProject.Domain.Validation
{
    public class ValidationMessage
    {
        public const string Required = "Bu alan zorunludur";
        public const string RequiredEmail = "Email adresi yanlış";
        public const string RequiredDate = "Tarih formatı yanlış";
        public const string RequiredPhone = "Telefon formatı yanlış";

        public static string MaxLength(int length)
        {
            return $"Maksimum {length} karakter girebilirsiniz";
        }

        public static string MinLength(int length)
        {
            return $"Minimum {length} karakter girebilirsiniz";
        }

        public static string GreaterThan(int value)
        {
            return $"{value}'dan büyük olmalıdır";
        }

        public static string GreaterThan(string value)
        {
            return $"{value}'dan büyük olmalıdır";
        }
    }
}
