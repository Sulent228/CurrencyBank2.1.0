using System.ComponentModel;

string CorrectUsername = "Nikchaprestol";
string CorrectPassword = "0001";

double buck = 76.75;
double euro = 94.08;
double yen = 0.49;
double funt = 103.8;

// Функций логина

bool isStringEmpty(string StringValue) { // Получает строковое значение и возвращает true если оно пустое или содержит только пробелы
	return string.IsNullOrWhiteSpace(StringValue);
}

void TryAgain() { // Возвращает False при вводе "нет", иначе True
	string answer = Console.ReadLine();
    if (answer.ToLower() == "нет")
    {
        Console.WriteLine("До свидания!");
        Environment.Exit(0);
    }
}

bool CheckForEmptyInputs(string password, string username) { // Проверяет оба ввода, если они пусты то возвращает True, иначе False
	if (isStringEmpty(password) || isStringEmpty(username))
    {
 		return true;
    }
    return false;
}

bool CheckForCorrectInputs(string password, string username) { // Сравнивает значения ввода, если ввод верный то возвращает True, иначе False
	if (username == CorrectUsername && password == CorrectPassword) {
		Console.Clear();
		Console.WriteLine($"Добро пожаловать, {username}");
		return true;
    }
    return false;
}

void Login() { // Функция входа в систему
	while (true) {
	    Console.WriteLine("Введите логин");
	    string username = Console.ReadLine();

	    Console.WriteLine("Введите пароль");
	    string password = Console.ReadLine();
	
	    bool isEmpty = CheckForEmptyInputs(password, username);
	    if (isEmpty) {
	    	Console.WriteLine("Вы ничего не ввели");
   	        Console.WriteLine("Попробовать снова? (да/нет)");
   	        
   	        TryAgain();

	    	continue; // Мы продолжаем если ввод был пуст
	    }
	    
		bool logged = CheckForCorrectInputs(password, username);
		if (logged) {
			break; // Мы вошли в систему и идем дальше после Login()
		} else {
			Console.WriteLine("Неправильный логин или пароль. Попробовать снова? (да/нет)");
		    
		    TryAgain();
		    
		    Console.Clear();
		}
	}
}

// Функций банковских операций

void Deposit(ref double AccountBalance) {
	Console.Clear();
    Console.WriteLine("Введите номер соответствующей валюты:");
    Console.WriteLine("1) Рубль");
    Console.WriteLine("2) Евро");
    Console.WriteLine("3) Доллар");
    Console.WriteLine("4) Йены");
    Console.WriteLine("5) Фунты");

    double SelectedCurrency = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Введите сумму:");
    double amount = Convert.ToDouble(Console.ReadLine());
    if (amount <= 0)
    {
        Console.WriteLine("Сумма должна быть положительной");
        return;
    }

    switch (SelectedCurrency)
    {
        case 1:
            AccountBalance += amount;
            break;
        case 2:
            AccountBalance += amount * euro;
            break;
        case 3:
            AccountBalance += amount * buck;
            break;
        case 4:
            AccountBalance += amount * yen;
            break;
        case 5:
            AccountBalance += amount * funt;
            break;
        default:
            Console.WriteLine("Неверный выбор валюты");
            break;
    }
    Console.WriteLine($"На вашем счете теперь {AccountBalance} рублей");
    Console.ReadKey();
}

void Withdraw(ref double AccountBalance) {
	Console.Clear();
    Console.WriteLine("Введите номер соответствующей валюты:");
    Console.WriteLine("1) Рубль");
    Console.WriteLine("2) Евро");
    Console.WriteLine("3) Доллар");
    Console.WriteLine("4) Йены");
    Console.WriteLine("5) Фунты");

    double SelectedCurrency = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Введите сумму:");
    double amount = Convert.ToDouble(Console.ReadLine());

    double amountinr = 0;
    switch (SelectedCurrency)
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
			return;
    }

    if (amountinr > AccountBalance)
    {
        Console.WriteLine("Недостаточно средств на счете!");
    }
    else
    {
        AccountBalance -= amountinr;
        Console.WriteLine($"На вашем счете теперь {AccountBalance} рублей");
    }
    Console.ReadKey();
}

void CheckCurrency() {
	Console.WriteLine("Актуальный курс валют в рублях:");
    Console.WriteLine($"1 евро = {euro} рублей");
    Console.WriteLine($"1 доллар = {buck} рублей");
    Console.WriteLine($"1 фунт = {funt} рублей");
    Console.WriteLine($"1 йена = {yen} рублей");
    Console.WriteLine("Нажмите любую клавишу для выхода в главное меню");
    Console.ReadKey();
    Console.Clear();
}

void TranslateCurrency(double AccountBalance) {
	Console.WriteLine("Выберите валюту, в которую хотите перевести свои средства:");
    Console.WriteLine("1) Евро");
    Console.WriteLine("2) Доллары");
    Console.WriteLine("3) Фунты");
    Console.WriteLine("4) Йены");

    int SelectedCurrency = Convert.ToInt32(Console.ReadLine());

    switch (SelectedCurrency)
    {
        case 1:
            Console.WriteLine($"Ваши {AccountBalance} рублей в евро будут равны {AccountBalance / euro:F2} €");
            break;
        case 2:
            Console.WriteLine($"Ваши {AccountBalance} рублей в долларах будут равны {AccountBalance / buck:F2} $");
            break;
        case 3:
            Console.WriteLine($"Ваши {AccountBalance} рублей в фунтах будут равны {AccountBalance / funt:F2} £");
            break;
        case 4:
            Console.WriteLine($"Ваши {AccountBalance} рублей в йенах будут равны {AccountBalance / yen:F2} ¥");
            break;
        default:
            Console.WriteLine("Неверный выбор валюты");
            break;
    }
    Console.ReadKey();
}

void Bank() {
	Console.WriteLine("Введи сумму на счете в рублях:");
	double AccountBalance = Convert.ToDouble(Console.ReadLine());
	
	while (true)
	{
	    Console.Clear();
	    Console.WriteLine($"\nТекущий баланс: {AccountBalance} рублей");
	    Console.WriteLine("Введите цифру, соответствующую той операции, которую хотите сделать:");
	    Console.WriteLine("1) Внести средства");
	    Console.WriteLine("2) Снять средства");
	    Console.WriteLine("3) Посмотреть курс валют");
	    Console.WriteLine("4) Перевести ваши деньги в другую валюту");
	    Console.WriteLine("5) Выйти из программы");
	    
		int SelectedOperation;
	    string input = Console.ReadLine();
	    
	    bool isANumber = Int32.TryParse(input, out SelectedOperation);
	    
	    if (!isANumber)
	    {
	        Console.WriteLine("Пожалуйста, введите число от 1 до 5");
	        continue;
	    }
	
	    switch (SelectedOperation) { // Выбор операций
	    case 1:
	        Deposit(ref AccountBalance);

	        break;
		case 2:
	     	Withdraw(ref AccountBalance);

	        break;
	    case 3:
	    	CheckCurrency();
	        
	        break;
	    case 4:
	    	TranslateCurrency(AccountBalance);	        
	        
	        break;
	    case 5:
	        Console.WriteLine("До свидания!");
			Environment.Exit(0); // Выход из программы 
			break;
	    default:
	        Console.WriteLine("Неверный выбор операции. Введите число от 1 до 5");
	        break;
	   	}
	}
}

// Начало программы

Console.Clear();
Login(); // Вход в систему
Bank(); // Пользование системой
