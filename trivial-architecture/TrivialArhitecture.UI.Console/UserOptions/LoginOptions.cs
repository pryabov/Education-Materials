using CommandLine;

namespace TrivialArchitecture.UI.Console.UserOptions
{
    class LoginOptions
    {
        [Option('l', "login", Required = true, HelpText = "Login")]
        public string Login { get; set; }

        [Option('p', "password", Required = true, HelpText = "Password")]
        public string Password { get; set; }
    }
}
