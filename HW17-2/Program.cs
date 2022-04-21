static void File1()
{
    StreamReader fileReader = new StreamReader("File1.txt");
    var temp1 = fileReader.ReadToEnd();
    StreamWriter fileWriter = new StreamWriter("ResultFile.txt", true);
    fileWriter.WriteLine(temp1);
    fileReader.Close();
    fileWriter.Close();
}
static void File2()
{
    StreamReader fileReader2 = new StreamReader("File2.txt");
    var temp2 = fileReader2.ReadToEnd();
    StreamWriter fileWriter = new StreamWriter("ResultFile.txt", true);
    fileWriter.WriteLine(temp2);
    fileReader2.Close();
    fileWriter.Close();
}


Task task1 = new Task(File1);
Task task2 = new Task(File2);

task1.Start();
task1.ContinueWith(t => task2.Start());

Task.WaitAll(task1, task2);

