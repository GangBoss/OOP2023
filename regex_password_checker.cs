using System.Text.RegularExpressions;
public class Solution {
    public bool StrongPasswordCheckerII(string password) {
        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-+])(?!.*(.)\1).{8,}$";

        return new Regex(pattern).IsMatch(password);
    }
}