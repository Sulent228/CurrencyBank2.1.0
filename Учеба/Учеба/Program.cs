using System.ComponentModel;

string tlog = "Nikchaprestol";
string secret = "0001";
bool loged = false;
double buck = 76.75;
double euro = 94.08;
double yen = 0.49;
double funt = 103.8;

Console.Clear();

while (!loged)
{
    Console.WriteLine("Введите логин");
    string log = Console.ReadLine();

    Console.WriteLine("Введите пароль");
    string password = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(log))
    {
        Console.WriteLine("Вы ничего не ввели");
        Console.WriteLine("Попробовать снова? (да/нет)");
        string tryagain = Console.ReadLine();

        if (tryagain == "нет")
        {
            return;
        }
    }
    else if (log != tlog || password != secret)
    {
        Console.WriteLine("Неправильный логин или пароль. Попробовать снова? (да/нет)");
        string tryagain1 = Console.ReadLine();
        if (tryagain1 == "нет")
        {
            Console.WriteLine("До свидания!");
            return;
        }
        Console.Clear();
    }
    else if (password == secret && tlog == log)
    {
        loged = true;
        Console.Clear();
    }
}


Console.WriteLine($"Добро пожаловать, {tlog}");
Console.WriteLine("Введи сумму на счете в рублях:");
double summ = Convert.ToDouble(Console.ReadLine());

bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine($"\nТекущий баланс: {summ} рублей");
    Console.WriteLine("Введите цифру, соответствующую той операции, которую хотите сделать:");
    Console.WriteLine("1) Внести средства");
    Console.WriteLine("2) Снять средства");
    Console.WriteLine("3) Посмотреть курс валют");
    Console.WriteLine("4) Перевести ваши деньги в другую валюту");
    Console.WriteLine("5) Выйти из программы");

    string input = Console.ReadLine();
    double num1;

    if (!double.TryParse(input, out num1))
    {
        Console.WriteLine("Пожалуйста, введите число от 1 до 5");
        continue;
    }

    if (num1 == 1)
    {
        Console.Clear();
        Console.WriteLine("Введите номер соответствующей валюты:");
        Console.WriteLine("1) Рубль");
        Console.WriteLine("2) Евро");
        Console.WriteLine("3) Доллар");
        Console.WriteLine("4) Йены");
        Console.WriteLine("5) Фунты");

        double valuta = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите сумму:");
        double amount = Convert.ToDouble(Console.ReadLine());
        if (amount <= 0)
        {
            Console.WriteLine("Сумма должна быть положительной");
            continue;
        }

        switch (valuta)
        {
            case 1:
                summ += amount;
                break;
            case 2:
                summ += amount * euro;
                break;
            case 3:
                summ += amount * buck;
                break;
            case 4:
                summ += amount * yen;
                break;
            case 5:
                summ += amount * funt;
                break;
            default:
                Console.WriteLine("Неверный выбор валюты");
                continue;
        }
        Console.WriteLine($"На вашем счете теперь {summ} рублей");
    }
    else if (num1 == 2)
    {
        Console.Clear();
        Console.WriteLine("Введите номер соответствующей валюты:");
        Console.WriteLine("1) Рубль");
        Console.WriteLine("2) Евро");
        Console.WriteLine("3) Доллар");
        Console.WriteLine("4) Йены");
        Console.WriteLine("5) Фунты");

        double valuta = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите сумму:");
        double amount = Convert.ToDouble(Console.ReadLine());

        double amountinr = 0;
        switch (valuta)
        {
            case 1:
                amountinr = amount;
                break;
            case 2:
                amountinr = amount * euro;
                break;
            case 3:
                amountinr = amount * buck;
                break;
            case 4:
                amountinr = amount * yen;
                break;
            case 5:
                amountinr = amount * funt;
                break;
            default:
                Console.WriteLine("Неверный выбор валюты");
                continue;
        }

        if (amountinr > summ)
        {
            Console.WriteLine("Недостаточно средств на счете!");
        }
        else
        {
            summ -= amountinr;
            Console.WriteLine($"На вашем счете теперь {summ} рублей");
        }
    }
    else if (num1 == 3)
    {
        
        Console.WriteLine("Актуальный курс валют в рублях:");
        Console.WriteLine($"1 евро = {euro} рублей");
        Console.WriteLine($"1 доллар = {buck} рублей");
        Console.WriteLine($"1 фунт = {funt} рублей");
        Console.WriteLine($"1 йена = {yen} рублей");
        Console.WriteLine("Нажмите любую клавишу для выхода в главное меню");
        Console.ReadKey();
        Console.Clear();
    }
    else if (num1 == 4)
    {
        
        Console.WriteLine("Выберите валюту, в которую хотите перевести свои средства:");
        Console.WriteLine("1) Евро");
        Console.WriteLine("2) Доллары");
        Console.WriteLine("3) Фунты");
        Console.WriteLine("4) Йены");
        

        int valuta1 = Convert.ToInt32(Console.ReadLine());

        switch (valuta1)
        {
            case 1:
                Console.WriteLine($"Ваши {summ} рублей в евро будут равны {summ / euro:F2} €");
                Console.ReadKey();
                break;
            case 2:
                Console.WriteLine($"Ваши {summ} рублей в долларах будут равны {summ / buck:F2} $");
                Console.ReadKey();
                break;
            case 3:
                Console.WriteLine($"Ваши {summ} рублей в фунтах будут равны {summ / funt:F2} £");
                Console.ReadKey();
                break;
            case 4:
                Console.WriteLine($"Ваши {summ} рублей в йенах будут равны {summ / yen:F2} ¥");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Неверный выбор валюты");
                Console.ReadKey();
                break;
        }
    }
    else if (num1 == 5)
    {
        
        Console.WriteLine("До свидания!");
        exit = true;
    }
    else
    {
        Console.WriteLine("Неверный выбор операции. Введите число от 1 до 5");
    }
}




