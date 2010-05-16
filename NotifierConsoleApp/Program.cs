using GrowlForNUnit;

namespace NotifierConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var notifier = new Notifier();
            notifier.RegisterGrowl();
            notifier.Notify("Testing the Growl notifier",
                            "If you see this message the Growl notifier seems to be working\nEven handling newline", true);
            notifier.Notify("Testing the Growl notifier Failure",
                    "Failure Message!!!", false);

        }
    }
}