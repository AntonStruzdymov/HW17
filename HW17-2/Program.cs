static void File1()
{
    StreamReader fileReader = new StreamReader(@"C:\Users\Asus\Desktop\Антон\C#\1\HW17\HW17-2\File1.txt");
    var temp1 = fileReader.ReadToEnd();
    StreamWriter fileWriter = new StreamWriter(@"C:\Users\Asus\Desktop\Антон\C#\1\HW17\HW17-2\ResultFile.txt", true);
    fileWriter.WriteLine(temp1);
    fileReader.Close();
    fileWriter.Close();
}
static void File2()
{
    StreamReader fileReader2 = new StreamReader(@"C:\Users\Asus\Desktop\Антон\C#\1\HW17\HW17-2\File2.txt");
    var temp2 = fileReader2.ReadToEnd();
    StreamWriter fileWriter = new StreamWriter(@"C:\Users\Asus\Desktop\Антон\C#\1\HW17\HW17-2\ResultFile.txt", true);
    fileWriter.WriteLine(temp2);
    fileReader2.Close();
    fileWriter.Close();
}


Task task1 = new Task(File1);
Task task2 = new Task(File2);

task1.Start();
task1.ContinueWith(t => task2.Start());

Task.WaitAll(task1, task2);

