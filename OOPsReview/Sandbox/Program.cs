using OOPsReview;

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