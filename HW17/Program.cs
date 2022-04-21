using HW17Library;
using System.Diagnostics;
using System.Threading;

List<Car> cars = new List<Car>();
for (int i = 0; i < 100000; i++)
{
    cars.Add(new Car(i));
}


Action<int> carAge = (int i) => { cars[i].Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute; };


Stopwatch swForeach = Stopwatch.StartNew();
foreach (var item in cars)
{
    item.Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute;
}
swForeach.Stop();
TimeSpan tsForeach = swForeach.Elapsed;
string etForeach = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", tsForeach.Hours, tsForeach.Minutes, tsForeach.Seconds, tsForeach.Milliseconds);

Stopwatch swFor = Stopwatch.StartNew();
for (int i = 0; i < cars.Count; i++)
{
    cars[i].Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute;
}
swFor.Stop();
TimeSpan tsFor = swFor.Elapsed;
string etFor = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", tsFor.Hours, tsFor.Minutes, tsFor.Seconds, tsFor.Milliseconds );

Stopwatch swParrForeach = Stopwatch.StartNew();
Parallel.ForEach(cars, car => car.Age = (343 * 34 * DateTime.Now.Millisecond * 77 * (DateTime.Now.Minute + 5)) / DateTime.Now.Minute);
swParrForeach.Stop();
TimeSpan tsParrForeach = swParrForeach.Elapsed;
string etParrForeach = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", tsParrForeach.Hours, tsParrForeach.Minutes, tsParrForeach.Seconds, tsParrForeach.Milliseconds);

Stopwatch swParrFor = Stopwatch.StartNew();
Parallel.For(0, cars.Count, carAge);
swParrFor.Stop();
TimeSpan tsParrFor = swParrFor.Elapsed;
string etParrFor = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", tsParrFor.Hours, tsParrFor.Minutes, tsParrFor.Seconds, tsParrFor.Milliseconds);

Console.WriteLine($"foreach {etForeach}");
Console.WriteLine($"for {etFor}");
Console.WriteLine($"ParralelForeach {etParrForeach}");
Console.WriteLine($"ParralelFor {etParrFor}");