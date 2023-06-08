using OOPsReview;
// Check Don's video for what he did here, something to do with RecordSample() and RefactorSample()
//RecordSample();
//RefactorSample();
FileIOCSV();
void RecordSample()
{
    // example of using a record

    Residence home = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
    Console.WriteLine(home.ToString());

    // the values in home cannot be changed through normal means.
    // instead, you must create a new instance to change the values

    home = new Residence(25, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
    Console.WriteLine(home.ToString());

    // example of refactoring which is a process of restructuring code while not changing the original functionality, the purpose of this
    bool testFlag;

    // original code

    if (home.prov.ToLower() == "AB")
    {
        testFlag = true;
    }
    else if (home.prov.ToLower() == "BC")
    {
        testFlag = true;
    }
    else if (home.prov.ToLower() == "SK")
    {
        testFlag = true;
    }
    else if (home.prov.ToLower() == "MN")
    {
        testFlag = true;
    }
}
void RefactorSample()
{
    // example of using a record

    Residence home = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
    Console.WriteLine(home.ToString());

    // the values in home cannot be changed through normal means.
    // instead, you must create a new instance to change the values

    home = new Residence(25, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
    Console.WriteLine(home.ToString());

    // example of refactoring which is a process of restructuring code while not changing the original functionality, the purpose of this
    bool testFlag;

    // improved code with if statement
    if (home.prov.ToLower() == "AB" ||
        home.prov.ToLower() == "BC" ||
        home.prov.ToLower() == "SK" ||
        home.prov.ToLower() == "MN")
    {
        testFlag = true;
    }
    else
    {
        testFlag = false;
    }

    // improved code with switch statement

    switch (home.prov.ToLower())
    {
        case "AB":
        case "BC":
        case "SK":
        case "MN":
            testFlag = true;
            break;
        default:
            testFlag = false;
            break;
    }
}
void FileIOCSV()
{
    // create list
    List <Employment> emp = new List <Employment>();
    emp.Add(new Employment("SAS Member", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "TeamMember"), DateTime.Parse("2015/06/14"), 3.6));
    emp.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "TeamLeader"), DateTime.Parse("2019/01/24"), 2.8));
    emp.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "Supervisor"), DateTime.Parse("2021/09/24"), 1.8));

    DumpEmployments(emp);

    WriteEmploymentCollectionToCSV(emp);

    List<Employment> empRead = new List <Employment>();
    empRead = ReadEmploymentCollectionFromCSV();

    DumpEmployments(empRead);
}
void DumpEmployments(List<Employment> emp)
{
    Console.WriteLine("\n\t\tDump of Employment Instances:\n");
    for (int i = 0; i < emp.Count; i++)
    {
        Console.WriteLine($"Instance {i}:\t {emp[i].ToString()}");
    }
}
void WriteEmploymentCollectionToCSV(List<Employment> emp)
{
    // using StreamReader and StreamWriter in conjuction with .AppendAllLines
    // filepath: C:\Temp\EmploymentData.txt
    string filePath = @"C:\Temp\EmploymentData.txt";

    // converting List into string List
    List<string> empCollection = new List<string>();
    foreach(Employment emps in emp)
    {
        empCollection.Add(emps.ToString());
    }

    File.AppendAllLines(filePath, empCollection);
}
List<Employment> ReadEmploymentCollectionFromCSV()
{
    // using StreamReader and StreamWriter in conjuction with .AppendAllLines
    // filepath: C:\Temp\EmploymentData.txt
    string filePath = @"C:\Temp\EmploymentData.txt";
    Employment empInstance = null;
    List<Employment> empCollection = new List<Employment>();

    try
    {
        string[] empCSVString = File.ReadAllLines(filePath);

        // convert array into employment instances

        foreach (string line in empCSVString)
        {
            try
            {
                empInstance = Employment.Parse(line);
                empCollection.Add(empInstance);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message}");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    return empCollection;
}