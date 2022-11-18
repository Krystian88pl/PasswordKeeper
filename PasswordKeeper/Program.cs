using PasswordKeeper.App.Concrate;
using PasswordKeeper.App.Menagers;


MenuActionService actionService = new MenuActionService();
PasswordService passwordService = new PasswordService();
PasswordMenagers passwordMenagers = new PasswordMenagers(actionService, passwordService);

Console.WriteLine("Welcome to Password Menager");
while (true)
{
    Console.WriteLine("Please let's me how do you do");
    var mainMenu = actionService.GetMenuActionsByMenuName("Main");
    for (int i = 0; i < mainMenu.Count; i++)
    {
        Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
    }

    var operation = Console.ReadKey();

    switch (operation.KeyChar)
    {
        case '1':
            var newId = passwordMenagers.AddNewPassword();
           // service.Method();
            break;
        case '2':
            passwordMenagers.Remove();
            break;
        case '3':
            passwordMenagers.PasswordShow();
            break;
    }
}