using OOPsReview;

// example of using a record

Residence home = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
Console.WriteLine(home.ToString());

// the values in home cannot be changed through normal means.
// instead, you must create a new instance to change the values

home = new Residence(25, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
Console.WriteLine(home.ToString());