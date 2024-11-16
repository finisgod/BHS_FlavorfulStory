using System;

namespace FlavorfulStory.UI
{
    /// <summary> �������� ����� �����.</summary>
    public static class InputFieldValidator
    {
        /// <summary> ����������� �������.</summary>
        private static readonly char[] ForbiddenCharacters =
            { '"', '\'', '@', '#', '$', '%', '^', '&', '*', '(', ')', '=', '+',
            '[', ']', '{', '}', '\\', '|', '/', '<', '>', '?', '`', '~' };

        /// <summary> ����������� ����� ������.</summary>
        private const int MinLength = 3;

        /// <summary> ������������ ����� ������.</summary>
        private const int MaxLength = 20;

        /// <summary> ��������� �� ������: ������ ����.</summary>
        private static readonly string EmptyInputError = "���� �� ����� ���� ������!";

        /// <summary> ��������� �� ������: ����������� �����.</summary>
        private static readonly string TooShortError = $"����� ������ ���� �� ����� {MinLength} ��������.";

        /// <summary> ��������� �� ������: ������������ �����.</summary>
        private static readonly string TooLongError = $"����� ������ ���� �� ����� {MaxLength} ��������.";

        /// <summary> ��������� �� ������: ����������� �������.</summary>
        private static readonly string ForbiddenCharactersError = "����� �������� ����������� �������!";

        /// <summary> ���������, ������� �� ����� �����.</summary>
        /// <param name="input"> ����� ��� ��������.</param>
        /// <param name="warningMessage"> ��������� �� ������, ���� ���� ���������.</param>
        /// <returns> True, ���� ���� �������; ����� False.</returns>
        public static bool IsValid(string input, out string warningMessage)
        {
            input = input.Trim();

            // ������ �������� � ���������������� ����������� �� �������
            var checks = new (Func<bool> Condition, string ErrorMessage)[]
            {
                (() => string.IsNullOrEmpty(input), EmptyInputError),
                (() => input.Length < MinLength, TooShortError),
                (() => input.Length > MaxLength, TooLongError),
                (() => ContainsForbiddenCharacters(input), ForbiddenCharactersError)
            };

            // �������� �������
            foreach (var (condition, errorMessage) in checks)
            {
                if (condition())
                {
                    warningMessage = errorMessage;
                    return false;
                }
            }

            // ��� �������� ��������
            warningMessage = string.Empty;
            return true;
        }

        /// <summary> ���������, �������� �� ����� ����������� �������.</summary>
        /// <param name="input"> ����� ��� ��������.</param>
        /// <returns> True, ���� ���� ����������� �������; ����� False.</returns>
        private static bool ContainsForbiddenCharacters(string input)
        {
            foreach (char c in ForbiddenCharacters)
            {
                if (input.Contains(c.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}