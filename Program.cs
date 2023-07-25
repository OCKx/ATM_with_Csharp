using System;

public class CardHolder
{
    string firstName;
    string lastName;
    int pin;
    string cardNum;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getCardNum()
    {
        return cardNum;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public int getPin()
    {
        return pin;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setCardNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("please choose one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit...");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thanks for your deposit your new balance is " + currentUser.getBalance());
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw...");
            double withdraw = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdraw)
            {
             Console.WriteLine("Insufficeint Fund");
            }
            else
            {
             currentUser.setBalance(currentUser.getBalance() - withdraw);
             Console.WriteLine("Thanks for your withdrawer:");
            }
        }

        void checkBalance(CardHolder currentUser)
        {
            Console.WriteLine("Your Balance is " + currentUser.getBalance());
        }



        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("123456789098765", 1234, "Ada", "Obi", 222.80));
        cardHolders.Add(new CardHolder("444456789098765", 8884, "Amada", "Obijiofor", 8762.80));

        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please enter your card number: ");
        CardHolder currentUser;

        string debitCardNum = "";
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(x => x.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Could not be recognised: Please try again");
                }
            }
            catch
            {
                 Console.WriteLine("Could not be recognised: Please try again");
            }
        }

    int userPin = 0;
    Console.WriteLine("Please enter your Pin: ");
    while (true)
    {
        try
        {
            userPin = int.Parse(Console.ReadLine());
            if (currentUser.getPin() == userPin)
            {
                break;
            }
            else
            {
                Console.WriteLine("Incorrect Pin: Please try again");
            }
        }
        catch
        {
            Console.WriteLine("Incorrect Pin: Please try again");
        }
    }

    Console.WriteLine("Welcome " + currentUser.getFirstName());
    int option = 0;
    do
    {
       printOptions();
       try
       {
        option = int.Parse(Console.ReadLine());
       }
       catch
       {
        
       } 
       if (option == 1)
       {
        deposit(currentUser);
       }
       else if (option == 2)
       {
        withdraw(currentUser);
       }
       else if (option == 3)
       {
        checkBalance(currentUser);
       }
       else if (option == 4)
       {
        break;
       }
       else
       {
        option = 0;
       }
    } while (option != 4);
        Console.WriteLine("Thanks for banking wih us");

    }
}