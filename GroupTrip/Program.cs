

System.Console.Write("What was the total trip in miles? ");
int totalTripMiles = Convert.ToInt32 (Console.ReadLine());



System.Console.Write("How many MPG does your car get? ");
int milesPerGallon = Convert.ToInt32 (Console.ReadLine());



System.Console.Write("How much does gas cost in your area. (price per gallon please!) ");
double gasCost = Convert.ToDouble (Console.ReadLine());


string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };


int peopleGoing = names.Length;



System.Console.Write("How many pizzas do you need? ");
int pizzaNeeded = Convert.ToInt32 (Console.ReadLine());



System.Console.Write("How much does each pizza cost? ");
double perPizzaCost = Convert.ToDouble (Console.ReadLine());



const int PizzaSlices = 8;
int totalSlices = pizzaNeeded * PizzaSlices;
double slicesPerPerson = totalSlices / (double) peopleGoing;

double pizzaCost = pizzaNeeded * (double) perPizzaCost;

const double taxRate = 0.18;
double tripTotal = FuelCost(totalTripMiles, milesPerGallon, gasCost) + pizzaCost;
double costPerPerson = tripTotal / peopleGoing;




System.Console.WriteLine("=== Part 1: The Trip ===");
System.Console.WriteLine($"Fuel Cost: {FuelCost(totalTripMiles, milesPerGallon, gasCost)}");
System.Console.WriteLine($" Pizza Cost: {pizzaCost.ToString("C")}");
System.Console.WriteLine($"Trip Total: {tripTotal.ToString("C")}");
System.Console.WriteLine();

System.Console.WriteLine("=== Part 2: Pizza Party ===");
System.Console.WriteLine($"People Going: {peopleGoing}");
System.Console.WriteLine($"Slices Each: {slicesPerPerson.ToString("F1")}");
System.Console.WriteLine($"Cost Per Person: {costPerPerson.ToString("C")}");
System.Console.WriteLine();

double totalHours = 0;
double totalTakeHome = 0;
double longest = 0;
double[] takeHomePay = new double[4];
double[] takeHomePayPerHour = new double[4];
double[] hoursNeeded = new double[4];
for (int i = 0; i < names.Length; i++)
{
  takeHomePay[i] = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate) ;
  takeHomePayPerHour[i] = TakeHomePay(hoursWorked[i], hourlyRates[i], taxRate) / hoursWorked[i];
  hoursNeeded[i] = HoursNeeded(costPerPerson, takeHomePayPerHour[i]);
  totalHours = totalHours + hoursWorked[i];
  totalTakeHome = totalTakeHome + takeHomePay[i];
  longest = Math.Max(longest, hoursNeeded[i]);   
}

System.Console.WriteLine("=== Part 3: Who Works How Long ===");
  System.Console.WriteLine($"Ada: takes home {takeHomePay[1]}, for {hoursWorked[1]}, {hourlyRates[1]}, per hour, must work {hoursNeeded[1]}");
  System.Console.WriteLine($"Grace: ");
  System.Console.WriteLine($"Alan:");
  System.Console.WriteLine($"Katherine:");

static double FuelCost(double totalTripMiles, double milesPerGallon, double gasCost)
{
    double gallonsNeeded = totalTripMiles / (double)milesPerGallon;
    return gallonsNeeded * (double)gasCost;
}

static double TakeHomePay(double hoursWorked, double hourlyRate, double taxRate)
{
double grossPay = hoursWorked * hourlyRate;
double taxWithheld = grossPay * taxRate;
return grossPay - taxWithheld;
}
static double HoursNeeded(double costPerPerson, double takeHomePayPerHour)
{
    return costPerPerson / takeHomePayPerHour;
}